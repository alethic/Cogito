namespace Cogito.ServiceBus.Infrastructure
{

    /// <summary>
    /// Indicates the status of a semaphore node.
    /// </summary>
    public enum SemaphoreStatus
    {

        /// <summary>
        /// The semaphore node is looking to acquire a resource.
        /// </summary>
        Acquire = 1,

        /// <summary>
        /// The semaphore node is not looking to acquire a resource.
        /// </summary>
        Release = 2,

    }

}
