using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;

using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;

namespace Cogito.Composition.Services
{

    [Export(typeof(ICatalogService))]
    [ExportMetadata(CompositionConstants.VisibilityMetadataKey, Visibility.Local)]
    public class CatalogService :
        ICatalogService
    {

        readonly CompositionContainerRef _ref;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="_ref"></param>
        [ImportingConstructor]
        public CatalogService(CompositionContainerRef _ref)
        {
            this._ref = _ref;
        }

        public void Add(ComposablePartCatalog catalog)
        {
            _ref.Container.AddCatalog(catalog);
        }

    }

}
