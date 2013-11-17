using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Cogito.Composition.Services
{

    /// <summary>
    /// Installs provided catalogs in the container.
    /// </summary>
    [OnInitInvokeAttribute]
    public class CatalogInstaller :
        IOnInitInvoke
    {

        readonly ICatalogService catalogs;
        readonly IEnumerable<ICatalogProvider> providers;
        readonly ICompositionContext context;
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="catalogs"></param>
        [ImportingConstructor]
        public CatalogInstaller(
            ICompositionContext context,
            ICatalogService catalogs, 
            [ImportMany] IEnumerable<ICatalogProvider> providers)
        {
            this.catalogs = catalogs;
            this.providers = providers;
            this.context = context;
        }

        public void Invoke()
        {
            foreach (var catalog in providers.SelectMany(i => i.GetCatalogs()))
                catalogs.Add(catalog);
        }

    }

}
