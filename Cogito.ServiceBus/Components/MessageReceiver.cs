using System;
using System.Diagnostics.Contracts;

using Cogito.Components;

namespace Cogito.ServiceBus.Components
{

    /// <summary>
    /// Base class for a <see cref="IComponent"/> that consumes messages from a named service bus.
    /// </summary>
    /// <typeparam name="TIdentity"></typeparam>
    /// <typeparam name="TMessage"></typeparam>
    public abstract class MessageReceiver<TIdentity, TMessage> :
        Component
        where TIdentity : class, IComponent
        where TMessage : class
    {

        readonly IServiceBus<TIdentity> bus;
        IDisposable subscription;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        public MessageReceiver(
            IServiceBus<TIdentity> bus)
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

            subscription = bus.Subscribe<TMessage>(MessageHandler);
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
