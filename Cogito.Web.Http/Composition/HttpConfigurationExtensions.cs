using System;
using System.Diagnostics.Contracts;
using System.Web.Http;

using Cogito.Composition;

namespace Cogito.Web.Http.Composition
{

    /// <summary>
    /// Provides composition related extensions to <see cref="HttpConfiguration"/>.
    /// </summary>
    public static class HttpConfigurationExtensions
    {

        /// <summary>
        /// Gets the <see cref="ICompositionContext"/> configured on the <see cref="HttpConfiguration"/>, or creates a
        /// new one.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static ICompositionContext RequireComposition(this HttpConfiguration configuration)
        {
            Contract.Requires<ArgumentNullException>(configuration != null);

            // get or create composition service
            return (ICompositionContext)configuration.Properties
                .GetOrAdd(typeof(ICompositionContext), _ =>
                    new HttpCompositionContext(configuration));
        }

    }

}
