using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.DurableInstancing;
using System.Threading.Tasks;
using System.Xml.Linq;

using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Manages access to a workflow's state with a <see cref="IActorStateManager"/>.
    /// </summary>
    public class ActivityActorStateManager
    {

        const string KEY_PREFIX = "Cogito.Fabric.Activities.ActivityActorState";

        /// <summary>
        /// Creates a key for storing objects in the state manager.
        /// </summary>
        /// <param name="objectName"></param>
        /// <returns></returns>
        static string FormatKey(string objectName)
        {
            Contract.Requires<ArgumentNullException>(objectName != null);

            return KEY_PREFIX + ":" + objectName;
        }


        readonly Lazy<IActorStateManager> state;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="stateFunc"></param>
        public ActivityActorStateManager(Func<IActorStateManager> stateFunc)
        {
            Contract.Requires<ArgumentNullException>(stateFunc != null);

            this.state = new Lazy<IActorStateManager>(stateFunc);
        }

        /// <summary>
        /// Gets the instance owner id.
        /// </summary>
        public async Task<Guid> GetInstanceOwnerId()
        {
            var item = await state.Value.TryGetStateAsync<Guid>(FormatKey("InstanceOwnerId"));
            return item.HasValue ? item.Value : Guid.Empty;
        }

        /// <summary>
        /// Sets the instance owner id.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task SetInstanceOwnerId(Guid value)
        {
            return state.Value.SetStateAsync(FormatKey("InstanceOwnerId"), value);
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        public async Task<InstanceState> GetInstanceState()
        {
            var item = await state.Value.TryGetStateAsync<InstanceState>(FormatKey("InstanceState"));
            return item.HasValue ? item.Value : default(InstanceState);
        }

        /// <summary>
        /// Sets the status.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task SetInstanceState(InstanceState value)
        {
            return state.Value.SetStateAsync(FormatKey("InstanceState"), value);
        }

        /// <summary>
        /// Gets the instance id.
        /// </summary>
        /// <returns></returns>
        public async Task<Guid> GetInstanceId()
        {
            var item = await state.Value.TryGetStateAsync<Guid>(FormatKey("InstanceId"));
            return item.HasValue ? item.Value : Guid.Empty;
        }

        /// <summary>
        /// Sets the instance id.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task SetInstanceId(Guid value)
        {
            return state.Value.SetStateAsync(FormatKey("InstanceId"), value);
        }

        /// <summary>
        /// Gets the instance data items.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<XName>> GetInstanceDataItems()
        {
            var prefix = FormatKey("InstanceData") + "::";

            return (await state.Value.GetStateNamesAsync())
                .Where(i => i.StartsWith(prefix))
                .Select(i => i.Substring(prefix.Length))
                .Select(i => XName.Get(i))
                .ToArray();
        }

        /// <summary>
        /// Gets the instance data with the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<object> GetInstanceData(XName key)
        {
            var item = await state.Value.TryGetStateAsync<ActivityActorInstanceValue>(FormatKey("InstanceData") + "::" + key);
            return item.HasValue ? item.Value.Value : null;
        }

        /// <summary>
        /// Gets the instance data with the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> GetInstanceData<T>(XName key)
        {
            return (T)await GetInstanceData(key);
        }

        /// <summary>
        /// Sets the instance data with the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task SetInstanceData(XName key, object value)
        {
            return state.Value.SetStateAsync(FormatKey("InstanceData") + "::" + key, new ActivityActorInstanceValue() { Value = value });
        }

        /// <summary>
        /// Clears all stored instance data.
        /// </summary>
        /// <returns></returns>
        public async Task ClearInstanceData()
        {
            foreach (var key in await GetInstanceDataItems())
                await state.Value.RemoveStateAsync(FormatKey("InstanceData") + "::" + key);
        }

        /// <summary>
        /// Gets the instance metadata items.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<XName>> GetInstanceMetadataItems()
        {
            var prefix = FormatKey("InstanceMetadata") + "::";

            return (await state.Value.GetStateNamesAsync())
                .Where(i => i.StartsWith(prefix))
                .Select(i => i.Substring(prefix.Length))
                .Select(i => XName.Get(i))
                .ToArray();
        }

        /// <summary>
        /// Gets the instance metadata with the specified key.
        /// </summary>
        /// <param name="key"></param>
        public async Task<object> GetInstanceMetadata(XName key)
        {
            var item = await state.Value.TryGetStateAsync<ActivityActorInstanceValue>(FormatKey("InstanceMetadata") + "::" + key);
            return item.HasValue ? item.Value.Value : null;
        }

        /// <summary>
        /// Gets the instance metadata with the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> GetInstanceMetadata<T>(XName key)
        {
            return (T)await GetInstanceMetadata(key);
        }

        /// <summary>
        /// Sets the instance data with the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task SetInstanceMetadata(XName key, object value)
        {
            return state.Value.SetStateAsync(FormatKey("InstanceMetadata") + "::" + key, new ActivityActorInstanceValue() { Value = value });
        }

        /// <summary>
        /// Clears all stored instance metadata.
        /// </summary>
        /// <returns></returns>
        public async Task ClearInstanceMetadata()
        {
            foreach (var key in await GetInstanceMetadataItems())
                await state.Value.RemoveStateAsync(FormatKey("InstanceMetadata" + "::" + key));
        }

        /// <summary>
        /// Raised by the instance store after persistence.
        /// </summary>
        public Func<Task> Persisted;

        /// <summary>
        /// Raises the Persisted event.
        /// </summary>
        public Task OnPersisted()
        {
            return Persisted();
        }

    }

}
