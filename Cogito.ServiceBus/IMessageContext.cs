using System;

namespace Cogito.ServiceBus
{

    public interface IMessageContext
    {

        string ContentType { get; }

        DateTime? ExpirationTime { get; }

    }

    public interface IMessageContext<T> :
        IMessageContext
    {

        T Message { get; }

    }

}
