using System;
using System.Diagnostics.Contracts;

using Cogito.Resources;

namespace Cogito.Web.UI.Resources
{

    /// <summary>
    /// Renders a `script` tag for a <see cref="IResource"/>.
    /// </summary>
    public class ScriptResourceControl
        : CogitoControl
    {

        readonly IResource resource;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resource"></param>
        public ScriptResourceControl(IResource resource)
        {
            Contract.Requires<ArgumentException>(resource.ContentType == "application/javascript");

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
