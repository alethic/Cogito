using System.Web.UI;

using Cogito.Resources;

namespace Cogito.Web.UI.Resources
{

    /// <summary>
    /// Injects referenced scripts into the HTML head section.
    /// </summary>
    public class ScriptResourcePageInstaller :
        IResourceReferencePageInstaller
    {

        public bool Install(Page page, IResource resource)
        {
            if (resource.ContentType != "application/javascript")
                return false;

            // install script control
            page.Header.Controls
                .GetOrAdd<ScriptResourceControl>(_ => _.Resource == resource, () => new ScriptResourceControl(resource));

            return true;
        }

    }

}
