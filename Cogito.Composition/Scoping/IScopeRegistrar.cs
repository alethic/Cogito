using System.ComponentModel.Composition.Hosting;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Manages a scope container.
    /// </summary>
    public interface IScopeRegistrar
    {

        /// <summary>
        /// Finds a container for the scope.
        /// </summary>
        /// <returns></returns>
        CompositionContainer Resolve();

        /// <summary>
        /// Sets a container for the scope.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        void Register(CompositionContainer context);

    }

}
