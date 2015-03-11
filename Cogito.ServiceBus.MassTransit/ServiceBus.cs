using System;
using System.Diagnostics.Contracts;

namespace Cogito.ServiceBus.MassTransit
{

    /// <summary>
    /// MassTransit <see cref="IServiceBus"/> implementation.
    /// </summary>
    public class ServiceBus :
        IServiceBus,
        IDisposable
    {

        /// <summary>
        /// Encapsulates a subscription.
        /// </summary>
        class Subscription :
            IDisposable
        {

            readonly global::MassTransit.UnsubscribeAction action;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="action"></param>
            public Subscription(global::MassTransit.UnsubscribeAction action)
            {
                Contract.Requires<ArgumentNullException>(action != null);

                this.action = action;
            }

            public void Dispose()
            {
                action();
            }

        }

        class MessageContext :
            IMessageContext
        {


            readonly global::MassTransit.IMessageContext context;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="context"></param>
            public MessageContext(global::MassTransit.IMessageContext context)
            {
                Contract.Requires<ArgumentNullException>(context != null);

                this.context = context;
            }

            public string ContentType
            {
                get { return context.ContentType; }
            }

            public DateTime? ExpirationTime
            {
                get { return context.ExpirationTime; }
            }

        }

        class MessageContext<T> :
            MessageContext,
            IMessageContext<T>
            where T : class
        {


            readonly global::MassTransit.IMessageContext<T> context;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="context"></param>
            public MessageContext(global::MassTransit.IMessageContext<T> context)
                : base(context)
            {
                Contract.Requires<ArgumentNullException>(context != null);

                this.context = context;
            }

            public T Message
            {
                get { return context.Message; }
            }

        }

        class SendContext :
            MessageContext,
            ISendContext
        {


            readonly IServiceBus bus;
            readonly global::MassTransit.ISendContext context;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="bus"></param>
            /// <param name="context"></param>
            public SendContext(ServiceBus bus, global::MassTransit.ISendContext context)
                : base(context)
            {
                Contract.Requires<ArgumentNullException>(bus != null);
                Contract.Requires<ArgumentNullException>(context != null);

                this.bus = bus;
                this.context = context;
            }

            public IServiceBus Bus
            {
                get { return bus; }
            }

            public ISendContext SetExpirationTime(DateTime value)
            {
                context.SetExpirationTime(value);
                return this;
            }

            public ISendContext SetHeader(string key, string value)
            {
                context.SetHeader(key, value);
                return this;
            }

            public ISendContext SetMessageType(string messageType)
            {
                context.SetMessageType(messageType);
                return this;
            }

            public ISendContext SetRetryCount(int retryCount)
            {
                context.SetRetryCount(retryCount);
                return this;
            }

        }

        class SendContext<T> :
            MessageContext<T>,
            ISendContext<T>
            where T : class
        {


            readonly IServiceBus bus;
            readonly global::MassTransit.ISendContext<T> context;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="bus"></param>
            /// <param name="context"></param>
            public SendContext(IServiceBus bus, global::MassTransit.ISendContext<T> context)
                : base(context)
            {
                Contract.Requires<ArgumentNullException>(bus != null);
                Contract.Requires<ArgumentNullException>(context != null);

                this.bus = bus;
                this.context = context;
            }

            public IServiceBus Bus
            {
                get { return bus; }
            }

            public ISendContext<T> SetExpirationTime(DateTime value)
            {
                context.SetExpirationTime(value);
                return this;
            }

            public ISendContext<T> SetHeader(string key, string value)
            {
                context.SetHeader(key, value);
                return this;
            }

            public ISendContext<T> SetMessageType(string messageType)
            {
                context.SetMessageType(messageType);
                return this;
            }

            public ISendContext<T> SetRetryCount(int retryCount)
            {
                context.SetRetryCount(retryCount);
                return this;
            }

            ISendContext ISendContext.SetExpirationTime(DateTime value)
            {
                return SetExpirationTime(value);
            }

            ISendContext ISendContext.SetHeader(string key, string value)
            {
                return SetHeader(key, value);
            }

            ISendContext ISendContext.SetMessageType(string messageType)
            {
                return SetMessageType(messageType);
            }

            ISendContext ISendContext.SetRetryCount(int retryCount)
            {
                return SetRetryCount(retryCount);
            }

        }

        class ConsumeContext :
            MessageContext,
            IConsumeContext
        {

            readonly IServiceBus bus;
            readonly global::MassTransit.IConsumeContext context;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="context"></param>
            public ConsumeContext(IServiceBus bus, global::MassTransit.IConsumeContext context)
                : base(context)
            {
                Contract.Requires<ArgumentNullException>(bus != null);
                Contract.Requires<ArgumentNullException>(context != null);

                this.bus = bus;
                this.context = context;
            }

            public IServiceBus Bus
            {
                get { return bus; }
            }

            public void Respond<T>(T message, Action<ISendContext<T>> contextCallback)
                where T : class
            {
                context.Respond<T>(message, _ => contextCallback(new SendContext<T>(bus, _)));
            }

        }

        class ConsumeContext<T> :
            ConsumeContext,
            IConsumeContext<T>
            where T : class
        {

            readonly global::MassTransit.IConsumeContext<T> context;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="bus"></param>
            /// <param name="context"></param>
            public ConsumeContext(IServiceBus bus, global::MassTransit.IConsumeContext<T> context)
                : base(bus, context)
            {
                Contract.Requires<ArgumentNullException>(bus != null);
                Contract.Requires<ArgumentNullException>(context != null);

                this.context = context;
            }

            public T Message
            {
                get { return context.Message; }
            }

        }

        class PublishContext :
            IPublishContext
        {

            readonly IServiceBus bus;
            readonly global::MassTransit.IPublishContext context;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="bus"></param>
            /// <param name="context"></param>
            public PublishContext(IServiceBus bus, global::MassTransit.IPublishContext context)
            {
                Contract.Requires<ArgumentNullException>(bus != null);
                Contract.Requires<ArgumentNullException>(context != null);

                this.bus = bus;
                this.context = context;
            }

            public IServiceBus Bus
            {
                get { return bus; }
            }

            public IPublishContext SetExpirationTime(DateTime value)
            {
                context.SetExpirationTime(value);
                return this;
            }

            public IPublishContext SetHeader(string key, string value)
            {
                context.SetHeader(key, value);
                return this;
            }

            public IPublishContext SetMessageType(string messageType)
            {
                context.SetMessageType(messageType);
                return this;
            }

            public IPublishContext SetRetryCount(int retryCount)
            {
                context.SetRetryCount(retryCount);
                return this;
            }

            public string ContentType
            {
                get { return context.ContentType; }
            }

            public DateTime? ExpirationTime
            {
                get { return context.ExpirationTime; }
            }

            ISendContext ISendContext.SetExpirationTime(DateTime value)
            {
                return SetExpirationTime(value);
            }

            ISendContext ISendContext.SetHeader(string key, string value)
            {
                return SetHeader(key, value);
            }

            ISendContext ISendContext.SetMessageType(string messageType)
            {
                return SetMessageType(messageType);
            }

            ISendContext ISendContext.SetRetryCount(int retryCount)
            {
                return SetRetryCount(retryCount);
            }

        }

        class PublishContext<T> :
            PublishContext,
            IPublishContext<T>
            where T : class
        {

            readonly global::MassTransit.IPublishContext<T> context;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="bus"></param>
            /// <param name="context"></param>
            public PublishContext(IServiceBus bus, global::MassTransit.IPublishContext<T> context)
                : base(bus, context)
            {
                Contract.Requires<ArgumentNullException>(bus != null);
                Contract.Requires<ArgumentNullException>(context != null);

                this.context = context;
            }

            public T Message
            {
                get { return context.Message; }
            }

            public new IPublishContext<T> SetExpirationTime(DateTime value)
            {
                base.SetExpirationTime(value);
                return this;
            }

            public new IPublishContext<T> SetHeader(string key, string value)
            {
                base.SetHeader(key, value);
                return this;
            }

            public new IPublishContext<T> SetMessageType(string messageType)
            {
                base.SetMessageType(messageType);
                return this;
            }

            public new IPublishContext<T> SetRetryCount(int retryCount)
            {
                base.SetRetryCount(retryCount);
                return this;
            }

            ISendContext ISendContext.SetExpirationTime(DateTime value)
            {
                return SetExpirationTime(value);
            }

            ISendContext ISendContext.SetHeader(string key, string value)
            {
                return SetHeader(key, value);
            }

            ISendContext ISendContext.SetMessageType(string messageType)
            {
                return SetMessageType(messageType);
            }

            ISendContext ISendContext.SetRetryCount(int retryCount)
            {
                return SetRetryCount(retryCount);
            }

            ISendContext<T> ISendContext<T>.SetExpirationTime(DateTime value)
            {
                return SetExpirationTime(value);
            }

            ISendContext<T> ISendContext<T>.SetHeader(string key, string value)
            {
                return SetHeader(key, value);
            }

            ISendContext<T> ISendContext<T>.SetMessageType(string messageType)
            {
                return SetMessageType(messageType);
            }

            ISendContext<T> ISendContext<T>.SetRetryCount(int retryCount)
            {
                return SetRetryCount(retryCount);
            }

        }

        readonly object sync = new object();
        Lazy<global::MassTransit.IServiceBus> bus;
        bool disposed;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        internal ServiceBus(Lazy<global::MassTransit.IServiceBus> bus)
        {
            Contract.Requires<ArgumentNullException>(bus != null);

            this.bus = bus;
        }

        public IDisposable Subscribe<T>(Action<T> handler)
            where T : class
        {
            lock (sync)
                return new Subscription(global::MassTransit.HandlerSubscriptionExtensions.SubscribeHandler<T>(bus.Value, handler));
        }

        public IDisposable Subscribe<T>(Action<T> handler, Predicate<T> condition)
            where T : class
        {
            lock (sync)
                return new Subscription(global::MassTransit.HandlerSubscriptionExtensions.SubscribeHandler<T>(bus.Value, handler, condition));
        }

        public IDisposable Subscribe<T>(Action<IConsumeContext<T>> handler)
            where T : class
        {
            lock (sync)
                return new Subscription(global::MassTransit.HandlerSubscriptionExtensions.SubscribeContextHandler<T>(bus.Value, _ => handler(new ConsumeContext<T>(this, _))));
        }

        public virtual void Publish<T>(object values, Action<IPublishContext<T>> contextCallback)
            where T : class
        {
            lock (sync)
                bus.Value.Publish<T>(values, _ => contextCallback(new PublishContext<T>(this, _)));
        }

        public virtual void Publish<T>(object values)
            where T : class
        {
            lock (sync)
                bus.Value.Publish<T>(values);
        }

        public virtual void Publish(object message, Type messageType, Action<IPublishContext> contextCallback)
        {
            lock (sync)
                bus.Value.Publish(message, messageType, _ => contextCallback(new PublishContext(this, _)));
        }

        public virtual void Publish(object message, Type messageType)
        {
            lock (sync)
                bus.Value.Publish(message, messageType);
        }

        public virtual void Publish(object message)
        {
            lock (sync)
                bus.Value.Publish(message);
        }

        public virtual void Publish<T>(T message, Action<IPublishContext<T>> contextCallback)
            where T : class
        {
            lock (sync)
                bus.Value.Publish<T>(message, _ => contextCallback(new PublishContext<T>(this, _)));
        }

        public virtual void Publish<T>(T message)
            where T : class
        {
            lock (sync)
                bus.Value.Publish<T>(message);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (bus != null)
                {
                    if (bus.IsValueCreated)
                        bus.Value.Dispose();

                    bus = null;
                }
            }

            disposed = true;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ServiceBus()
        {
            Dispose(false);
        }

    }

    public class ServiceBus<T> :
        ServiceBus,
        IServiceBus<T>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        public ServiceBus(Lazy<global::MassTransit.IServiceBus> bus)
            : base(bus)
        {
            Contract.Requires<ArgumentNullException>(bus != null);
        }

    }

}
