﻿using System;
using System.Activities.Hosting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Describes the state persisted along with the actor.
    /// </summary>
    [DataContract]
    [KnownType(typeof(XName))]
    [KnownType(typeof(ActivityActorSerializedObject))]
    [KnownType(typeof(ReadOnlyCollection<BookmarkInfo>))]
    public class ActivityActorState
    {

        /// <summary>
        /// Owner ID of this <see cref="ActivityActor{TActivity, TState}"/>.
        /// </summary>
        [DataMember]
        public Guid InstanceOwnerId { get; set; }

        /// <summary>
        /// State of the <see cref="ActivityActor{TActivity, TState}"/>.
        /// </summary>
        [DataMember]
        public ActivityActorStatus Status { get; set; }

        /// <summary>
        /// Instance ID of the workflow associated with the <see cref="ActivityActor{TActivity, TState}"/>.
        /// </summary>
        [DataMember]
        public Guid InstanceId { get; set; }

        /// <summary>
        /// Set of outstanding bookmarks.
        /// </summary>
        [DataMember]
        public string[] Bookmarks { get; set; }

        /// <summary>
        /// Backend storage for an <see cref="ActivityActorInstanceStore"/>.
        /// </summary>
        [DataMember]
        public Dictionary<Guid, Dictionary<XName, object>> InstanceData { get; set; }

        /// <summary>
        /// Backend storage for an <see cref="ActivityActorInstanceStore"/>.
        /// </summary>
        [DataMember]
        public Dictionary<Guid, Dictionary<XName, object>> InstanceMetadata { get; set; }

    }

    /// <summary>
    /// Describes the state persisted along with the actor.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    [DataContract]
    public class ActivityActorState<TState> :
        ActivityActorState
    {

        /// <summary>
        /// Gets the user-defined state.
        /// </summary>
        [DataMember]
        public TState State { get; set; }

    }

}
