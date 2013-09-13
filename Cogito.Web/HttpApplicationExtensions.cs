using System;
using System.Diagnostics.Contracts;
using System.Web;
using Cogito.Composition;

namespace Cogito.Web
{

    public static class HttpApplicationExtensions
    {

        /// <summary>
        /// Enables composition extensions on the ASP.Net Web configuration.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="application"></param>
        /// <param name="composition"></param>
        /// <returns></returns>
        public static HttpApplication WithComposition(
            this HttpApplication application,
            ICompositionContext composition)
        {
            Contract.Requires<ArgumentNullException>(application != null);
            Contract.Requires<ArgumentNullException>(composition != null);

            // mark MVC as enabled
            composition.GetExportedValue<IWebConfiguration>().Configured = true;

            return application;
        }

    }

}
