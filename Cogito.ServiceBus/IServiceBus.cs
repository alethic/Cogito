using System;

namespace Cogito.ServiceBus
{

    /// <summary>
    /// General service bus interface. Inject an instance of this type when you want to obtain the application
    /// specific service bus, for broadcast notifications.
    /// </summary>
    public interface IServiceBus :
        IDisposable
    {

        IDisposable Subscribe<T>(Action<T> handler)
            where T : class;

        IDisposable Subscribe<T>(Action<T> handler, Predicate<T> condition)
            where T : class;

        IDisposable Subscribe<T>(Action<IConsumeContext<T>> handler)
            where T : class;

        void Publish<T>(object values, Action<IPublishContext<T>> contextCallback)
            where T : class;

        void Publish<T>(object values)
            where T : class;

        void Publish(object message, Type messageType, Action<IPublishContext> contextCallback);

        void Publish(object message, Type messageType);

        void Publish(object message);

        void Publish<T>(T message, Action<IPublishContext<T>> contextCallback)
            where T : class;

        void Publish<T>(T message)
            where T : class;

    }

    /// <summary>
    /// Scope-specific service bus. Use this to listen to identified worker queues.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    public interface IServiceBus<TScope> :
        IServiceBus
    {



    }

}
