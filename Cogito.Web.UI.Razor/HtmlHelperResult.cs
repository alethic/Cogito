using System;
using System.Diagnostics.Contracts;
using System.Web.UI;

using Cogito.Web.Razor;

namespace Cogito.Web.UI.Razor
{

    /// <summary>
    /// Simple template writer than invokes a delegate to write to a <see cref="HtmlWriter"/>.
    /// </summary>
    public class HtmlHelperResult :
        HelperResult
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        public HtmlHelperResult(Action<HtmlTextWriter> action)
            : base(w => action(w as HtmlTextWriter ?? new HtmlTextWriter(w)))
        {
            Contract.Requires<ArgumentNullException>(action != null);
        }

        /// <summary>
        /// Writes the result.
        /// </summary>
        /// <param name="writer"></param>
        public void WriteTo(HtmlTextWriter writer)
        {
            Contract.Requires<ArgumentNullException>(writer != null);

            base.WriteTo(writer);
        }

    }

}
