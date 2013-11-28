using System;
using System.Diagnostics.Contracts;
using System.Web.UI;

namespace Cogito.Web.UI.Resources
{

    /// <summary>
    /// Injects referenced stylesheets into the HTML head.
    /// </summary>
    class StyleSheetManager :
        CogitoControl
    {

        readonly ResourceManager resourceManager;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public StyleSheetManager(ResourceManager resourceManager)
        {
            Contract.Requires<ArgumentNullException>(resourceManager != null);

            this.resourceManager = resourceManager;
        }

    }

}
