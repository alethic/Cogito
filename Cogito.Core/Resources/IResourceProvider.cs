using System.Linq;

namespace Cogito.Resources
{

    /// <summary>
    /// Represents a provider that can query for available resources.
    /// </summary>
    public interface IResourceProvider
        : IQueryable<IResource>
    {



    }

}
