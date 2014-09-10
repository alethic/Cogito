namespace Cogito.ServiceBus
{

    public interface IPublishContext :
        ISendContext,
        IMessageContext
    {



    }

    public interface IPublishContext<T> :
        IPublishContext,
        IMessageContext<T>
        where T : class
    {



    }

}
