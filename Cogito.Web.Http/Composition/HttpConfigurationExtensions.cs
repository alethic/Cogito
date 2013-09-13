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
        public static ICompositionContext RequireComposition<T>(
            this HttpConfiguration configuration, 
            Func<HttpConfiguration, T> create)
            where T : HttpCompositionContext
        {
            Contract.Requires<ArgumentNullException>(configuration != null);

            // get or create composition service
            return (ICompositionContext)configuration.Properties
                .GetOrAdd(typeof(ICompositionContext), _ =>
                    create(configuration));
        }

        /// <summary>
        /// Gets the <see cref="ICompositionContext"/> configured on the <see cref="HttpConfiguration"/>, or creates a
        /// new one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static ICompositionContext RequireComposition<T>(
            this HttpConfiguration configuration)
            where T : HttpCompositionContext, new()
        {
            return RequireComposition<T>(configuration, _ => new T());
        }

        /// <summary>
        /// Gets the <see cref="ICompositionContext"/> configured on the <see cref="HttpConfiguration"/>, or creates a
        /// new one.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static ICompositionContext RequireComposition(
            this HttpConfiguration configuration)
        {
            return RequireComposition(configuration, c => new HttpCompositionContext(c));
        }

    }

}
