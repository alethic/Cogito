using Cogito.Core;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Exports the <see cref="CompositionContainer"/> to itself.
    /// </summary>
    public class CompositionContainerExport :
        Value<CompositionContainer>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="container"></param>
        public CompositionContainerExport(CompositionContainer container)
            : base(container)
        {

        }

    }

}
