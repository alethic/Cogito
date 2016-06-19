using System;
using System.Activities.DurableInstancing;
using System.Activities.Hosting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.DurableInstancing;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using Cogito.Threading;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Provides a Durable Instancing store for saving objects into a <see cref="ActivityActorStateManager"/>.
    /// </summary>
    public class ActivityActorInstanceStore :
        InstanceStore
    {

        readonly ActivityActorStateManager state;
        readonly NetDataContractSerializer serializer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="actor"></param>
        public ActivityActorInstanceStore(ActivityActorStateManager state)
        {
            Contract.Requires<ArgumentNullException>(state != null);

            this.state = state;
            this.serializer = new NetDataContractSerializer();
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
                return CreateWorkflowOwnerCommand(context, (CreateWorkflowOwnerCommand)command).BeginToAsync(callback, state);
            }
            else if (command is QueryActivatableWorkflowsCommand)
            {
                return QueryActivatableWorkflowsCommand(context, (QueryActivatableWorkflowsCommand)command).BeginToAsync(callback, state);
            }
            else if (command is SaveWorkflowCommand)
            {
                return SaveWorkflowCommand(context, (SaveWorkflowCommand)command).BeginToAsync(callback, state);
            }
            else if (command is LoadWorkflowCommand)
            {
                return LoadWorkflowCommand(context, (LoadWorkflowCommand)command).BeginToAsync(callback, state);
            }
            else if (command is TryLoadRunnableWorkflowCommand)
            {
                return TryLoadRunnableWorkflowCommand(context, (TryLoadRunnableWorkflowCommand)command).BeginToAsync(callback, state);
            }
            else if (command is DeleteWorkflowOwnerCommand)
            {
                return DeleteWorkflowOwnerCommand(context, (DeleteWorkflowOwnerCommand)command).BeginToAsync(callback, state);
            }
            else
            {
                return Task.FromResult(true).BeginToAsync(callback, state);
            }
        }

        /// <summary>
        /// Ends an attempt to execute the given <see cref="InstancePersistenceCommand"/> against the <see cref="InstanceStore"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected override bool EndTryCommand(IAsyncResult result)
        {
            return ((Task<bool>)result).EndToAsync();
        }

        #region Commands

        /// <summary>
        /// Handles a <see cref="CreateWorkflowOwnerCommand"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        async Task<bool> CreateWorkflowOwnerCommand(InstancePersistenceContext context, CreateWorkflowOwnerCommand command)
        {
            context.BindInstanceOwner(await state.GetInstanceOwnerId(), Guid.NewGuid());
            return true;
        }

        /// <summary>
        /// Handles a <see cref="QueryActivatableWorkflowsCommand"/>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        async Task<bool> QueryActivatableWorkflowsCommand(InstancePersistenceContext context, QueryActivatableWorkflowsCommand command)
        {
            return false;
        }

        /// <summary>
        /// Handles a <see cref="SaveWorkflowCommand"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        async Task<bool> SaveWorkflowCommand(InstancePersistenceContext context, SaveWorkflowCommand command)
        {
            // save the instance data
            await state.SetInstanceState(InstanceState.Initialized);
            await SaveInstanceData(context.InstanceView.InstanceId, command.InstanceData);
            await SaveInstanceMetadata(context.InstanceView.InstanceId, command.InstanceMetadataChanges);

            // clear instance data when complete
            if (command.CompleteInstance)
            {
                await state.SetInstanceState(InstanceState.Completed);
                await state.ClearInstanceData();
                await state.ClearInstanceMetadata();
            }

            // signal that we have been saved
            await state.OnPersisted();

            return true;
        }

        /// <summary>
        /// Handles a <see cref="LoadWorkflowCommand"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        async Task<bool> LoadWorkflowCommand(InstancePersistenceContext context, LoadWorkflowCommand command)
        {
            if (await state.GetInstanceState() != InstanceState.Completed)
            {
                context.LoadedInstance(
                    InstanceState.Initialized,
                    await LoadInstanceData(context.InstanceView.InstanceId),
                    await LoadInstanceMetadata(context.InstanceView.InstanceId),
                    null,
                    null);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Handles a <see cref="TryLoadRunnableWorkflowCommand"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        async Task<bool> TryLoadRunnableWorkflowCommand(InstancePersistenceContext context, TryLoadRunnableWorkflowCommand command)
        {
            return false;
        }

        /// <summary>
        /// Handles a <see cref="DeleteWorkflowOwnerCommand"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="command"></param>
        Task<bool> DeleteWorkflowOwnerCommand(InstancePersistenceContext context, DeleteWorkflowOwnerCommand command)
        {
            return Task.FromResult(true);
        }

        #endregion

        #region Serialization

        /// <summary>
        /// Loads the instance data for the given instance ID.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        async Task<IDictionary<XName, InstanceValue>> LoadInstanceData(Guid instanceId)
        {
            if (await state.GetInstanceId() != instanceId)
                throw new InvalidOperationException();

            return await (await state.GetInstanceDataItems())
                .ToDictionaryAsync(i => i, async i => new InstanceValue(FromSerializableObject(await state.GetInstanceData(i))));
        }

        /// <summary>
        /// Lodas the instance metadata for the given instance ID.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        async Task<IDictionary<XName, InstanceValue>> LoadInstanceMetadata(Guid instanceId)
        {
            if (await state.GetInstanceId() != instanceId)
                throw new InvalidOperationException();

            return await (await state.GetInstanceMetadataItems())
                .ToDictionaryAsync(i => i, async i => new InstanceValue(FromSerializableObject(await state.GetInstanceMetadata(i))));
        }

        /// <summary>
        /// Saves the instance data for the given instance ID.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="data"></param>
        async Task SaveInstanceData(Guid instanceId, IDictionary<XName, InstanceValue> data)
        {
            Contract.Requires<ArgumentNullException>(data != null);

            if (await state.GetInstanceId() != instanceId)
                throw new InvalidOperationException();

            foreach (var kvp in data)
                await state.SetInstanceData(kvp.Key, ToSerializableObject(kvp.Value.Value));
        }

        /// <summary>
        /// Saves the instance metadata for the given instance ID.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="metadata"></param>
        async Task SaveInstanceMetadata(Guid instanceId, IDictionary<XName, InstanceValue> metadata)
        {
            Contract.Requires<ArgumentNullException>(metadata != null);

            if (await state.GetInstanceId() != instanceId)
                throw new InvalidOperationException();

            foreach (var kvp in metadata)
                await state.SetInstanceMetadata(kvp.Key, ToSerializableObject(kvp.Value.Value));
        }

        /// <summary>
        /// Serializes the given serializable object.
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
                return new ActivityActorInstanceValueAsString() { Data = SerializeObject(value).ToString() };
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
        /// Deserializes the given serializable object.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object FromSerializableObject(object value)
        {
            if (value is ActivityActorInstanceValue)
                return ((ActivityActorInstanceValue)value).Value;
            else if (value is ActivityActorInstanceValueAsString)
                return DeserializeObject(XElement.Parse(((ActivityActorInstanceValueAsString)value).Data));
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
