using System;
using System.Collections.Immutable;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Timers;

namespace Cogito.ServiceBus.Infrastructure
{

    /// <summary>
    /// Maintains a distributed semaphore structure. Requires a <see cref="ServiceBus"/> that participates in
    /// broadcast messages.
    /// </summary>
    public abstract class Semaphore :
        IDisposable
    {

        readonly object sync = new object();
        readonly string semaphoreId;
        readonly string id;
        readonly DateTime sort;
        readonly IServiceBus bus;

        ImmutableDictionary<string, Tuple<DateTime, DateTime>> nodes = ImmutableDictionary<string, Tuple<DateTime, DateTime>>.Empty;
        IDisposable subscription;
        Timer timer;
        int resources;
        int peers;
        int consumed;
        bool isAcquired;

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
            this.subscription = this.bus.Subscribe<SemaphoreMessage>(OnServiceMessage);

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
            timer.Start();
        }

        /// <summary>
        /// Releases the resource allocation.
        /// </summary>
        public void Release()
        {
            lock (sync)
            {
                if (timer.Enabled)
                {
                    timer.Stop();

                    // signal others
                    bus.Publish<SemaphoreMessage>(new SemaphoreMessage()
                    {
                        SemaphoreId = semaphoreId,
                        InstanceId = id,
                        Timestamp = DateTime.UtcNow,
                        Sort = sort,
                        Status = SemaphoreStatus.Release,
                    }, x => x.SetExpirationTime(DateTime.UtcNow.AddSeconds(5)));

                    // deactivate
                    OnRelease();
                }
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
                if (timer.Enabled)
                {
                    bus.Publish<SemaphoreMessage>(new SemaphoreMessage()
                    {
                        SemaphoreId = semaphoreId,
                        InstanceId = id,
                        Timestamp = DateTime.UtcNow,
                        Sort = sort,
                        Status = SemaphoreStatus.Acquire,
                    }, x => x.SetExpirationTime(DateTime.UtcNow.AddSeconds(5)));
                }
            }
        }

        /// <summary>
        /// Invoked when a bus message arrives.
        /// </summary>
        /// <param name="message"></param>
        void OnServiceMessage(SemaphoreMessage message)
        {
            lock (sync)
            {
                if (timer.Enabled)
                {
                    // message not destined to us
                    if (message.SemaphoreId != semaphoreId)
                        return;

                    // remote semaphore node is seeking to acquire a resource
                    if (message.Status == SemaphoreStatus.Acquire)
                        nodes = nodes.SetItem(message.InstanceId, Tuple.Create(message.Timestamp, message.Sort));

                    // remote semaphore node is not seeking to acquire a resource
                    if (message.Status == SemaphoreStatus.Release)
                        nodes = nodes.Remove(message.InstanceId);

                    // remove stale nodes
                    nodes = nodes.RemoveRange(nodes.Where(i => i.Value.Item1 < DateTime.UtcNow.AddSeconds(-15)).Select(i => i.Key));

                    // order nodes by age
                    var ordered = nodes
                        .OrderBy(i => i.Value.Item2)
                        .Select(i => i.Key)
                        .ToArray();

                    // update counts
                    peers = ordered.Length;
                    consumed = Math.Min(resources, peers);

                    // are we a member of the active set?
                    if (ordered.Take(resources).Contains(id))
                        OnAcquire();
                    else
                        OnRelease();
                }
            }
        }

        /// <summary>
        /// Signals that a resource was acquired.
        /// </summary>
        void OnAcquire()
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
        void OnRelease()
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
            if (Released != null)
                Released(this, args);
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            Release();

            if (subscription != null)
            {
                subscription.Dispose();
                subscription = null;
            }

            if (bus != null)
            {
                bus.Dispose();
            }
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
        public Semaphore(IServiceBus bus, int resources)
            : base(bus, typeof(TIdentity).FullName, resources)
        {
            Contract.Requires<ArgumentNullException>(bus != null);
            Contract.Requires<ArgumentNullException>(resources >= 1);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        public Semaphore(IServiceBus bus)
            : this(bus, 1)
        {
            Contract.Requires<ArgumentNullException>(bus != null);
        }

    }

}
