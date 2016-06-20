using Cogito.Core;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Exports the <see cref="CompositionContainer"/> to itself.
    /// </summary>
    class ContainerExport :
        Value<CompositionContainer>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="container"></param>
        public ContainerExport(CompositionContainer container)
            : base(container)
        {

        }

    }

}
