using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;

using Cogito.Components;
using Cogito.ServiceBus.Infrastructure;

namespace Cogito.ServiceBus.Components
{

    /// <summary>
    /// Provides a service manager for a <see cref="SingleNodeMessageHandler{TComponent}"/>.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    [Export(typeof(SingleNodeMessageHandlerManager<>))]
    public class SingleNodeMessageHandlerManager<TComponent> :
        DistributedComponentManager<TComponent>
        where TComponent : IComponent
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="semaphore"></param>
        [ImportingConstructor]
        public SingleNodeMessageHandlerManager(
            Semaphore<TComponent> semaphore)
            : base(semaphore)
        {
            Contract.Requires<ArgumentNullException>(semaphore != null);

            // single instance component requires at least one instance
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
