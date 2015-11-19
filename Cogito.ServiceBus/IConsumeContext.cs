using System;

namespace Cogito.ServiceBus
{

    public interface IConsumeContext :
        IBusContext,
        IMessageContext
    {

        void Respond<T>(T message)
            where T : class;

        void Respond<T>(T message, Action<ISendContext<T>> contextCallback)
            where T : class;

    }

    public interface IConsumeContext<T> :
        IConsumeContext,
        IMessageContext<T>
        where T : class
    {



    }

}
