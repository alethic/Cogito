using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Diagnostics.Contracts;

using Cogito.Components;
using Cogito.ServiceBus.Infrastructure;

namespace Cogito.ServiceBus.Components
{

    /// <summary>
    /// Manages a <see cref="DistributedComponent"/>. Attaches to the given <see cref="Semaphore"/> and uses it to
    /// monitor whether or not the currently identified node should be up or down.
    /// </summary>
    public abstract class DistributedComponentManager
    {

        readonly object sync = new object();
        readonly Semaphore semaphore;
        readonly string name;
        bool running;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="semaphore"></param>
        /// <param name="name"></param>
        internal protected DistributedComponentManager(
            Semaphore semaphore,
            string name)
        {
            Contract.Requires<ArgumentNullException>(semaphore != null);
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(name));

            this.semaphore = semaphore;
            this.semaphore.Resources = 1;
            this.semaphore.Acquired += (s, a) => Evaluate();
            this.semaphore.Released += (s, a) => Evaluate();
            this.name = name;
        }

        /// <summary>
        /// Gets or sets the number of nodes that can be running.
        /// </summary>
        public virtual int Instances
        {
            get { return semaphore.Resources; }
            set { Contract.Requires<ArgumentOutOfRangeException>(value >= 1); semaphore.Resources = value; }
        }

        /// <summary>
        /// Signals that the component would like to be running.
        /// </summary>
        internal void Enable()
        {
            lock (sync)
            {
                semaphore.Acquire();
                Evaluate();
            }
        }

        /// <summary>
        /// Signals that the component no longer needs to be running.
        /// </summary>
        internal void Disable()
        {
            lock (sync)
            {
                semaphore.Release();
                Evaluate();
            }
        }

        /// <summary>
        /// Gets whether or not the component should be running.
        /// </summary>
        public bool Runnable
        {
            get { return semaphore.IsAcquired; }
        }

        /// <summary>
        /// Raised when the component should be started.
        /// </summary>
        public EventHandler Start;

        /// <summary>
        /// Raises the Start event.
        /// </summary>
        /// <param name="args"></param>
        void OnStart(EventArgs args)
        {
            Contract.Requires<ArgumentNullException>(args != null);
            Trace.TraceInformation("{0} ({1}): OnStart", typeof(DistributedComponentManager).Name, name);

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
        void OnStop(EventArgs args)
        {
            Contract.Requires<ArgumentNullException>(args != null);
            Trace.TraceInformation("{0} ({1}): OnStop", typeof(DistributedComponentManager).Name, name);

            if (Stop != null)
                Stop(this, args);
        }

        /// <summary>
        /// Evaluates whether the service should be running and starts or stops it.
        /// </summary>
        void Evaluate()
        {
            lock (sync)
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

    }

    /// <summary>
    /// Used by a <see cref="DistributedComponent"/> to maintain Service Bus signaling.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    [Export(typeof(DistributedComponentManager<>))]
    public class DistributedComponentManager<TComponent> :
        DistributedComponentManager
        where TComponent : IComponent
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="semaphore"></param>
        [ImportingConstructor]
        public DistributedComponentManager(
            Semaphore<TComponent> semaphore)
            : base(semaphore, typeof(TComponent).FullName)
        {
            Contract.Requires<ArgumentNullException>(semaphore != null);
        }

    }

}