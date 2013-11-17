using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using Cogito.Composition.Services;

namespace Cogito.Composition.Hosting
{

    public class CatalogService :
        ICatalogService
    {

        readonly ICollection<ComposablePartCatalog> catalogs;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="catalogs"></param>
        public CatalogService(
            ICollection<ComposablePartCatalog> catalogs)
        {
            this.catalogs = catalogs;
        }

        public void Add(ComposablePartCatalog catalog)
        {
            catalogs.Add(catalog);
        }

        public IEnumerator<ComposablePartCatalog> GetEnumerator()
        {
            return catalogs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

}
