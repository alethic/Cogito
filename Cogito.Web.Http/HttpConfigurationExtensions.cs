using System;
using System.Diagnostics.Contracts;
using System.Web.Http;

using Cogito.Composition;

namespace Cogito.Web.Http
{

    /// <summary>
    /// Provides composition related extensions to <see cref="HttpConfiguration"/>.
    /// </summary>
    public static class HttpConfigurationExtensions
    {

        /// <summary>
        /// Enables composition extensions on the WebApi configuration.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="composition"></param>
        /// <returns></returns>
        public static HttpConfiguration WithApiComposition(
            this HttpConfiguration configuration,
            ICompositionContext composition)
        {
            Contract.Requires<ArgumentNullException>(configuration != null);
            Contract.Requires<ArgumentNullException>(composition != null);

            // mark MVC as enabled
            composition.GetExportedValue<IApiConfiguration>().Available = true;
            composition.GetExportedValue<IApiConfiguration>().Configuration = configuration;

            return configuration;
        }

    }

}
