using System;

namespace Cogito.ServiceBus
{

    public interface IRequestContext :
        IBusContext
    {

        IRequestContext Handle<TResponse>(Action<TResponse> handler)
            where TResponse : class;

        IRequestContext SetTimeout(TimeSpan timeout);

        IRequestContext SetExpiration(TimeSpan timeout);

    }

    public interface IRequestContext<TRequest> :
        IRequestContext
        where TRequest : class
    {

        new IRequestContext<TRequest> Handle<TResponse>(Action<TResponse> handler)
            where TResponse : class;

        IRequestContext<TRequest> HandleFault(Action<IFault<TRequest>> handler);

        IRequestContext<TRequest> HandleFault(Action<IConsumeContext<IFault<TRequest>>> handler);

        new IRequestContext<TRequest> SetTimeout(TimeSpan timeout);

        new IRequestContext<TRequest> SetExpiration(TimeSpan timeout);

    }

}
