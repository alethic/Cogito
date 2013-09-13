using System;
using System.Diagnostics.Contracts;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace ISIS.Web.Mvc
{

    /// <summary>
    /// Represents a root composition service.
    /// </summary>
    class CompositionManager : CompositionServiceRoot
    {

        HttpConfiguration configuration;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="configuration"></param>
        public CompositionManager(HttpConfiguration configuration)
        {
            Contract.Requires<ArgumentNullException>(configuration != null);

            // configure HTTP application
            this.configuration = configuration;
            this.configuration.DependencyResolver = this.GetExportedValue<IDependencyResolver>();
        }

    }

}
