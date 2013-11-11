using System.Linq;

namespace Cogito.Resources
{

    /// <summary>
    /// Represents a provider that can query for available resource bundles.
    /// </summary>
    public interface IResourceBundleProvider
        : IQueryable<IResourceBundle>
    {



    }

}
