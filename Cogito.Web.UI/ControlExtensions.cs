using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;

using Cogito.Linq;

namespace Cogito.Web.UI
{

    /// <summary>
    /// Provides extensions that make working with <see cref="Control"/> instances easier.
    /// </summary>
    public static class ControlExtensions
    {

        /// <summary>
        /// Traverses from this control downward.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static IEnumerable<Control> Traverse(this Control control)
        {
            Contract.Requires<ArgumentNullException>(control != null);

            yield return control;

            foreach (Control _ in control.Controls)
                foreach (Control __ in Traverse(_))
                    yield return __;
        }

        /// <summary>
        /// Sets the given attribute and attribute value on the <see cref="Control"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T AddAttribute<T>(this T control, string key, string value)
            where T : IAttributeAccessor
        {
            Contract.Requires<ArgumentNullException>(control != null);
            Contract.Requires<ArgumentNullException>(key != null);

            control.SetAttribute(key, value);

            return control;
        }

        /// <summary>
        /// Sets the given attribute and attribute value on the <see cref="Control"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static T AddAttribute<T>(this T control, Expression<Func<string, string>> attribute)
            where T : class, IAttributeAccessor
        {
            Contract.Requires<ArgumentNullException>(control != null);
            Contract.Requires<ArgumentNullException>(attribute != null);

            foreach (var p in attribute.Parameters)
                AddAttribute(control, p.Name, attribute.Compile()(control.GetAttribute(p.Name)));

            return control;
        }

        /// <summary>
        /// Adds the given CSS class to the <see cref="IAttributeAccessor"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="class"></param>
        /// <returns></returns>
        public static T AddClass<T>(this T control, string @class)
            where T : class, IAttributeAccessor
        {
            Contract.Requires<ArgumentNullException>(control != null);

            if (!string.IsNullOrWhiteSpace(@class))
            {
                // split all class names, append new class name, remove duplicates
                var css = (control.GetAttribute("class") ?? "")
                    .Split(' ')
                    .Append(@class)
                    .Select(i => i.TrimOrNull())
                    .Where(i => i != null)
                    .ToArray();

                if (css.Length > 0)
                    control.SetAttribute("class", string.Join(" ", css));
            }

            return control;
        }

        /// <summary>
        /// Removes the given CSS class from the <see cref="IAttributeAccessor"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="class"></param>
        /// <returns></returns>
        public static T RemoveClass<T>(this T control, string @class)
            where T : class, IAttributeAccessor
        {
            Contract.Requires<ArgumentNullException>(control != null);

            if (!string.IsNullOrWhiteSpace(@class))
            {
                // split all class names, append new class name, remove duplicates
                var css = (control.GetAttribute("class") ?? "")
                    .Split(' ')
                    .Select(i => i.TrimOrNull())
                    .Where(i => i != null)
                    .Where(i => i != @class)
                    .ToArray();

                control.SetAttribute("class", string.Join(" ", css).TrimOrNull());
            }

            return control;
        }

        /// <summary>
        /// Adds the given content to the body of the control.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T WithContent<T>(this T control, string value)
            where T : Control
        {
            Contract.Requires<ArgumentNullException>(control != null);

            if (!string.IsNullOrWhiteSpace(value))
                control.Controls.Add(new LiteralControl(value));

            return control;
        }

    }

}
