using System;
using System.Diagnostics.Contracts;

using Cogito.Components;

namespace Cogito.ServiceBus.Components
{

    /// <summary>
    /// Base class for a <see cref="IComponent"/> that consumes messages from a named service bus and runs only once
    /// on the cluster.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <typeparam name="TMessage"></typeparam>
    public abstract class SingleNodeMessageHandler<TComponent, TMessage> :
        DistributedComponent<TComponent>
        where TComponent : class, IComponent
        where TMessage : class
    {

        readonly IServiceBus<TComponent> bus;
        readonly DistributedComponentManager<TComponent> manager;
        IDisposable subscription;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="manager"></param>
        public SingleNodeMessageHandler(
            SingleNodeMessageHandlerManager<TComponent> manager,
            IServiceBus<TComponent> bus)
            : base(manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null);
            Contract.Requires<ArgumentNullException>(bus != null);

            this.manager = manager;
            this.bus = bus;
        }

        protected override void OnStart()
        {
            if (subscription != null)
            {
                subscription.Dispose();
                subscription = null;
            }

            subscription = bus.Subscribe<TMessage>(MessageHandler);
        }

        protected override void OnStop()
        {
            if (subscription != null)
            {
                subscription.Dispose();
                subscription = null;
            }
        }

        /// <summary>
        /// Attempts to process the message and ensures any exceptions are logged.
        /// </summary>
        /// <param name="context"></param>
        void MessageHandler(IConsumeContext<TMessage> context)
        {
            Contract.Requires<ArgumentNullException>(context != null);

            try
            {
                OnMessage(context);
            }
            catch (Exception e)
            {
                e.Trace();
                throw e;
            }
        }

        /// <summary>
        /// Implement this method to handle incoming messages.
        /// </summary>
        /// <param name="context"></param>
        protected abstract void OnMessage(IConsumeContext<TMessage> context);

    }

}
