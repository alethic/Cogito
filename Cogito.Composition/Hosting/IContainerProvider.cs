using Cogito.Core;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Provides access to the local <see cref="CompositionContainer"/>.
    /// </summary>
    public interface IContainerProvider
    {

        /// <summary>
        /// Gets the <see cref="CompositionContainer"/>.
        /// </summary>
        /// <returns></returns>
        CompositionContainer GetContainer();

        /// <summary>
        /// Allocates a reference to the <see cref="CompositionContainer"/>.
        /// </summary>
        /// <returns></returns>
        Ref<CompositionContainer> GetContainerRef();

    }

}
