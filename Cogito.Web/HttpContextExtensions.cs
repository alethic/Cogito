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
            var ctx = (ICompositionContext)http.Items[typeof(ICompositionContext)];
            if (ctx == null)
                // or create new
                http.Items.Add(typeof(ICompositionContext), ctx = CreateCompositionContext(http));

            return ctx;
        }

        /// <summary>
        /// Creates a new per-request context.
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        static ICompositionContext CreateCompositionContext(this HttpContextBase http)
        {
            Contract.Requires<ArgumentNullException>(http != null);

            var ctx = http.Application.GetCompositionContext();
            if (ctx == null)
                throw new NullReferenceException("Could not obtain application level context.");

            return ctx.CreateScope<IRequestScope>();
        }

    }

}
