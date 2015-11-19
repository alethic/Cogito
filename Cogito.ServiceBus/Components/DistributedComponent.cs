using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

using Cogito.Components;

namespace Cogito.ServiceBus.Components
{

    /// <summary>
    /// Component implementation that limits the number of instances that can be running at a given time on a cluster.
    /// Be sure to pass a <see cref="DistributedComponentManager"/> of the appropriate <see cref="IComponent"/> type
    /// to the constructor.
    /// </summary>
    public abstract class DistributedComponent<TComponent> :
        Component
        where TComponent : IComponent
    {

        readonly DistributedComponentManager<TComponent> manager;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="manager"></param>
        public DistributedComponent(
            DistributedComponentManager<TComponent> manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null);

            this.manager = manager;
            this.manager.Start += (s, a) => InvokeOnStart();
            this.manager.Stop += (s, a) => InvokeOnStop();
        }

        /// <summary>
        /// Gets or sets the number of component instances that can be running at one time.
        /// </summary>
        public int Instances
        {
            get { return manager.Instances; }
            set { Contract.Requires<ArgumentOutOfRangeException>(value >= 1); manager.Instances = value; }
        }

        /// <summary>
        /// Implements the service start method. Does not immediately start the component. Instead signals the manager.
        /// </summary>
        public override sealed void Start()
        {
            manager.Enable();
        }

        /// <summary>
        /// Implements the stop method. Does not immediately stop the component. Instead signals the manager.
        /// </summary>
        public override sealed void Stop()
        {
            manager.Disable();
        }

        /// <summary>
        /// Invoked when the component should be started.
        /// </summary>
        protected virtual void OnStart()
        {

        }

        void InvokeOnStart()
        {
            Trace.TraceInformation("{0}: starting...", GetType().FullName);
            OnStart();
        }

        /// <summary>
        /// Invoked when the component should be stopped.
        /// </summary>
        protected virtual void OnStop()
        {

        }

        void InvokeOnStop()
        {
            Trace.TraceInformation("{0}: stopping...", GetType().FullName);
            OnStop();
        }

    }

}
