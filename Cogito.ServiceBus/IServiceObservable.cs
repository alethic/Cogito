using System;

namespace Cogito.ServiceBus
{

    public interface IServiceObservable<TService, TMessage> :
        IObservable<TMessage>
        where TMessage : class
    {



    }

}
