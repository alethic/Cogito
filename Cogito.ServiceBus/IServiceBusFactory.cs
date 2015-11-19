namespace Cogito.ServiceBus
{

    /// <summary>
    /// Gets instances of a service bus.
    /// </summary>
    public interface IServiceBusFactory
    {

        /// <summary>
        /// Creates a global bus instance.
        /// </summary>
        /// <returns></returns>
        IServiceBus CreateBus();

    }

    /// <summary>
    /// Gets instances of a scoped sevice bus.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    public interface IServiceBusFactory<TScope>
    {

        /// <summary>
        /// Creates a scoped bus instance.
        /// </summary>
        /// <returns></returns>
        IServiceBus<TScope> CreateBus();

    }

}
