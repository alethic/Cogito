using System;
using System.Diagnostics.Contracts;

using Cogito.Components;

namespace Cogito.ServiceBus.Components
{

    /// <summary>
    /// Base class for a <see cref="IComponent"/> that consumes messages from a unique service bus.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <typeparam name="TMessage"></typeparam>
    public abstract class MessageHandler<TComponent, TMessage> :
        Component
        where TComponent : class, IComponent
        where TMessage : class
    {

        readonly IServiceBus<TComponent> bus;
        IDisposable subscription;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        public MessageHandler(
            IServiceBus<TComponent> bus)
        {
            Contract.Requires<ArgumentNullException>(bus != null);

            this.bus = bus;
        }

        public override void Start()
        {
            if (subscription != null)
            {
                subscription.Dispose();
                subscription = null;
            }

            subscription = bus.Subscribe<TMessage>(OnMessageHandler);
        }

        public override void Stop()
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
        void OnMessageHandler(IConsumeContext<TMessage> context)
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
