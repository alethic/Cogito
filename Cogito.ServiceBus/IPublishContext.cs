using System;
namespace Cogito.ServiceBus
{

    public interface IPublishContext :
        ISendContext,
        IMessageContext
    {

        new IPublishContext SetExpirationTime(DateTime value);

        new IPublishContext SetHeader(string key, string value);

        new IPublishContext SetMessageType(string messageType);

        new IPublishContext SetRetryCount(int retryCount);

    }

    public interface IPublishContext<T> :
        IPublishContext,
        ISendContext<T>,
        IMessageContext<T>
        where T : class
    {

        new IPublishContext<T> SetExpirationTime(DateTime value);

        new IPublishContext<T> SetHeader(string key, string value);

        new IPublishContext<T> SetMessageType(string messageType);

        new IPublishContext<T> SetRetryCount(int retryCount);

    }

}
