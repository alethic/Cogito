using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Provides scopes.
    /// </summary>
    [Export(typeof(ScopeProvider))]
    public class ScopeProvider
    {

        ICompositionContext composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="scopeContexts"></param>
        [ImportingConstructor]
        public ScopeProvider(
            ICompositionContext composition)
        {
            this.composition = composition;
        }

        /// <summary>
        /// Gets an existing scope of the specified type, or begins a new one.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        public ICompositionContext GetOrBeginScope(Type scopeType)
        {
            return GetScope(scopeType) ?? BeginScope(scopeType);
        }

        /// <summary>
        /// Gets an existing scope of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        public ICompositionContext GetScope(Type scopeType)
        {
            var scopeContexts = composition.GetExportedValues(typeof(IScopeContext<>).MakeGenericType(scopeType))
                .OfType<IScopeContext>();
            return scopeContexts
                .Select(i => i.GetScope())
                .FirstOrDefault();
        }

        /// <summary>
        /// Begins a new scope of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        public ICompositionContext BeginScope(Type scopeType)
        {
            var scopeContexts = composition.GetExportedValues(typeof(IScopeContext<>).MakeGenericType(scopeType))
                .OfType<IScopeContext>();
            return scopeContexts
                .Select(i => i.BeginScope())
                .FirstOrDefault();
        }

    }

    /// <summary>
    /// Provides scopes.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    [Export(typeof(ScopeProvider<>))]
    public class ScopeProvider<TScope>
        where TScope : IScope
    {

        IEnumerable<IScopeContext<TScope>> scopeContexts;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="scopeContexts"></param>
        [ImportingConstructor]
        public ScopeProvider(
            IEnumerable<IScopeContext<TScope>> scopeContexts)
        {
            this.scopeContexts = scopeContexts;
        }

        /// <summary>
        /// Gets an existing scope or begins a new one.
        /// </summary>
        /// <returns></returns>
        public ICompositionContext GetOrBeginScope()
        {
            return GetScope() ?? BeginScope();
        }

        /// <summary>
        /// Gets the current scope.
        /// </summary>
        /// <returns></returns>
        public ICompositionContext GetScope()
        {
            return scopeContexts
                .Select(i => i.GetScope())
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the current scope.
        /// </summary>
        /// <returns></returns>
        public ICompositionContext BeginScope()
        {
            return scopeContexts
                .Select(i => i.BeginScope())
                .FirstOrDefault();
        }

    }

}
