using System;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
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
    public class HttpCompositionContext : CompositionContext
    {

        HttpConfiguration configuration;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="configuration"></param>
        protected internal HttpCompositionContext(
            HttpConfiguration configuration)
            : base()
        {
            Contract.Requires<ArgumentNullException>(configuration != null);

            // configure HTTP application
            this.configuration = configuration;
            this.configuration.DependencyResolver = this.GetExportedValue<IDependencyResolver>();
        }

        protected override ComposablePartCatalog CreateCatalog()
        {
            return new AggregateCatalog(base.CreateCatalog(), new AssemblyCatalog(typeof(HttpCompositionContext).Assembly));
        }

    }

}
