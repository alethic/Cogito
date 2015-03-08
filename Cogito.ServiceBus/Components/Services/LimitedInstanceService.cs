using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Cogito.Components.Services
{

    /// <summary>
    /// Service implementation that limits the number of instances that can be running at a given time. Be sure to
    /// pass a <see cref="LimitedInstanceServiceManager"/> of the appropriate <see cref="IService"/> type to the
    /// constructor.
    /// </summary>
    public abstract class LimitedInstanceService :
        ServiceBase
    {

        readonly LimitedInstanceServiceManager manager;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="manager"></param>
        public LimitedInstanceService(LimitedInstanceServiceManager manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null);

            this.manager = manager;
            this.manager.Start += (s, a) => InvokeOnStart();
            this.manager.Stop += (s, a) => InvokeOnStop();
        }

        /// <summary>
        /// Gets or sets the number of service instances that can be running at one time.
        /// </summary>
        public int Instances
        {
            get { return manager.Instances; }
            set { Contract.Requires<ArgumentOutOfRangeException>(value >= 1); manager.Instances = value; }
        }

        /// <summary>
        /// Implements the service start method. Does not immediately start the service. Instead signals the manager.
        /// </summary>
        public override sealed void Start()
        {
            manager.Enable();
        }

        /// <summary>
        /// Implements the stop method. Does not immediately stop the service. Instead signals the manager.
        /// </summary>
        public override sealed void Stop()
        {
            manager.Disable();
        }

        /// <summary>
        /// Invoked when the service should be started.
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
        /// Invoked when the service should be stopped.
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
