using System;
using System.Activities.DurableInstancing;
using System.Activities.Hosting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.DurableInstancing;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;

using Cogito.Collections;
using Cogito.Threading;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Provides a Durable Instancing store for saving objects into a <see cref="ActivityActorState"/>.
    /// </summary>
    class ActivityActorInstanceStore<TState> :
        InstanceStore
    {

        readonly ActivityActorBase<TState> actor;
        readonly ActivityActorState actorState;
        readonly NetDataContractSerializer serializer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="activityState"></param>
        internal ActivityActorInstanceStore(ActivityActorBase<TState> actor)
        {
            Contract.Requires<ArgumentNullException>(actor != null);

            this.actor = actor;
            this.actorState = actor.ActivityStateInternal;
            this.serializer = new NetDataContractSerializer();

            // initialize activity state
            if (actorState.InstanceData == null)
                actorState.InstanceData = new Dictionary<Guid, Dictionary<XName, object>>();

            // initialize activity state
            if (actorState.InstanceMetadata == null)
                actorState.InstanceMetadata = new Dictionary<Guid, Dictionary<XName, object>>();
        }

        /// <summary>
        /// Attempts to execute the given command against the <see cref="InstanceStore"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        protected override bool TryCommand(InstancePersistenceContext context, InstancePersistenceCommand command, TimeSpan timeout)
        {
            return EndTryCommand(BeginTryCommand(context, command, timeout, null, null));
        }

        /// <summary>
        /// Begins an attempt to execute the given command against the <see cref="InstanceStore"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        /// <param name="timeout"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected override IAsyncResult BeginTryCommand(InstancePersistenceContext context, InstancePersistenceCommand command, TimeSpan timeout, AsyncCallback callback, object state)
        {
            if (command is CreateWorkflowOwnerCommand)
            {
                CreateWorkflowOwnerCommand(context, (CreateWorkflowOwnerCommand)command);
            }
            else if (command is SaveWorkflowCommand)
            {
                SaveWorkflowCommand(context, (SaveWorkflowCommand)command);

            }
            else if (command is LoadWorkflowCommand)
            {
                LoadWorkflowCommand(context, (LoadWorkflowCommand)command);
            }
            else if (command is DeleteWorkflowOwnerCommand)
            {
                DeleteWorkflowOwnerCommand(context, (DeleteWorkflowOwnerCommand)command);
            }

            return new CompletedAsyncResult<bool>(true, callback, state);
        }

        /// <summary>
        /// Ends an attempt to execute the given <see cref="InstancePersistenceCommand"/> against the <see cref="InstanceStore"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected override bool EndTryCommand(IAsyncResult result)
        {
            return CompletedAsyncResult<bool>.End(result);
        }

        #region Commands

        /// <summary>
        /// Handles a <see cref="CreateWorkflowOwnerCommand"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        void CreateWorkflowOwnerCommand(InstancePersistenceContext context, CreateWorkflowOwnerCommand command)
        {
            context.BindInstanceOwner((Guid)actorState.InstanceOwnerId, Guid.NewGuid());
        }

        /// <summary>
        /// Handles a <see cref="SaveWorkflowCommand"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        void SaveWorkflowCommand(InstancePersistenceContext context, SaveWorkflowCommand command)
        {
            // save the instance data
            SaveInstanceData(context.InstanceView.InstanceId, command.InstanceData);
            SaveInstanceMetadata(context.InstanceView.InstanceId, command.InstanceMetadataChanges);

            // clear instance data when complete
            if (command.CompleteInstance)
                actorState.InstanceData.Remove(context.InstanceView.InstanceId);
        }

        /// <summary>
        /// Handles a <see cref="LoadWorkflowCommand"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        void LoadWorkflowCommand(InstancePersistenceContext context, LoadWorkflowCommand command)
        {
            context.LoadedInstance(
                InstanceState.Initialized,
                LoadInstanceData(context.InstanceView.InstanceId),
                LoadInstanceMetadata(context.InstanceView.InstanceId),
                null,
                null);
        }

        /// <summary>
        /// Handles a <see cref="DeleteWorkflowOwnerCommand"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        void DeleteWorkflowOwnerCommand(InstancePersistenceContext context, DeleteWorkflowOwnerCommand command)
        {

        }

        #endregion

        #region Serialization

        /// <summary>
        /// Loads the instance data for the given instance ID.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        IDictionary<XName, InstanceValue> LoadInstanceData(Guid instanceId)
        {
            var data = actorState.InstanceData.GetOrDefault(instanceId);
            if (data == null)
                return new Dictionary<XName, InstanceValue>();

            return data
                .ToDictionary(i => i.Key, i => new InstanceValue(FromSerializableObject(i.Value)));
        }

        /// <summary>
        /// Lodas the instance metadata for the given instance ID.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        IDictionary<XName, InstanceValue> LoadInstanceMetadata(Guid instanceId)
        {
            var metadata = actorState.InstanceMetadata.GetOrDefault(instanceId);
            if (metadata == null)
                return new Dictionary<XName, InstanceValue>();

            return metadata
                .ToDictionary(i => i.Key, i => new InstanceValue(FromSerializableObject(i.Value)));
        }

        /// <summary>
        /// Saves the instance data for the given instance ID.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="data"></param>
        void SaveInstanceData(Guid instanceId, IDictionary<XName, InstanceValue> data)
        {
            Contract.Requires<ArgumentNullException>(data != null);

            actorState.InstanceData[instanceId] = data
                .ToDictionary(i => i.Key, i => ToSerializableObject(i.Value.Value));
        }

        /// <summary>
        /// Saves the instance metadata for the given instance ID.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="metadata"></param>
        void SaveInstanceMetadata(Guid instanceId, IDictionary<XName, InstanceValue> metadata)
        {
            Contract.Requires<ArgumentNullException>(metadata != null);

            actorState.InstanceMetadata[instanceId] = metadata
                .ToDictionary(i => i.Key, i => ToSerializableObject(i.Value.Value));
        }

        /// <summary>
        /// Returns an <see cref="ActorInstanceValue"/> for the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object ToSerializableObject(object value)
        {
            if (value.GetType().IsPrimitive)
                return value;
            else if (value.GetType().IsGenericType &&
                value.GetType().GetGenericTypeDefinition() == typeof(Nullable<>) &&
                Nullable.GetUnderlyingType(value.GetType()).IsPrimitive)
                return value;
            else if (value is string)
                return value;
            else if (value.GetType().IsEnum)
                return value;
            else if (value is DateTime? || value is DateTime)
                return value;
            else if (value is DateTimeOffset? || value is DateTimeOffset)
                return value;
            else if (value is TimeSpan? || value is TimeSpan)
                return value;
            else if (value is Guid? || value is Guid)
                return value;
            else if (value is Uri)
                return value;
            else if (value is byte[])
                return value;
            else if (value is XmlQualifiedName)
                return value;
            else if (value is XName)
                return value;
            else if (value is ReadOnlyCollection<BookmarkInfo>)
                return value;
            else
                return new ActivityActorSerializedObject() { Data = SerializeObject(value).ToString() };
        }

        /// <summary>
        /// Serializes the given object to a <see cref="XElement"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        XElement SerializeObject(object value)
        {
            Contract.Requires<ArgumentNullException>(value != null);

            // serialize to stream
            var stream = new MemoryStream();
            serializer.Serialize(stream, value);
            stream.Position = 0;

            // parse serialized contents into new element
            return XElement.Load(stream);
        }

        /// <summary>
        /// Returns an instance value from a <see cref="ActorInstanceValue"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object FromSerializableObject(object value)
        {
            if (value is ActivityActorSerializedObject)
                return DeserializeObject(XElement.Parse(((ActivityActorSerializedObject)value).Data));
            else
                return value;
        }

        /// <summary>
        /// Deserializes the given object.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        object DeserializeObject(XElement element)
        {
            Contract.Requires<ArgumentNullException>(element != null);

            var stream = new MemoryStream();
            element.Save(stream);
            stream.Position = 0;

            return serializer.Deserialize(stream);
        }

        #endregion

    }
}
