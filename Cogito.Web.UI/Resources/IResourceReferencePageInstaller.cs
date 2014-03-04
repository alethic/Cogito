using System.Web.UI;

using Cogito.Resources;

namespace Cogito.Web.UI.Resources
{

    /// <summary>
    /// Installs a reference to a resource into the page.
    /// </summary>
    public interface IResourceReferencePageInstaller
    {

        /// <summary>
        /// Installs a reference to a resource into the page, if possible.
        /// </summary>
        bool Install(Page page, IResource resource);

    }

}
