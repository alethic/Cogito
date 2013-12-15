using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.UI;
using Cogito.Resources;

namespace Cogito.Web.UI.Resources
{

    /// <summary>
    /// Renders a `script` tag for a <see cref="IResource"/>.
    /// </summary>
    public class ScriptResourceControl :
        CogitoControl,
        IScriptControl
    {

        readonly IResource resource;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resource"></param>
        public ScriptResourceControl(IResource resource)
        {
            Contract.Requires<ArgumentNullException>(resource != null);
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

        protected override void Render(HtmlTextWriter writer)
        {
            var url = ResolveUrl(Resource);
            if (url == null)
                throw new NullReferenceException(string.Format("Could not resolve Url for resource {0}.", Resource));

            writer.Write(string.Format("<script type=\"application/javascript\" src=\"{0}\"></script>\n", url));
        }
    
        public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            yield break;
        }

        public IEnumerable<ScriptReference> GetScriptReferences()
        {
            yield break;
        }

    }

}
