namespace Cogito.ServiceBus.Infrastructure
{

    /// <summary>
    /// Indicates the status of a semaphore node.
    /// </summary>
    public enum SemaphoreStatus
    {

        /// <summary>
        /// The semaphore node is available.
        /// </summary>
        Available = 1,

        /// <summary>
        /// The semaphore node is unavailable.
        /// </summary>
        Unavailable = 2,

    }

}
