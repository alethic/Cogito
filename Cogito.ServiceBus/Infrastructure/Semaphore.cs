using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Timers;

namespace Cogito.ServiceBus.Infrastructure
{

    /// <summary>
    /// Maintains a distributed semaphore structure. Requires a <see cref="ServiceBus"/> that participates in
    /// broadcast messages.
    /// </summary>
    /// <typeparam name="TIdentity">Unique identity of the semaphore on the broadcast bus.</typeparam>
    public class Semaphore<TIdentity> :
        IDisposable
    {

        readonly object sync = new object();
        readonly Guid id;
        readonly DateTime sort;
        readonly Dictionary<Guid, Tuple<DateTime, DateTime>> registrations = new Dictionary<Guid, Tuple<DateTime, DateTime>>();
        readonly IServiceBus bus;

        IDisposable subscription;
        Timer timer;
        int max;
        int available;
        int active;
        bool isActive;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="max"></param>
        public Semaphore(IServiceBus bus, int max)
        {
            Contract.Requires<ArgumentNullException>(bus != null);

            this.id = Guid.NewGuid();
            this.sort = DateTime.UtcNow;
            this.bus = bus;
            this.max = max;

            this.isActive = false;
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
        /// Gets the maximum number of instances that can be running.
        /// </summary>
        public int Maximum
        {
            get { return max; }
        }

        /// <summary>
        /// Gets the number of available instances that can be running.
        /// </summary>
        public int Available
        {
            get { return available; }
        }

        /// <summary>
        /// Gets the current number of instances that are running.
        /// </summary>
        public int Active
        {
            get { return active; }
        }

        /// <summary>
        /// Gets whether or not this node is active.
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
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
                        Ping = DateTime.UtcNow,
                        Sort = sort,
                        Status = SemaphoreStatus.Unavailable,
                    }, x => x.SetExpirationTime(DateTime.UtcNow.AddSeconds(5)));

                    // deactivate
                    OnDeactive();
                }
            }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs args)
        {
            lock (sync)
            {
                // notify that we're still alive
                bus.Publish<SemaphoreMessage<TIdentity>>(new SemaphoreMessage<TIdentity>()
                {
                    Id = id,
                    Ping = DateTime.UtcNow,
                    Sort = sort,
                    Status = SemaphoreStatus.Available,
                }, x => x.SetExpirationTime(DateTime.UtcNow.AddSeconds(5)));
            }
        }

        void OnServiceMessage(SemaphoreMessage<TIdentity> message)
        {
            lock (sync)
            {
                if (timer.Enabled)
                {
                    // service is alive
                    if (message.Status == SemaphoreStatus.Available)
                        registrations[message.Id] = Tuple.Create(message.Ping, message.Sort);

                    // service is disposed
                    if (message.Status == SemaphoreStatus.Unavailable)
                        registrations.Remove(message.Id);

                    // remove stale registrations
                    foreach (var i in registrations.Where(i => i.Value.Item1 < DateTime.UtcNow.AddSeconds(-15)).ToList())
                        registrations.Remove(i.Key);

                    // select oldest count registrations
                    var all = registrations
                        .OrderBy(i => i.Value.Item2)
                        .Select(i => i.Key)
                        .ToList();

                    // update counts
                    available = all.Count;
                    active = all.Take(max).Count();

                    if (all.Take(max).Contains(id))
                        OnActive();
                    else
                        OnDeactive();
                }
            }
        }

        void OnActive()
        {
            if (!isActive)
            {
                isActive = true;
                OnActivated(EventArgs.Empty);
            }
        }

        void OnDeactive()
        {
            if (isActive)
            {
                isActive = false;
                OnDeactivated(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Raised when the service is activated.
        /// </summary>
        public event EventHandler Activated;

        /// <summary>
        /// Raises the activated event.
        /// </summary>
        /// <param name="args"></param>
        void OnActivated(EventArgs args)
        {
            Debug.Print("Activated: {0}", id);

            if (Activated != null)
                Activated(this, args);
        }

        /// <summary>
        /// Raised when the service is deactivated.
        /// </summary>
        public event EventHandler Deactivated;

        /// <summary>
        /// Raises the Deactivated event.
        /// </summary>
        /// <param name="args"></param>
        void OnDeactivated(EventArgs args)
        {
            Debug.Print("Deactivated: {0}", id);

            if (Deactivated != null)
                Deactivated(this, args);
        }

        public void Dispose()
        {
            Stop();

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

}
