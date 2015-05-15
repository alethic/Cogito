using System;
using System.Runtime.Serialization;

namespace Cogito.ServiceBus.MassTransit
{

    [DataContract]
    public class Envelope
    {

        [DataMember]
        public string ConversationId { get; set; }

        [DataMember]
        public string CorrelationId { get; set; }

        [DataMember]
        public string DestinationAddress { get; set; }

        [DataMember]
        public DateTime? ExpirationTime { get; set; }

        [DataMember]
        public string FaultAddress { get; set; }

        [DataMember]
        public EnvelopeHeaderDictionary Headers { get; set; }

        [DataMember]
        public object Message { get; set; }

        [DataMember]
        public string MessageId { get; set; }

        [DataMember]
        public EnvelopeMessageTypeList MessageType { get; set; }

        [DataMember]
        public string Network { get; set; }

        [DataMember]
        public string RequestId { get; set; }

        [DataMember]
        public string ResponseAddress { get; set; }

        [DataMember]
        public int RetryCount { get; set; }

        [DataMember]
        public string SourceAddress { get; set; }

    }

}
