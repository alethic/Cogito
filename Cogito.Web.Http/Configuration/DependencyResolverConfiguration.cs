using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Cogito.Application;

namespace Cogito.Web.Http.Configuration
{

    [Export(typeof(IApplicationStart))]
    public class DependencyResolverConfiguration : ApiLifecycleComponent
    {

        HttpConfiguration configuration;
        IDependencyResolver dependencyResolver;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="dependencyResolver"></param>
        [ImportingConstructor]
        public DependencyResolverConfiguration(
            IApiConfiguration configuration,
            IDependencyResolver dependencyResolver)
            : base(configuration)
        {
            Contract.Requires<ArgumentNullException>(configuration != null);
            Contract.Requires<ArgumentNullException>(dependencyResolver != null);

            this.configuration = configuration != null ? configuration.Configuration : null;
            this.dependencyResolver = dependencyResolver;
        }

        public override void OnStart()
        {
            configuration.DependencyResolver = dependencyResolver;
        }

    }

}
