using System;
using System.Diagnostics.Contracts;
using System.Web.UI;

using Cogito.Resources;

namespace Cogito.Web.UI.Resources
{

    public class ScriptResourceBundleReference :
        ScriptReference
    {

        readonly IResourceBundle bundle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundle"></param>
        /// <param name="name"></param>
        public ScriptResourceBundleReference(IResourceBundle bundle, string name)
        {
            Contract.Requires<ArgumentNullException>(bundle != null);
            Contract.Requires<ArgumentNullException>(name != null);

            this.Name = name;
            this.bundle = bundle;
        }

    }

}
