using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace Cogito.Composition
{

    /// <summary>
    /// Implements <see cref="ICompositionContext"/> for the root of the application.
    /// </summary>
    public class CompositionContext : CompositionContextCore
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CompositionContext()
            : base()
        {
            
        }

        protected override ComposablePartCatalog CreateCatalog()
        {
            return new AssemblyCatalog(typeof(CompositionContext).Assembly);
        }

    }

}
