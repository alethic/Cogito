using System.Runtime.Serialization;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Describes a serialized object type.
    /// </summary>
    [DataContract]
    public class ActivityActorInstanceValueAsString
    {

        /// <summary>
        /// Serialized data as XML.
        /// </summary>
        [DataMember]
        public string Data { get; set; }

    }

}
