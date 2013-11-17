using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;

namespace Cogito.Composition.Services
{

    /// <summary>
    /// Describes an object that provides additional <see cref="ComposablePartCatalog"/>s to a container.
    /// </summary>
    public interface ICatalogProvider
    {

        /// <summary>
        /// Gets the catalogs being provided that will be integrated into the container.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ComposablePartCatalog> GetCatalogs();

    }

}
