using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Cogito.Composition.Hosting;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Manages scopes.
    /// </summary>
    [Export(typeof(ScopeManager))]
    public class ScopeManager
    {

        readonly ICompositionContext composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        [ImportingConstructor]
        public ScopeManager(
            ICompositionContext composition)
        {
            this.composition = composition;
        }

        /// <summary>
        /// Gets the contexts for the given scope type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        IEnumerable<IScopeRegistrar> GetRegistrars(Type scopeType)
        {
            return composition
                .GetExportedValues(typeof(IScopeRegistrar<>).MakeGenericType(scopeType))
                .OfType<IScopeRegistrar>();
        }

        /// <summary>
        /// Gets an existing scope of the specified type, or begins a new one.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        public ICompositionContext GetOrBeginContext(Type scopeType)
        {
            return GetContext(scopeType) ?? RegisterContext(scopeType, BeginContext(scopeType));
        }

        /// <summary>
        /// Gets an existing scope of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        public ICompositionContext GetContext(Type scopeType)
        {
            return GetRegistrars(scopeType)
                .Select(i => i.GetScope())
                .FirstOrDefault(i => i != null);
        }

        /// <summary>
        /// Begins a new scope context.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        public ICompositionContext BeginContext(Type scopeType)
        {
            return CompositionScope.CreateScope(composition.AsContainer(), scopeType).AsContext();
        }

        /// <summary>
        /// Begins a new scope of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        public ICompositionContext RegisterContext(Type scopeType, ICompositionContext context)
        {
            foreach (var ctx in GetRegistrars(scopeType))
                ctx.RegisterScope(context);

            return context;
        }

    }

}
