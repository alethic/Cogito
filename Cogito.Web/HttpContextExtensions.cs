using System;
using System.Diagnostics.Contracts;
using System.Web;

using Cogito.Composition;

namespace Cogito.Web
{

    /// <summary>
    /// Provides extension methods for working against a <see cref="HttpContext"/>.
    /// </summary>
    public static class HttpContextExtensions
    {

        /// <summary>
        /// Gets a reference to the composition context for the current request.
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public static ICompositionContext GetCompositionContext(this HttpContext http)
        {
            Contract.Requires<ArgumentNullException>(http != null);

            return GetCompositionContext(new HttpContextWrapper(http));
        }

        /// <summary>
        /// Gets a reference to the composition context for the current request.
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public static ICompositionContext GetCompositionContext(this HttpContextBase http)
        {
            Contract.Requires<ArgumentNullException>(http != null);

            // find existing context
            return (ICompositionContext)http.Items[typeof(ICompositionContext)];
        }

        /// <summary>
        /// Gets the composition context for the current request.
        /// </summary>
        /// <param name="http"></param>
        /// <param name="composition"></param>
        /// <returns></returns>
        public static void SetCompositionContext(this HttpContext http, ICompositionContext composition)
        {
            Contract.Requires<ArgumentNullException>(http != null);
            Contract.Requires<ArgumentNullException>(composition != null);

            SetCompositionContext(new HttpContextWrapper(http), composition);
        }

        /// <summary>
        /// Sets the composition context for the current request.
        /// </summary>
        /// <param name="http"></param>
        /// <param name="composition"></param>
        /// <returns></returns>
        public static void SetCompositionContext(this HttpContextBase http, ICompositionContext composition)
        {
            Contract.Requires<ArgumentNullException>(http != null);
            Contract.Requires<ArgumentNullException>(composition != null);

            http.Items[typeof(ICompositionContext)] = composition;
        }

    }

}
