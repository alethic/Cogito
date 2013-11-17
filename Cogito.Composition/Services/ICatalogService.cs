using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;

namespace Cogito.Composition.Services
{

    /// <summary>
    /// Allows access to the currently registered catalogs.
    /// </summary>
    public interface ICatalogService :
        IEnumerable<ComposablePartCatalog>
    {

        /// <summary>
        /// Adds the given catalog.
        /// </summary>
        /// <param name="catalog"></param>
        void Add(ComposablePartCatalog catalog);

    }

}
