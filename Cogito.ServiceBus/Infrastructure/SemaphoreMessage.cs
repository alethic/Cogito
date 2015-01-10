using System;

namespace Cogito.ServiceBus.Infrastructure
{

    /// <summary>
    /// Broadcast message for maintaining the semaphore.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class SemaphoreMessage<T>
    {

        /// <summary>
        /// Unique identifier of the semaphore instance.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Message time.
        /// </summary>
        public DateTime Ping { get; set; }

        /// <summary>
        /// Sort order of the node instance.
        /// </summary>
        public DateTime Sort { get; set; }

        /// <summary>
        /// Current status of the semaphore node.
        /// </summary>
        public SemaphoreStatus Status { get; set; }

    }

}
