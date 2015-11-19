namespace Cogito.ServiceBus.Infrastructure
{

    /// <summary>
    /// Creates <see cref="Semaphore"/> instances.
    /// </summary>
    /// <typeparam name="TIdentity"></typeparam>
    public interface ISemaphoreFactory<TIdentity>
    {

        /// <summary>
        /// Creates a new <see cref="Semaphore"/>.
        /// </summary>
        /// <returns></returns>
        Semaphore<TIdentity> Create();

    }

}
