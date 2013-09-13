using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace Cogito.Composition
{

    /// <summary>
    /// <see cref="CompositionContext"/> implementation that imports the entire application by default.
    /// </summary>
    public class ApplicationCompositionContext : CompositionContext
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ApplicationCompositionContext()
            : base()
        {

        }

        protected override ComposablePartCatalog CreateCatalog()
        {
            return new AggregateCatalog(new ApplicationCatalog());
        }

    }

}
