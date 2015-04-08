using System;

namespace Cogito.ServiceBus
{

    public interface IRequestContext :
        IBusContext
    {

        /// <summary>
        /// Handles a response of a given type.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="handler"></param>
        /// <returns></returns>
        IRequestContext Handle<TResponse>(Action<TResponse> handler)
            where TResponse : class;

        /// <summary>
        /// Sets how long the caller should wait for a response.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IRequestContext SetTimeout(TimeSpan timeout);

        /// <summary>
        /// Sets how long the message should survive on the broker.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IRequestContext SetExpiration(TimeSpan timeout);

    }

    public interface IRequestContext<TRequest> :
        IRequestContext
        where TRequest : class
    {

        /// <summary>
        /// Handles a response of a given type.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="handler"></param>
        /// <returns></returns>
        new IRequestContext<TRequest> Handle<TResponse>(Action<TResponse> handler)
            where TResponse : class;

        /// <summary>
        /// Handles a fault.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        IRequestContext<TRequest> HandleFault(Action<IFault<TRequest>> handler);

        /// <summary>
        /// Handles a fault.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        IRequestContext<TRequest> HandleFault(Action<IConsumeContext<IFault<TRequest>>> handler);

        /// <summary>
        /// Sets how long the caller should wait for a response.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        new IRequestContext<TRequest> SetTimeout(TimeSpan timeout);

        /// <summary>
        /// Sets how long the message should survive on the broker.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        new IRequestContext<TRequest> SetExpiration(TimeSpan timeout);

    }

}
