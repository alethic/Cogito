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
    [KnownType(typeof(ActivityActorInstanceValueAsXml))]
    [KnownType(typeof(ReadOnlyCollection<BookmarkInfo>))]
    class ActivityActorState
    {

        [DataMember]
        public Guid InstanceOwnerId { get; set; }

        [DataMember]
        public Guid InstanceId { get; set; }

        [DataMember]
        public InstanceState InstanceState { get; set; }

        [DataMember]
        public IDictionary<XName, object> InstanceData { get; set; }

        [DataMember]
        public IDictionary<XName, object> InstanceMetadata { get; set; }

    }

}
