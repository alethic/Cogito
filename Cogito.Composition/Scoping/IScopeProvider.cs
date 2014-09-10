using System;
using Cogito.Composition.Hosting;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Manages a scope container.
    /// </summary>
    public interface IScopeProvider
    {

        /// <summary>
        /// Resolves an ambient scope container reference.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        CompositionContainer Resolve(Type scopeType);

        /// <summary>
        /// Registers an ambient scope container reference.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        void Register(Type scopeType, CompositionContainer container);

    }

}
