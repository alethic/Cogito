using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;

using Cogito.Application.Lifecycle;

namespace Cogito.Web.Http.Dependencies
{

    /// <summary>
    /// Configures the WebApi DependencyResolver.
    /// </summary>
    [OnStart(typeof(IWebApiModule))]
    public class DependencyResolverSetup : WebApiLifecycleListener
    {

        IWebApiModule module;
        IDependencyResolver dependencyResolver;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="dependencyResolver"></param>
        [ImportingConstructor]
        public DependencyResolverSetup(
            IWebApiModule module,
            IDependencyResolver dependencyResolver)
            : base(module)
        {
            Contract.Requires<ArgumentNullException>(module != null);
            Contract.Requires<ArgumentNullException>(dependencyResolver != null);

            this.module = module;
            this.dependencyResolver = dependencyResolver;
        }

        public override void OnStart()
        {
            // set up dependency resolver
            module.Http.DependencyResolver = dependencyResolver;
        }

    }

}
