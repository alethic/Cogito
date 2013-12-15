using System;
using System.ComponentModel.Composition;
using System.Web.UI;

using Cogito.Resources;

namespace Cogito.Web.UI.Resources
{

    /// <summary>
    /// Injects referenced style sheets into the HTML head section.
    /// </summary>
    [Export(typeof(IResourceReferencePageInstaller))]
    public class StyleSheetResourcePageInstaller :
        IResourceReferencePageInstaller
    {

        public bool Install(Page page, IResource resource)
        {
            if (resource.ContentType != "text/css")
                return false;

            var header = page.Header;
            if (header == null)
                throw new NullReferenceException("Header control not found.");

            // install script control
            header.Controls
                .GetOrAdd<StyleSheetResourceControl>(_ => _.Resource == resource, () => new StyleSheetResourceControl(resource));

            return true;
        }

    }

}
