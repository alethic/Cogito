using System;
using System.Web;
using System.Web.UI;

using Cogito.Web.Razor;

namespace Cogito.Web.UI.Razor
{

    /// <summary>
    /// Specialized <see cref="Page"/> instance that uses the Razor templating service to implement it's Render method.
    /// </summary>
    public abstract class RazorPage : Page, IRazorControlAccessor
    {

        IRazorControlTemplate template;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public RazorPage()
            : base()
        {
            // look up template
            template = Razor.Template(this, GetType());
            if (template == null)
                throw new RazorException("Could not load Razor template for {0}.", this);
        }

        /// <summary>
        /// Gets the <see cref="RazorControlTemplate"/> that will render this <see cref="RazorControl"/>.
        /// </summary>
        protected IRazorControlTemplate Template
        {
            get { return template; }
        }

        /// <summary>
        /// Raises the System.Web.UI.Control.Init event.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnInit(EventArgs args)
        {
            base.OnInit(args);

            EnsureChildControls();
        }

        /// <summary>
        /// Renders the control using the configured Razor template.
        /// </summary>
        /// <param name="writer"></param>
        protected sealed override void Render(HtmlTextWriter writer)
        {
            Razor.Render(writer, template);
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="writer"></param>
        /// <exception cref="NotSupportedException" />
        protected sealed override void RenderChildren(HtmlTextWriter writer)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Implements IRazorControlAccessor.Context.
        /// </summary>
        HttpContextBase IRazorControlAccessor.Context
        {
            get { return new HttpContextWrapper(Context); }
        }

        /// <summary>
        /// Implements IRazorControlAccessor.ViewState.
        /// </summary>
        StateBag IRazorControlAccessor.ViewState
        {
            get { return ViewState; }
        }

    }

}
