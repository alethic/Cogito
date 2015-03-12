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

        class Node
        {

            public string Id { get; set; }

            public DateTime Timestamp { get; set; }

            public DateTime Sort { get; set; }

        }

        readonly object sync = new object();
        readonly string semaphoreId;
        readonly string id;
        readonly IServiceBus bus;

        Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        IDisposable subscription;
        Timer timer;
        DateTime sort;
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
            this.id = Guid.NewGuid().ToString();
            this.sort = DateTime.UtcNow;
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
            Trace.TraceInformation("Semaphore: ({0}) Acquire", semaphoreId);

            lock (sync)
            {
                if (disposed)
                    throw new ObjectDisposedException(semaphoreId);

                // begin listening to messages
                if (subscription == null)
                    subscription = bus.Subscribe<SemaphoreMessage>(OnMessage, i => i.SemaphoreId == semaphoreId);

                // begin attempting to acquire resource
                sort = DateTime.UtcNow;
                nodes = new Dictionary<string, Node>();
                timer.Start();
            }
        }

        /// <summary>
        /// Releases the resource allocation.
        /// </summary>
        public void Release()
        {
            Trace.TraceInformation("Semaphore: ({0}) Release", semaphoreId);

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
                        bus.Publish<SemaphoreMessage>(new SemaphoreMessage()
                        {
                            SemaphoreId = semaphoreId,
                            InstanceId = id,
                            Timestamp = DateTime.UtcNow,
                            Sort = sort,
                            Status = SemaphoreStatus.Release,
                        }, x => x.SetExpirationTime(DateTime.Now.AddMinutes(1)).SetRetryCount(0));
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
                                Sort = sort,
                                Status = SemaphoreStatus.Acquire,
                            }, x => x.SetExpirationTime(DateTime.Now.AddMinutes(1)).SetRetryCount(0));
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
                    node.Sort = message.Sort;

                    // remote semaphore node is not seeking to acquire a resource
                    if (message.Status == SemaphoreStatus.Release)
                        nodes.Remove(node.Id);

                    // remove stale nodes
                    foreach (var i in nodes.Where(i => i.Value.Timestamp < DateTime.UtcNow.AddMinutes(-1)).Select(i => i.Key).ToArray())
                        nodes.Remove(i);

                    // order nodes by age
                    var ordered = nodes.Values
                        .OrderBy(i => i.Sort)
                        .ToArray();

                    // update counts
                    peers = ordered.Length;
                    consumed = Math.Min(resources, peers);

                    // determine whether we are one of the running nodes
                    var running = ordered.Take(resources).ToArray();
                    var self = running.Where(i => i.Id == id).FirstOrDefault();

                    // is our own record at least 30 seconds old?
                    if (self != null && self.Sort <= DateTime.UtcNow.AddSeconds(-30))
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
            Trace.TraceInformation("Semaphore: ({0}) OnAcquired", semaphoreId);

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
            Trace.TraceInformation("Semaphore: ({0}) OnReleased", semaphoreId);

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
