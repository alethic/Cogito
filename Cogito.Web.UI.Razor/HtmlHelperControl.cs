using System;
using System.Web.UI;

namespace Cogito.Web.UI.Razor
{

    /// <summary>
    /// ASP.Net server control that accepts and renders a <see cref="HtmlHelperResult"/>.
    /// </summary>
    class HtmlHelperControl : CogitoControl
    {

        Action<object> action;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        public HtmlHelperControl(Action<object> action)
        {
            this.action = action;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            
        }

    }

}
