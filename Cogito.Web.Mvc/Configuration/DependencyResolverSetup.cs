using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Web.Mvc;

using Cogito.Application.Lifecycle;

namespace Cogito.Web.Mvc
{

    /// <summary>
    /// Configures the MVC dependency resolver.
    /// </summary>
    [OnBeforeStart(typeof(IMvcModule))]
    public class DependencyResolverSetup : MvcLifecycleListener
    {

        IDependencyResolver dependencyResolver;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="dependencyResolver"></param>
        [ImportingConstructor]
        public DependencyResolverSetup(
            IDependencyResolver dependencyResolver)
            : base()
        {
            Contract.Requires<ArgumentNullException>(dependencyResolver != null);

            this.dependencyResolver = dependencyResolver;
        }

        public override void OnBeforeStart()
        {
            System.Web.Mvc.DependencyResolver.SetResolver(dependencyResolver);
        }

    }

}
