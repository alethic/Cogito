using System;
using System.Activities.Hosting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.DurableInstancing;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Cogito.ServiceFabric.Activities
{

    /// <summary>
    /// Serializable object that holds the activity state.
    /// </summary>
    [DataContract]
    [KnownType(typeof(XName))]
    [KnownType(typeof(ActivityActorInstanceValueAsString))]
    [KnownType(typeof(ReadOnlyCollection<BookmarkInfo>))]
    public class ActivityActorState
    {

        [DataMember]
        public Guid InstanceOwnerId { get; set; }

        [DataMember]
        public Guid InstanceId { get; set; }

        [DataMember]
        public InstanceState InstanceState { get; set; }

        [DataMember]
        public Dictionary<string, object> InstanceData { get; set; } =
            new Dictionary<string, object>();

        [DataMember]
        public Dictionary<string, object> InstanceMetadata { get; set; } =
            new Dictionary<string, object>();

    }

}
