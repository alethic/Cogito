using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.UI.WebControls;

using Cogito.Linq;

namespace Cogito.Web.UI
{

    /// <summary>
    /// Provides extensions that make working with <see cref="WebControl"/> instances easier.
    /// </summary>
    public static class WebControlExtensions
    {

        /// <summary>
        /// Adds the given CSS class to the <see cref="WebControl"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="class"></param>
        /// <returns></returns>
        public static T AddCssClass<T>(this T control, string @class)
            where T : WebControl
        {
            Contract.Requires<ArgumentNullException>(control != null);

            if (!string.IsNullOrWhiteSpace(@class))
            {
                // split all class names, append new class name, remove duplicates
                var css = control.CssClass
                    .Split(' ')
                    .Append(@class)
                    .Select(i => i.TrimOrNull())
                    .Where(i => i != null)
                    .ToArray();

                if (css.Length > 0)
                    control.CssClass = string.Join(" ", css);
            }

            return control;
        }

        /// <summary>
        /// Removes the given CSS class from the <see cref="WebControl"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="class"></param>
        /// <returns></returns>
        public static T RemoveCssClass<T>(this T control, string @class)
            where T : WebControl
        {
            Contract.Requires<ArgumentNullException>(control != null);

            if (!string.IsNullOrWhiteSpace(@class))
            {
                // split all class names, append new class name, remove duplicates
                var css = control.CssClass
                    .Split(' ')
                    .Select(i => i.TrimOrNull())
                    .Where(i => i != null)
                    .Where(i => i != @class)
                    .ToArray();

                control.CssClass = string.Join(" ", css);
            }

            return control;
        }

    }

}
