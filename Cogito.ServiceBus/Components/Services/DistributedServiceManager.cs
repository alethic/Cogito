using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Diagnostics.Contracts;

using Cogito.ServiceBus.Infrastructure;

namespace Cogito.Components.Services
{

    /// <summary>
    /// Manages a <see cref="DistributedService"/>.
    /// </summary>
    public abstract class DistributedServiceManager
    {

        readonly object sync = new object();
        readonly Semaphore semaphore;
        readonly string serviceName;
        bool running;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="semaphore"></param>
        /// <param name="serviceName"></param>
        internal protected DistributedServiceManager(
            Semaphore semaphore,
            string serviceName)
        {
            Contract.Requires<ArgumentNullException>(semaphore != null);
            Contract.Requires<ArgumentNullException>(serviceName != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(serviceName));

            this.semaphore = semaphore;
            this.semaphore.Resources = 1;
            this.semaphore.Acquired += (s, a) => Evaluate();
            this.semaphore.Released += (s, a) => Evaluate();
            this.serviceName = serviceName;
        }

        /// <summary>
        /// Gets or sets the number of instances that can be running.
        /// </summary>
        public virtual int Instances
        {
            get { return semaphore.Resources; }
            set { Contract.Requires<ArgumentOutOfRangeException>(value >= 1); semaphore.Resources = value; }
        }

        /// <summary>
        /// Signals that the service would like to be running.
        /// </summary>
        public void Enable()
        {
            lock (sync)
            {
                semaphore.Acquire();
                Evaluate();
            }
        }

        /// <summary>
        /// Signals that the service no longer needs to be running.
        /// </summary>
        public void Disable()
        {
            lock (sync)
            {
                semaphore.Release();
                Evaluate();
            }
        }

        /// <summary>
        /// Gets whether or not the service should be running.
        /// </summary>
        public bool Runnable
        {
            get { return semaphore.IsAcquired; }
        }

        /// <summary>
        /// Raised when the service should be started.
        /// </summary>
        public EventHandler Start;

        /// <summary>
        /// Raises the Start event.
        /// </summary>
        /// <param name="args"></param>
        protected void OnStart(EventArgs args)
        {
            Contract.Requires<ArgumentNullException>(args != null);
            Trace.TraceInformation("DistributedServiceManager ({0}): OnStart", serviceName);

            if (Start != null)
                Start(this, args);
        }

        /// <summary>
        /// Raised when the service should be stopped.
        /// </summary>
        public EventHandler Stop;

        /// <summary>
        /// Raises the Stop event.
        /// </summary>
        /// <param name="args"></param>
        protected void OnStop(EventArgs args)
        {
            Contract.Requires<ArgumentNullException>(args != null);
            Trace.TraceInformation("DistributedServiceManager ({0}): OnStop", serviceName);

            if (Stop != null)
                Stop(this, args);
        }

        /// <summary>
        /// Evaluates whether the service should be running and starts or stops it.
        /// </summary>
        void Evaluate()
        {
            if (!running && Runnable)
            {
                running = true;
                OnStart(EventArgs.Empty);
            }
            else if (running)
            {
                OnStop(EventArgs.Empty);
                running = false;
            }
        }

    }

    /// <summary>
    /// Used by a <see cref="DistributedService"/> to maintain Service Bus signaling.
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    [Export(typeof(DistributedServiceManager<>))]
    public class DistributedServiceManager<TService> :
        DistributedServiceManager
        where TService : IService
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="semaphore"></param>
        [ImportingConstructor]
        public DistributedServiceManager(
            Semaphore<TService> semaphore)
            : base(semaphore, typeof(TService).FullName)
        {
            Contract.Requires<ArgumentNullException>(semaphore != null);
        }

    }

}