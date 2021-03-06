﻿using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Cogito.Web.UI
{

    /// <summary>
    /// Provides extensions that make working with <see cref="HtmlControl"/> instances easier.
    /// </summary>
    public static class HtmlControlExtensions
    {

        /// <summary>
        /// Adds the given CSS style to the <see cref="HtmlControl"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T AddCssStyle<T>(this T control, string key, string value)
            where T : HtmlControl
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
        /// Adds the given CSS style to the <see cref="HtmlControl"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T AddCssStyle<T>(this T control, HtmlTextWriterStyle key, string value)
            where T : HtmlControl
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            control.Style.Add(key, value);

            return control;
        }

        /// <summary>
        /// Removes the given CSS style from the <see cref="HtmlControl"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T RemoveCssStyle<T>(this T control, string key)
            where T : HtmlControl
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

        /// <summary>
        /// Removes the given CSS style from the <see cref="HtmlControl"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T RemoveCssStyle<T>(this T control, HtmlTextWriterStyle key)
            where T : HtmlControl
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            control.Style.Remove(key);

            return control;
        }

    }

}
