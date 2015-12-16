using System.Runtime.Serialization;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Describes a serialized object type.
    /// </summary>
    [DataContract]
    public class ActivityActorSerializedObject
    {

        [DataMember]
        public string Data { get; set; }

    }

}
