using System;

namespace Cogito.ServiceBus
{

    public interface IServiceContextObservable<TService, TMessage> :
        IObservable<IConsumeContext<TMessage>>
        where TMessage : class
    {



    }

}
