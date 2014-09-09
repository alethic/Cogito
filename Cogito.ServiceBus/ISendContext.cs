using System;

namespace Cogito.ServiceBus
{

    public interface ISendContext :
        IBusContext,
        IMessageContext
    {

        void SetExpirationTime(DateTime value);

        void SetHeader(string key, string value);

        void SetMessageType(string messageType);

    }

    public interface ISendContext<T> :
        ISendContext,
        IMessageContext<T>
    {



    }

}
