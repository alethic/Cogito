using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.UI;

using Cogito.Linq;

namespace Cogito.Web.UI
{

    /// <summary>
    /// Provides various extensions for working with <see cref="ControlCollection"/> instances.
    /// </summary>
    public static class ControlCollectionExtensions
    {

        /// <summary>
        /// Gets or adds a <see cref="Control"/> to the <see cref="ControlCollection"/>.
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="controls"></param>
        /// <param name="predicate"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public static TControl GetOrAdd<TControl>(this ControlCollection controls, Predicate<TControl> predicate, Func<TControl> create)
            where TControl : Control
        {
            Contract.Requires<ArgumentNullException>(controls != null);
            Contract.Requires<ArgumentNullException>(predicate != null);
            Contract.Requires<ArgumentNullException>(create != null);

            // find existing
            var control = controls
                .OfType<TControl>()
                .Where(i => predicate(i))
                .FirstOrDefault();

            // add new
            if (control == null)
                controls.Add(control = create());

            return control;
        }

        /// <summary>
        /// Gets or adds a new <see cref="Control"/> to the <see cref="ControlCollection"/>.
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="controls"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static TControl GetOrAdd<TControl>(this ControlCollection controls, Predicate<TControl> predicate)
            where TControl : Control, new()
        {
            Contract.Requires<ArgumentNullException>(controls != null);
            Contract.Requires<ArgumentNullException>(predicate != null);

            return controls.GetOrAdd(predicate, () => new TControl());
        }

        /// <summary>
        /// Gets or adds a <see cref="Control"/> to the <see cref="ControlCollection"/>.
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="controls"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public static TControl GetOrAdd<TControl>(this ControlCollection controls, Func<TControl> create)
            where TControl : Control
        {
            Contract.Requires<ArgumentNullException>(controls != null);
            Contract.Requires<ArgumentNullException>(create != null);

            return controls.GetOrAdd<TControl>(_ => true, create);
        }

        /// <summary>
        /// Gets or adds a new <see cref="CogitoControl"/> to the <see cref="ControlCollection"/>.
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="controls"></param>
        /// <returns></returns>
        public static TControl GetOrAdd<TControl>(this ControlCollection controls)
            where TControl : Control, new()
        {
            Contract.Requires<ArgumentNullException>(controls != null);

            return controls.GetOrAdd(() => new TControl());
        }

    }

}
