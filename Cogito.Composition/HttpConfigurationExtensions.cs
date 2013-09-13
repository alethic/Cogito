using System;
using System.Diagnostics.Contracts;
using System.Web.Http;

namespace ISIS.Web.Mvc
{

    public static class HttpConfigurationExtensions
    {

        /// <summary>
        /// Gets the <see cref="ICompositionService"/> configured on the <see cref="HttpConfiguration"/>, or creates a
        /// new one.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static ICompositionService RequireComposition(this HttpConfiguration configuration)
        {
            Contract.Requires<ArgumentNullException>(configuration != null);

            return (ICompositionService)configuration.Properties
                .GetOrAdd(typeof(ICompositionService), _ =>
                    new CompositionManager(configuration));
        }

    }

}
