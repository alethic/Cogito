using System;
using System.Diagnostics.Contracts;
using System.Web.Http;
using System.Web.Http.Dependencies;

using Cogito.Composition;

namespace Cogito.Web.Http.Composition
{

    /// <summary>
    /// Provides a <see cref="CompositionContext"/> implementation for an ASP.Net application. Injects itself into the
    /// given  <see cref="HttpConfiguration"/> object.
    /// </summary>
    class HttpCompositionService : CompositionContext
    {

        HttpConfiguration configuration;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="configuration"></param>
        internal HttpCompositionService(HttpConfiguration configuration)
        {
            Contract.Requires<ArgumentNullException>(configuration != null);

            // configure HTTP application
            this.configuration = configuration;
            this.configuration.DependencyResolver = this.GetExportedValue<IDependencyResolver>();
        }

    }

}
