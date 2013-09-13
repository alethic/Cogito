using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace ISIS.Web.Mvc
{

    /// <summary>
    /// Implements <see cref="ICompositionService"/> for the root of the application.
    /// </summary>
    class CompositionServiceRoot : CompositionService
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CompositionServiceRoot()
            : base()
        {
            
        }

        protected override ComposablePartCatalog CreateCatalog()
        {
            return new AssemblyCatalog(typeof(CompositionServiceRoot).Assembly);
        }

    }

}
