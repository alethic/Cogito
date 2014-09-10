using System;
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

        readonly IContainerProvider provider;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="provider"></param>
        [ImportingConstructor]
        public CatalogService(IContainerProvider provider)
        {
            this.provider = provider;
        }

        public void Add(ComposablePartCatalog catalog)
        {
            provider.GetContainer().AddCatalog(catalog);
        }

    }

}
