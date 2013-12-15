using System;
using System.Diagnostics.Contracts;
using System.Web.UI;

using Cogito.Resources;

namespace Cogito.Web.UI.Resources
{

    /// <summary>
    /// Renders a `link` tag for a CSS stylesheet <see cref="IResource"/>.
    /// </summary>
    public class StyleSheetResourceControl :
        CogitoControl
    {

        readonly IResource resource;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resource"></param>
        public StyleSheetResourceControl(IResource resource)
        {
            Contract.Requires<ArgumentNullException>(resource != null);
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

        protected override void Render(HtmlTextWriter writer)
        {
            var url = ResolveUrl(Resource);
            if (url == null)
                throw new NullReferenceException(string.Format("Could not resolve Url for resource {0}.", Resource));

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/css");
            writer.AddAttribute(HtmlTextWriterAttribute.Rel, "stylesheet");
            writer.AddAttribute(HtmlTextWriterAttribute.Href, url);
            writer.RenderBeginTag(HtmlTextWriterTag.Link);
            writer.RenderEndTag();
        }

    }

}
