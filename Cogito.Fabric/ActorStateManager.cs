using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Data;

namespace Cogito.Fabric
{

    /// <summary>
    /// <see cref="IActorStateManager"/>.
    /// </summary>
    public class ActorStateManager :
        IActorStateManager
    {

        readonly IActorStateManager state;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="state"></param>
        public ActorStateManager(IActorStateManager state)
        {
            Contract.Requires<ArgumentNullException>(state != null);

            this.state = state;
        }

        public virtual Task<T> AddOrUpdateStateAsync<T>(string stateName, T addValue, Func<string, T, T> updateValueFactory, CancellationToken cancellationToken = default(CancellationToken))
        {
            return state.AddOrUpdateStateAsync<T>(stateName, addValue, updateValueFactory, cancellationToken);
        }

        public virtual Task AddStateAsync<T>(string stateName, T value, CancellationToken cancellationToken = default(CancellationToken))
        {
            return state.AddStateAsync<T>(stateName, value, cancellationToken);
        }

        public virtual Task<bool> ContainsStateAsync(string stateName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return state.ContainsStateAsync(stateName, cancellationToken);
        }

        public virtual Task<T> GetOrAddStateAsync<T>(string stateName, T value, CancellationToken cancellationToken = default(CancellationToken))
        {
            return state.GetOrAddStateAsync<T>(stateName, value, cancellationToken);
        }

        public virtual Task<T> GetStateAsync<T>(string stateName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return state.GetStateAsync<T>(stateName, cancellationToken);
        }

        public virtual Task<IEnumerable<string>> GetStateNamesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return state.GetStateNamesAsync(cancellationToken);
        }

        public virtual Task RemoveStateAsync(string stateName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return state.RemoveStateAsync(stateName, cancellationToken);
        }

        public virtual Task SetStateAsync<T>(string stateName, T value, CancellationToken cancellationToken = default(CancellationToken))
        {
            return state.SetStateAsync<T>(stateName, value, cancellationToken);
        }

        public virtual Task<bool> TryAddStateAsync<T>(string stateName, T value, CancellationToken cancellationToken = default(CancellationToken))
        {
            return state.TryAddStateAsync<T>(stateName, value, cancellationToken);
        }

        public virtual Task<ConditionalValue<T>> TryGetStateAsync<T>(string stateName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return state.TryGetStateAsync<T>(stateName, cancellationToken);
        }

        public virtual Task<bool> TryRemoveStateAsync(string stateName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return state.TryRemoveStateAsync(stateName, cancellationToken);
        }

    }

}
