using System;
using System.Linq;
using System.Web.UI;

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
            if (controls == null)
                throw new ArgumentNullException(nameof(controls));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            if (create == null)
                throw new ArgumentNullException(nameof(create));

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
            if (controls == null)
                throw new ArgumentNullException(nameof(controls));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

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
            if (controls == null)
                throw new ArgumentNullException(nameof(controls));
            if (create == null)
                throw new ArgumentNullException(nameof(create));

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
            if (controls == null)
                throw new ArgumentNullException(nameof(controls));

            return controls.GetOrAdd(() => new TControl());
        }

    }

}
