using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;

using Cogito.Application.Lifecycle;

namespace Cogito.Web.Http.Configuration
{

    [OnStart(typeof(IApiApplication))]
    public class DependencyResolverConfiguration : ApiLifecycleComponent
    {

        IApiApplication app;
        IDependencyResolver dependencyResolver;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="dependencyResolver"></param>
        [ImportingConstructor]
        public DependencyResolverConfiguration(
            IApiApplication app,
            IDependencyResolver dependencyResolver)
            : base(app)
        {
            Contract.Requires<ArgumentNullException>(app != null);
            Contract.Requires<ArgumentNullException>(dependencyResolver != null);

            this.app = app;
            this.dependencyResolver = dependencyResolver;
        }

        public override void OnStart()
        {
            app.Http.DependencyResolver = dependencyResolver;
        }

    }

}
