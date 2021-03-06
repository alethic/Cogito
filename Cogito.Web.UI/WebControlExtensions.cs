﻿using System;
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
            if (control == null)
                throw new ArgumentNullException(nameof(control));

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
            if (control == null)
                throw new ArgumentNullException(nameof(control));

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

        /// <summary>
        /// Adds the given CSS style to the <see cref="WebControl"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T AddCssStyle<T>(this T control, string key, string value)
            where T : WebControl
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentOutOfRangeException(nameof(key));

            control.Style.Add(key, value);

            return control;
        }

        /// <summary>
        /// Removes the given CSS style from the <see cref="WebControl"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T RemoveCssStyle<T>(this T control, string key)
            where T : WebControl
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentOutOfRangeException(nameof(key));

            control.Style.Remove(key);

            return control;
        }

    }

}
