using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cogito.ServiceBus.MassTransit
{

    /// <summary>
    /// MassTransit <see cref="IServiceBus"/> implementation.
    /// </summary>
    class ServiceBus :
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

        class Fault<T> :
            IFault<T>
            where T : class
        {

            readonly global::MassTransit.Fault<T> fault;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="fault"></param>
            public Fault(global::MassTransit.Fault<T> fault)
            {
                Contract.Requires<ArgumentNullException>(fault != null);

                this.fault = fault;
            }

            public string FaultType
            {
                get { return fault.FaultType; }
            }

            public System.Collections.Generic.List<string> Messages
            {
                get { return fault.Messages; }
            }

            public DateTime OccurredAt
            {
                get { return fault.OccurredAt; }
            }

            public System.Collections.Generic.List<string> StackTrace
            {
                get { return fault.StackTrace; }
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

            readonly ServiceBus bus;
            readonly global::MassTransit.IConsumeContext context;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="context"></param>
            public ConsumeContext(ServiceBus bus, global::MassTransit.IConsumeContext context)
                : base(context)
            {
                Contract.Requires<ArgumentNullException>(bus != null);
                Contract.Requires<ArgumentNullException>(context != null);

                this.bus = bus;
                this.context = context;
            }

            Uri FixResponseAddress(Uri uri)
            {
                Contract.Requires<ArgumentNullException>(uri != null);

                var b = new UriBuilder(uri);
                b.Host = context.InputAddress.Host;
                return b.Uri;
            }

            public IServiceBus Bus
            {
                get { return bus; }
            }

            public void Respond<T>(T message)
                where T : class
            {
                if (context.ResponseAddress != null)
                {
                    context.Bus.GetEndpoint(FixResponseAddress(context.ResponseAddress)).Send(message, _ =>
                    {
                        _.SetSourceAddress(context.Bus.Endpoint.Address.Uri);
                        _.SetRequestId(context.RequestId);
                    });
                }
                else
                {
                    context.Bus.Publish(message, _ =>
                    {
                        _.SetRequestId(context.RequestId);
                    });
                }
            }

            public void Respond<T>(T message, Action<ISendContext<T>> contextCallback)
                where T : class
            {
                if (context.ResponseAddress != null)
                {
                    context.Bus.GetEndpoint(FixResponseAddress(context.ResponseAddress)).Send(message, _ =>
                    {
                        _.SetSourceAddress(context.Bus.Endpoint.Address.Uri);
                        _.SetRequestId(context.RequestId);
                        contextCallback(new SendContext<T>(bus, _));
                    });
                }
                else
                {
                    context.Bus.Publish(message, _ =>
                    {
                        _.SetRequestId(context.RequestId);
                        contextCallback(new SendContext<T>(bus, _));
                    });
                }


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
            public ConsumeContext(ServiceBus bus, global::MassTransit.IConsumeContext<T> context)
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

        class FaultConsumeContext<T> :
            ConsumeContext,
            IConsumeContext<IFault<T>>
            where T : class
        {

            readonly global::MassTransit.IConsumeContext<global::MassTransit.Fault<T>> context;
            readonly IFault<T> fault;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="bus"></param>
            /// <param name="context"></param>
            public FaultConsumeContext(ServiceBus bus, global::MassTransit.IConsumeContext<global::MassTransit.Fault<T>> context)
                : base(bus, context)
            {
                Contract.Requires<ArgumentNullException>(bus != null);
                Contract.Requires<ArgumentNullException>(context != null);

                this.context = context;
                this.fault = new Fault<T>(context.Message);
            }

            public IFault<T> Message
            {
                get { return fault; }
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
            public PublishContext(ServiceBus bus, global::MassTransit.IPublishContext context)
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
            public PublishContext(ServiceBus bus, global::MassTransit.IPublishContext<T> context)
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

        abstract class RequestContext
        {

            readonly protected ServiceBus bus;
            readonly global::MassTransit.RequestResponse.Configurators.RequestConfigurator configurator;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="bus"></param>
            /// <param name="configurator"></param>
            public RequestContext(ServiceBus bus, global::MassTransit.RequestResponse.Configurators.RequestConfigurator configurator)
            {
                Contract.Requires<ArgumentNullException>(bus != null);
                Contract.Requires<ArgumentNullException>(configurator != null);

                this.bus = bus;
                this.configurator = configurator;
            }

            public IServiceBus Bus
            {
                get { return bus; }
            }

        }

        class RequestContext<T> :
            RequestContext,
            IRequestContext<T>
            where T : class
        {

            readonly global::MassTransit.RequestResponse.Configurators.InlineRequestConfigurator<T> configurator;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="bus"></param>
            /// <param name="configurator"></param>
            public RequestContext(ServiceBus bus, global::MassTransit.RequestResponse.Configurators.InlineRequestConfigurator<T> configurator)
                : base(bus, configurator)
            {
                Contract.Requires<ArgumentNullException>(bus != null);
                Contract.Requires<ArgumentNullException>(configurator != null);

                this.configurator = configurator;
            }

            public IRequestContext<T> Handle<TResponse>(Action<TResponse> handler)
                where TResponse : class
            {
                configurator.Handle<TResponse>(handler);
                return this;
            }

            public IRequestContext<T> HandleFault(Action<IFault<T>> cb)
            {
                configurator.HandleFault(_ => new Fault<T>(_));
                return this;
            }

            public IRequestContext<T> HandleFault(Action<IConsumeContext<IFault<T>>> handler)
            {
                configurator.HandleFault((c, f) => handler(new FaultConsumeContext<T>(bus, c)));
                return this;
            }

            public IRequestContext<T> SetTimeout(TimeSpan timeout)
            {
                configurator.SetTimeout(timeout);
                return this;
            }

            public IRequestContext<T> SetExpiration(TimeSpan timeout)
            {
                configurator.SetRequestExpiration(timeout);
                return this;
            }

            IRequestContext IRequestContext.Handle<TResponse>(Action<TResponse> handler)
            {
                return Handle(handler);
            }

            IRequestContext IRequestContext.SetTimeout(TimeSpan timeout)
            {
                return SetTimeout(timeout);
            }

            IRequestContext IRequestContext.SetExpiration(TimeSpan timeout)
            {
                return SetExpiration(timeout);
            }

        }

        readonly object sync = new object();
        readonly Lazy<global::MassTransit.IServiceBus> bus;
        readonly Uri uri;
        bool disposed;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        public ServiceBus(Lazy<global::MassTransit.IServiceBus> bus, Uri uri)
        {
            Contract.Requires<ArgumentNullException>(bus != null);
            Contract.Requires<ArgumentNullException>(uri != null);

            this.bus = bus;
            this.uri = uri;
        }

        /// <summary>
        /// Gets the wrapped MassTransit bus instance.
        /// </summary>
        public global::MassTransit.IServiceBus OriginalBus
        {
            get { return bus.Value; }
        }

        public Uri Uri
        {
            get { return uri; }
        }

        public IDisposable Subscribe<T>(Action<T> handler)
            where T : class
        {
            lock (sync)
                return new Subscription(global::MassTransit.HandlerSubscriptionExtensions.SubscribeHandler<T>(bus.Value, handler));
        }

        public IDisposable Subscribe<T>(Action<T> handler, Expression<Func<T, bool>> predicate)
            where T : class
        {
            var c = predicate.Compile();

            lock (sync)
                return new Subscription(global::MassTransit.HandlerSubscriptionExtensions.SubscribeHandler<T>(bus.Value, handler, _ => c(_)));
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
            bus.Value.Publish<T>(values, _ => contextCallback(new PublishContext<T>(this, _)));
        }

        public virtual void Publish<T>(object values)
            where T : class
        {
            bus.Value.Publish<T>(values);
        }

        public virtual void Publish(object message, Type messageType, Action<IPublishContext> contextCallback)
        {
            bus.Value.Publish(message, messageType, _ => contextCallback(new PublishContext(this, _)));
        }

        public virtual void Publish(object message, Type messageType)
        {
            bus.Value.Publish(message, messageType);
        }

        public virtual void Publish(object message)
        {
            bus.Value.Publish(message);
        }

        public virtual void Publish<T>(T message, Action<IPublishContext<T>> contextCallback)
            where T : class
        {
            bus.Value.Publish<T>(message, _ => contextCallback(new PublishContext<T>(this, _)));
        }

        public virtual void Publish<T>(T message)
            where T : class
        {
            bus.Value.Publish<T>(message);
        }

        public virtual void Request<T>(T message, Action<IRequestContext<T>> contextCallback)
            where T : class
        {
            Task.Run(() => global::MassTransit.RequestResponseExtensions.PublishRequest<T>(bus.Value, message, _ => contextCallback(new RequestContext<T>(this, _)))).Wait();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (bus.IsValueCreated)
                    bus.Value.Dispose();
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

    class ServiceBus<T> :
        ServiceBus,
        IServiceBus<T>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="uri"></param>
        public ServiceBus(Lazy<global::MassTransit.IServiceBus> bus, Uri uri)
            : base(bus, uri)
        {
            Contract.Requires<ArgumentNullException>(bus != null);
            Contract.Requires<ArgumentNullException>(uri != null);
        }

    }

}
