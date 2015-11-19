using System;
using System.Runtime.Serialization;

namespace Cogito.ServiceBus.Infrastructure
{

    /// <summary>
    /// Broadcast message for maintaining the semaphore.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    [DataContract]
    public class SemaphoreMessage
    {

        /// <summary>
        /// Unique identifier of the semaphore.
        /// </summary>
        [DataMember]
        public string SemaphoreId { get; set; }

        /// <summary>
        /// Unique identifier of the semaphore instance.
        /// </summary>
        [DataMember]
        public Guid InstanceId { get; set; }

        /// <summary>
        /// Message time.
        /// </summary>
        [DataMember]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Time the node was activated.
        /// </summary>
        [DataMember]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Priority of the instance. Randomly selected by the instance.
        /// </summary>
        [DataMember]
        public int Priority { get; set; }

        /// <summary>
        /// Current status of the semaphore node.
        /// </summary>
        [DataMember]
        public SemaphoreStatus Status { get; set; }

    }

}
