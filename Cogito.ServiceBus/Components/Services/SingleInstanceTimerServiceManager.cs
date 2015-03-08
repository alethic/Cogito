using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;

using Cogito.ServiceBus.Infrastructure;

namespace Cogito.Components.Services
{

    /// <summary>
    /// Provides a service manager for a <see cref="SingleInstanceTimerService{TService}"/>.
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    [Export(typeof(SingleInstanceTimerServiceManager<>))]
    public class SingleInstanceTimerServiceManager<TService> :
        LimitedInstanceServiceManager<TService>
        where TService : IService
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="semaphore"></param>
        [ImportingConstructor]
        public SingleInstanceTimerServiceManager(
            Semaphore<TService> semaphore)
            : base(semaphore)
        {
            Contract.Requires<ArgumentNullException>(semaphore != null);

            // single instance service requires one instance
            base.Instances = 1;
        }

        /// <summary>
        /// Gets or sets the number of instances that should be running.
        /// </summary>
        public override sealed int Instances
        {
            get { return base.Instances; }
            set { base.Instances = 1; }
        }

    }

}
