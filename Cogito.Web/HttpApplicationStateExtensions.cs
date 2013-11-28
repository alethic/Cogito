using System;
using System.Diagnostics.Contracts;
using System.Web;

using Cogito.Composition;
using Cogito.Web.Configuration;

namespace Cogito.Web
{

    /// <summary>
    /// Provides extension methods for working with the <see cref="HttpApplicationState"/> type.
    /// </summary>
    public static class HttpApplicationStateExtensions
    {

        static readonly ConfigurationSection configuration =
            ConfigurationSection.GetDefaultSection();

        /// <summary>
        /// Gets the <see cref="ICompositionContext"/> for the application.
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public static ICompositionContext GetCompositionContext(this HttpApplicationState http)
        {
            return GetCompositionContext(new HttpApplicationStateWrapper(http));
        }

        /// <summary>
        /// Gets the <see cref="ICompositionContext"/> for the application.
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public static ICompositionContext GetCompositionContext(this HttpApplicationStateBase http)
        {
            Contract.Requires<ArgumentNullException>(http != null);

            return (ICompositionContext)http.Get(typeof(ICompositionContext).FullName);
        }

        /// <summary>
        /// Sets the given <see cref="ICompositionContext"/> for the application.
        /// </summary>
        /// <param name="http"></param>
        /// <param name="composition"></param>
        public static void SetCompositionContext(this HttpApplicationState http, ICompositionContext composition)
        {
            Contract.Requires<ArgumentNullException>(http != null);
            Contract.Requires<ArgumentNullException>(composition != null);

            SetCompositionContext(new HttpApplicationStateWrapper(http), composition);
        }

        /// <summary>
        /// Sets the given <see cref="ICompositionContext"/> for the application.
        /// </summary>
        /// <param name="http"></param>
        /// <param name="composition"></param>
        public static void SetCompositionContext(this HttpApplicationStateBase http, ICompositionContext composition)
        {
            Contract.Requires<ArgumentNullException>(http != null);
            Contract.Requires<ArgumentNullException>(composition != null);

            http[typeof(ICompositionContext).FullName] = composition;
        }

    }

}
