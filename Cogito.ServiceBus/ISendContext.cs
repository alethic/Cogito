using System;

namespace Cogito.ServiceBus
{

    public interface ISendContext :
        IBusContext,
        IMessageContext
    {

        ISendContext SetExpirationTime(DateTime value);

        ISendContext SetHeader(string key, string value);

        ISendContext SetMessageType(string messageType);

        ISendContext SetRetryCount(int retryCount);

    }

    public interface ISendContext<T> :
        ISendContext,
        IMessageContext<T>
    {

        new ISendContext<T> SetExpirationTime(DateTime value);

        new ISendContext<T> SetHeader(string key, string value);

        new ISendContext<T> SetMessageType(string messageType);

        new ISendContext<T> SetRetryCount(int retryCount);

    }

}
