using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.DurableInstancing;
using System.Threading.Tasks;
using System.Xml.Linq;
using Cogito.Collections;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.ServiceFabric.Activities
{

    /// <summary>
    /// Manages access to a workflow's state with a <see cref="IActorStateManager"/>.
    /// </summary>
    class ActivityActorStateManager
    {

        const string STATE_NAME = "__ActivityActorState__";

        readonly ActivityWorkflowHost host;
        internal object sync = new object();
        ActivityActorState state;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="host"></param>
        public ActivityActorStateManager(ActivityWorkflowHost host)
        {
            Contract.Requires<ArgumentNullException>(host != null);

            this.host = host;
        }

        /// <summary>
        /// Gets or sets the instance owner id.
        /// </summary>
        public Guid InstanceOwnerId
        {
            get { lock (sync) return state.InstanceOwnerId; }
            set { lock (sync) state.InstanceOwnerId = value; }
        }

        /// <summary>
        /// Gets or sets the instance id.
        /// </summary>
        public Guid InstanceId
        {
            get { lock (sync) return state.InstanceId; }
            set { lock (sync) state.InstanceId = value; }
        }

        /// <summary>
        /// Gets or sets the instance state.
        /// </summary>
        public InstanceState InstanceState
        {
            get { lock (sync) return state.InstanceState; }
            set { lock (sync) state.InstanceState = value; }
        }

        /// <summary>
        /// Sets an instance data item.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetInstanceData(string name, object value)
        {
            lock (sync)
                state.InstanceData[name] = value;
        }

        /// <summary>
        /// Gets an instance data item.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetInstanceData(string name)
        {
            lock (sync)
                return state.InstanceData.GetOrDefault(name);
        }

        /// <summary>
        /// Gets the available instance data names.
        /// </summary>
        /// <returns></returns>
        public string[] GetInstanceDataNames()
        {
            lock (sync)
                return state.InstanceData.Keys.ToArray();
        }

        /// <summary>
        /// Clears the instance data.
        /// </summary>
        public void ClearInstanceData()
        {
            lock (sync)
                state.InstanceData.Clear();
        }

        /// <summary>
        /// Sets an instance metadata item.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetInstanceMetadata(string name, object value)
        {
            lock (sync)
                state.InstanceMetadata[name] = value;
        }

        /// <summary>
        /// Gets an instance metadata item.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetInstanceMetadata(string name)
        {
            lock (sync)
                return state.InstanceMetadata.GetOrDefault(name);
        }

        /// <summary>
        /// Gets the available instance data names.
        /// </summary>
        /// <returns></returns>
        public string[] GetInstanceMetadataNames()
        {
            lock (sync)
                return state.InstanceMetadata.Keys.ToArray();
        }

        /// <summary>
        /// Clears the instance metadata.
        /// </summary>
        public void ClearInstanceMetadata()
        {
            lock (sync)
                state.InstanceMetadata.Clear();
        }

        /// <summary> 
        /// Loads the state from the actor. Should be invoked from a context with an actor lock.
        /// </summary>
        /// <returns></returns>
        public async Task LoadAsync()
        {
            var item = await host.Actor.StateManager.TryGetStateAsync<ActivityActorState>(STATE_NAME);
            state = item.HasValue ? item.Value : new ActivityActorState();
        }

        /// <summary>
        /// Saves the state to the actor. Should be invoked from a context with an actor lock.
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync()
        {
            await host.Actor.StateManager.SetStateAsync(STATE_NAME, state);
        }

        /// <summary>
        /// Raised by the instance store after persistence.
        /// </summary>
        public Action Persisted;

        /// <summary>
        /// Raises the Persisted event.
        /// </summary>
        public void OnPersisted()
        {
            Persisted?.Invoke();
        }

        /// <summary>
        /// Raised by the instance store upon completion.
        /// </summary>
        public Action Completed;

        /// <summary>
        /// Raises the Completed event.
        /// </summary>
        /// <returns></returns>
        public void OnCompleted()
        {
            Completed?.Invoke();
        }

    }

}
