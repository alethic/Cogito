using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Timers;

using Cogito.Collections;

namespace Cogito.ServiceBus.Infrastructure
{

    /// <summary>
    /// Maintains a distributed semaphore structure. Requires a <see cref="ServiceBus"/> that participates in
    /// broadcast messages.
    /// </summary>
    public abstract class Semaphore :
        IDisposable
    {

        /// <summary>
        /// Describes a known running instance.
        /// </summary>
        class Node
        {

            /// <summary>
            /// Unique identifier of the node.
            /// </summary>
            public Guid Id { get; set; }

            /// <summary>
            /// Last update time of the node.
            /// </summary>
            public DateTime Timestamp { get; set; }

            /// <summary>
            /// Time the node was first initialized.
            /// </summary>
            public DateTime StartTime { get; set; }

            /// <summary>
            /// Used in order to decide which node to select.
            /// </summary>
            public int Priority { get; set; }

        }

        readonly object sync = new object();
        readonly string semaphoreId;
        readonly Guid id;
        readonly IServiceBus bus;

        Dictionary<Guid, Node> nodes = new Dictionary<Guid, Node>();
        IDisposable subscription;
        Timer timer;
        DateTime startTime;
        int priority;
        int resources;
        int peers;
        int consumed;
        bool isAcquired;
        bool disposed;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        protected internal Semaphore(IServiceBus bus, string semaphoreId, int resources)
        {
            Contract.Requires<ArgumentNullException>(bus != null);
            Contract.Requires<ArgumentNullException>(semaphoreId != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(semaphoreId));

            this.semaphoreId = semaphoreId;
            this.id = Guid.NewGuid();
            this.priority = Guid.NewGuid().GetHashCode();
            this.startTime = DateTime.UtcNow;
            this.bus = bus;
            this.resources = resources;

            this.isAcquired = false;

            this.timer = new Timer();
            this.timer.Interval = TimeSpan.FromSeconds(5).TotalMilliseconds;
            this.timer.Elapsed += timer_Elapsed;
        }

        /// <summary>
        /// Gets or sets the maximum number of instances that can be running.
        /// </summary>
        public int Resources
        {
            get { return resources; }
            set { resources = value; }
        }

        /// <summary>
        /// Gets the total number of peers waiting for resources.
        /// </summary>
        public int Peers
        {
            get { return peers; }
        }

        /// <summary>
        /// Gets the current number of resources that are consumed.
        /// </summary>
        public int Consumed
        {
            get { return consumed; }
        }

        /// <summary>
        /// Gets whether or not this node is active.
        /// </summary>
        public bool IsAcquired
        {
            get { return isAcquired; }
        }

        /// <summary>
        /// Acquires a resource allocation.
        /// </summary>
        public void Acquire()
        {
            Trace.TraceInformation("{0}: ({1}) Acquire", typeof(Semaphore).FullName, semaphoreId);

            lock (sync)
            {
                if (disposed)
                    throw new ObjectDisposedException(semaphoreId);

                // begin listening to messages
                if (subscription == null)
                    subscription = bus.Subscribe<SemaphoreMessage>(OnMessage, i => i.SemaphoreId == semaphoreId);

                // begin attempting to acquire resource
                startTime = DateTime.UtcNow;
                priority = Guid.NewGuid().GetHashCode();
                nodes.Remove(id);
                timer.Start();
            }
        }

        /// <summary>
        /// Releases the resource allocation.
        /// </summary>
        public void Release()
        {
            Trace.TraceInformation("{0}: ({1}) Release", typeof(Semaphore).FullName, semaphoreId);

            // cease publishing messages immediately
            timer.Stop();

            lock (sync)
            {
                if (disposed)
                    throw new ObjectDisposedException(semaphoreId);

                // second stop within lock
                timer.Stop();

                try
                {
                    // signal that we are no longer interested in a resource
                    if (bus != null)
                    {
                        bus.Publish(new SemaphoreMessage()
                        {
                            SemaphoreId = semaphoreId,
                            InstanceId = id,
                            Timestamp = DateTime.UtcNow,
                            StartTime = startTime,
                            Priority = priority,
                            Status = SemaphoreStatus.Release,
                        }, x => x.SetExpirationTime(DateTime.Now.AddSeconds(15)).SetRetryCount(0));
                    }
                }
                catch (Exception e)
                {
                    e.Trace();
                }

                // cease our subscription
                if (subscription != null)
                {
                    subscription.Dispose();
                    subscription = null;
                }

                // reset counters
                peers = 0;
                consumed = 0;

                // deactivate
                SetRelease();
            }
        }

        /// <summary>
        /// Invoked periodically. Publishes notification messages to the bus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void timer_Elapsed(object sender, ElapsedEventArgs args)
        {
            lock (sync)
            {
                if (disposed)
                    return;

                if (timer.Enabled)
                {
                    try
                    {
                        if (bus != null)
                        {
                            bus.Publish<SemaphoreMessage>(new SemaphoreMessage()
                            {
                                SemaphoreId = semaphoreId,
                                InstanceId = id,
                                Timestamp = DateTime.UtcNow,
                                StartTime = startTime,
                                Priority = priority,
                                Status = SemaphoreStatus.Acquire,
                            }, x => x.SetExpirationTime(DateTime.Now.AddSeconds(15)).SetRetryCount(0));
                        }
                    }
                    catch (Exception e)
                    {
                        e.Trace();
                    }
                }
            }
        }

        /// <summary>
        /// Invoked when a bus message arrives.
        /// </summary>
        /// <param name="message"></param>
        void OnMessage(SemaphoreMessage message)
        {
            Contract.Assert(message.SemaphoreId == semaphoreId);

            try
            {
                lock (sync)
                {
                    if (disposed)
                        return;

                    // insert or update node
                    var node = nodes.GetOrAdd(message.InstanceId, _ => new Node() { Id = message.InstanceId });
                    node.Timestamp = message.Timestamp;
                    node.StartTime = message.StartTime;
                    node.Priority = message.Priority;

                    // remote semaphore node is not seeking to acquire a resource
                    if (message.Status == SemaphoreStatus.Release)
                        nodes.Remove(node.Id);

                    // remove stale nodes
                    foreach (var i in nodes.Where(i => i.Value.Timestamp < DateTime.UtcNow.AddMinutes(-1)).Select(i => i.Key).ToArray())
                        nodes.Remove(i);

                    // order nodes by age
                    var ordered = nodes.Values
                        .OrderByDescending(i => i.Priority)
                        .ToArray();

                    // update counts
                    peers = ordered.Length;
                    consumed = Math.Min(resources, peers);

                    // determine whether we are one of the running nodes
                    var running = ordered.Take(resources).ToArray();
                    var self = running.Where(i => i.Id == id).FirstOrDefault();

                    // is our own record at least 15 seconds old?
                    if (self != null && self.StartTime <= DateTime.UtcNow.AddSeconds(-15))
                    {
                        // we acquired the semaphore
                        SetAcquire();
                    }
                    else
                    {
                        // we did not acquire the semaphore
                        SetRelease();
                    }
                }
            }
            catch (Exception e)
            {
                e.Trace();
            }
        }

        /// <summary>
        /// Signals that a resource was acquired.
        /// </summary>
        void SetAcquire()
        {
            if (!isAcquired)
            {
                isAcquired = true;
                OnAcquired(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Signals that a resource was released.
        /// </summary>
        void SetRelease()
        {
            if (isAcquired)
            {
                isAcquired = false;
                OnReleased(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Raised when a resource is acquired.
        /// </summary>
        public event EventHandler Acquired;

        /// <summary>
        /// Raises the Acquired event.
        /// </summary>
        /// <param name="args"></param>
        protected void OnAcquired(EventArgs args)
        {
            Contract.Requires<ArgumentNullException>(args != null);
            Trace.TraceInformation("{0}: ({1}) OnAcquired", typeof(Semaphore).FullName, semaphoreId);

            if (Acquired != null)
                Acquired(this, args);
        }

        /// <summary>
        /// Raised when the service is deactivated.
        /// </summary>
        public event EventHandler Released;

        /// <summary>
        /// Raises the Released event.
        /// </summary>
        /// <param name="args"></param>
        protected void OnReleased(EventArgs args)
        {
            Contract.Requires<ArgumentNullException>(args != null);
            Trace.TraceInformation("{0}: ({1}) OnReleased", typeof(Semaphore).FullName, semaphoreId);

            if (Released != null)
                Released(this, args);
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (timer != null)
                {
                    timer.Stop();
                }

                if (subscription != null)
                {
                    subscription.Dispose();
                    subscription = null;
                }
            }

            disposed = true;
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes the instance.
        /// </summary>
        ~Semaphore()
        {
            Dispose(false);
        }

    }

    /// <summary>
    /// Maintains a distributed semaphore structure. Requires a <see cref="ServiceBus"/> that participates in
    /// broadcast messages.
    /// </summary>
    /// <typeparam name="TIdentity">Unique identity of the semaphore on the broadcast bus.</typeparam>
    public sealed class Semaphore<TIdentity> :
        Semaphore
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="resources"></param>
        public Semaphore(
            IServiceBus bus,
            int resources)
            : base(bus, typeof(TIdentity).FullName, resources)
        {
            Contract.Requires<ArgumentNullException>(bus != null);
            Contract.Requires<ArgumentNullException>(resources >= 1);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        public Semaphore(
            IServiceBus bus)
            : this(bus, 1)
        {
            Contract.Requires<ArgumentNullException>(bus != null);
        }

    }

}
