using System;
using System.Diagnostics.Contracts;
using System.Web;
using Cogito.Composition;
using Cogito.Composition.Hosting;
using Cogito.Web.Configuration;

namespace Cogito.Web
{

    public static class HttpApplicationStateExtensions
    {

        static readonly ConfigurationSection configuration =
            ConfigurationSection.GetDefaultSection();

        /// <summary>
        /// Gets the configured <see cref="ICompositionContext"/>.
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public static ICompositionContext GetCompositionContext(this HttpApplicationStateBase http)
        {
            Contract.Requires<ArgumentNullException>(http != null);

            var ctx = (ICompositionContext)http.Get(typeof(ICompositionContext).FullName);
            if (ctx == null)
                http.Add(typeof(ICompositionContext).FullName, ctx = GetConfiguredContext(http));

            return ctx;
        }

        /// <summary>
        /// Gets the configured composition context.
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        static ICompositionContext GetConfiguredContext(this HttpApplicationStateBase http)
        {
            Contract.Requires<ArgumentNullException>(http != null);

            return ContainerManager.GetContainer(configuration.Composition.ContainerName ?? "Default")
                .AsContext();
        }

    }

}
