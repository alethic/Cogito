using System;
using System.Diagnostics.Contracts;
using System.Web;
using System.Web.Routing;

using Cogito.Composition;

namespace Cogito.Web.Mvc
{

    public static class HttpApplicationExtensions
    {

        /// <summary>
        /// Enables composition extensions on the WebApi configuration.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="http"></param>
        /// <param name="composition"></param>
        /// <returns></returns>
        public static HttpApplication WithMvcComposition(
            this HttpApplication http,
            ICompositionContext composition,
            RouteCollection routes)
        {
            Contract.Requires<ArgumentNullException>(http != null);
            Contract.Requires<ArgumentNullException>(composition != null);
            Contract.Requires<ArgumentNullException>(routes != null);

            // mark MVC as enabled
            composition.GetExportedValue<IMvcApplication>().Activate(http, routes);
            
            return http;
        }

    }

}
