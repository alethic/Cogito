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
    public abstract class MessageConsumer<TIdentity, TMessage> :
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
        public MessageConsumer(
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

            subscription = bus.Subscribe<TMessage>(OnMessage);
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
        /// Implement this method to handle incoming messages.
        /// </summary>
        /// <param name="context"></param>
        protected abstract void OnMessage(IConsumeContext<TMessage> context);

    }

}
