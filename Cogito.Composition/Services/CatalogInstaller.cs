using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;

namespace Cogito.Composition.Services
{

    /// <summary>
    /// Installs provided catalogs in the container.
    /// </summary>
    [OnInitInvokeAttribute]
    [ExportMetadata(CompositionConstants.VisibilityMetadataKey, Visibility.Local)]
    public class CatalogInstaller :
        IOnInitInvoke
    {

        readonly ICatalogService catalogs;
        readonly IEnumerable<ICatalogProvider> providers;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="catalogs"></param>
        [ImportingConstructor]
        public CatalogInstaller(
            ICatalogService catalogs, 
            [ImportMany] IEnumerable<ICatalogProvider> providers)
        {
            this.catalogs = catalogs;
            this.providers = providers;
        }

        public void Invoke()
        {
            foreach (var catalog in providers.SelectMany(i => i.GetCatalogs()))
                catalogs.Add(catalog);
        }

    }

}
