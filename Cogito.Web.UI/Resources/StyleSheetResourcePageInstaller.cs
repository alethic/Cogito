using System.Web.UI;

using Cogito.Resources;

namespace Cogito.Web.UI.Resources
{

    /// <summary>
    /// Injects referenced style sheets into the HTML head section.
    /// </summary>
    public class StyleSheetResourcePageInstaller :
        IResourceReferencePageInstaller
    {

        public bool Install(Page page, IResource resource)
        {
            if (resource.ContentType != "text/css")
                return false;

            // install script control
            page.Header.Controls
                .GetOrAdd<StyleSheetResourceControl>(_ => _.Resource == resource, () => new StyleSheetResourceControl(resource));

            return true;
        }

    }

}
