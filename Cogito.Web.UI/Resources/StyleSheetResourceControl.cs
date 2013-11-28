using System;
using System.Diagnostics.Contracts;

using Cogito.Resources;

namespace Cogito.Web.UI.Resources
{

    /// <summary>
    /// Renders a `link` tag for a CSS stylesheet <see cref="IResource"/>.
    /// </summary>
    public class StyleSheetResourceControl
        : CogitoControl
    {

        readonly IResource resource;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resource"></param>
        public StyleSheetResourceControl(IResource resource)
        {
            Contract.Requires<ArgumentException>(resource.ContentType == "text/css");

            this.resource = resource;
        }

        /// <summary>
        /// Gets a reference to the <see cref="IResource"/> being rendered.
        /// </summary>
        public IResource Resource
        {
            get { return resource; }
        }

    }

}
