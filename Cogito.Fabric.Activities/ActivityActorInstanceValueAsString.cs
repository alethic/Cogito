using System.Runtime.Serialization;

namespace Cogito.ServiceFabric.Activities
{

    /// <summary>
    /// Describes a serialized object type.
    /// </summary>
    [DataContract]
    class ActivityActorInstanceValueAsString
    {

        /// <summary>
        /// Serialized data as XML.
        /// </summary>
        [DataMember]
        public string Data { get; set; }

    }

}
