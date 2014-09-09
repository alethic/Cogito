using System;
namespace Cogito.ServiceBus
{

    public interface IServiceBus
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

    public interface IServiceBus<TService> :
        IServiceBus
    {

        IServiceBus Global { get; }

    }

}
