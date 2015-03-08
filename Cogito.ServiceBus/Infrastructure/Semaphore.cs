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

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        protected internal Semaphore()
        {

        }

        /// <summary>
        /// Acquires a resource. This operation begins engaging with the service bus.
        /// </summary>
        public abstract void Acquire();

        /// <summary>
        /// Releases a resource. This operation stops engaging with the service bus.
        /// </summary>
        public abstract void Release();

        /// <summary>
        /// Gets or sets the maximum number of instances that can be running.
        /// </summary>
        public abstract int Resources { get; set; }

        /// <summary>
        /// Gets the number of available instances that can be running.
        /// </summary>
        public abstract int Peers { get; }

        /// <summary>
        /// Gets the current number of instances that are running.
        /// </summary>
        public abstract int Consumed { get; }

        /// <summary>
        /// Returns <c>true</c> if a resource has been acquired.
        /// </summary>
        public abstract bool IsAcquired { get; }

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
        public virtual void Dispose()
        {

        }

    }

    /// <summary>
    /// Maintains a distributed semaphore structure. Requires a <see cref="ServiceBus"/> that participates in
    /// broadcast messages.
    /// </summary>
    /// <typeparam name="TIdentity">Unique identity of the semaphore on the broadcast bus.</typeparam>
    public class Semaphore<TIdentity> :
        Semaphore
    {

        readonly object sync = new object();
        readonly Guid id;
        readonly DateTime sort;
        readonly IServiceBus bus;

        ImmutableDictionary<Guid, Tuple<DateTime, DateTime>> nodes = ImmutableDictionary<Guid, Tuple<DateTime, DateTime>>.Empty;
        IDisposable subscription;
        Timer timer;
        int resources;
        int peers;
        int consumed;
        bool isAcquired;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="resources"></param>
        public Semaphore(IServiceBus bus, int resources)
        {
            Contract.Requires<ArgumentNullException>(bus != null);

            this.id = Guid.NewGuid();
            this.sort = DateTime.UtcNow;
            this.bus = bus;
            this.resources = resources;

            this.isAcquired = false;
            this.subscription = this.bus.Subscribe<SemaphoreMessage<TIdentity>>(OnServiceMessage);

            this.timer = new Timer();
            this.timer.Interval = TimeSpan.FromSeconds(5).TotalMilliseconds;
            this.timer.Elapsed += timer_Elapsed;
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

        /// <summary>
        /// Gets the total number of resources.
        /// </summary>
        public override int Resources
        {
            get { return resources; }
            set { resources = value; }
        }

        /// <summary>
        /// Gets the total number of peers waiting for resources.
        /// </summary>
        public override int Peers
        {
            get { return peers; }
        }

        /// <summary>
        /// Gets the current number of resources that are consumed.
        /// </summary>
        public override int Consumed
        {
            get { return consumed; }
        }

        /// <summary>
        /// Gets whether or not this node is active.
        /// </summary>
        public override bool IsAcquired
        {
            get { return isAcquired; }
        }

        /// <summary>
        /// Acquires a resource allocation.
        /// </summary>
        public override void Acquire()
        {
            timer.Start();
        }

        /// <summary>
        /// Releases the resource allocation.
        /// </summary>
        public override void Release()
        {
            lock (sync)
            {
                if (timer.Enabled)
                {
                    timer.Stop();

                    // signal others
                    bus.Publish<SemaphoreMessage<TIdentity>>(new SemaphoreMessage<TIdentity>()
                    {
                        Id = id,
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
                    bus.Publish<SemaphoreMessage<TIdentity>>(new SemaphoreMessage<TIdentity>()
                    {
                        Id = id,
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
        void OnServiceMessage(SemaphoreMessage<TIdentity> message)
        {
            lock (sync)
            {
                if (timer.Enabled)
                {
                    // remote semaphore node is seeking to acquire a resource
                    if (message.Status == SemaphoreStatus.Acquire)
                        nodes = nodes.SetItem(message.Id, Tuple.Create(message.Timestamp, message.Sort));

                    // remote semaphore node is not seeking to acquire a resource
                    if (message.Status == SemaphoreStatus.Release)
                        nodes = nodes.Remove(message.Id);

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
        /// Disposes of the instance.
        /// </summary>
        public override void Dispose()
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

            base.Dispose();
        }

    }

}
