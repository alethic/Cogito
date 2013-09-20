using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Web.Mvc;

using Cogito.Application.Lifecycle;
using Cogito.Web.Mvc;

namespace Cogito.Web.Http.Configuration
{

    [OnBeforeStart(typeof(IMvcApplication))]
    public class DependencyResolverConfiguration : MvcLifecycleComponent
    {

        IDependencyResolver dependencyResolver;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="dependencyResolver"></param>
        [ImportingConstructor]
        public DependencyResolverConfiguration(
            IMvcApplication app,
            IDependencyResolver dependencyResolver)
            : base(app)
        {
            Contract.Requires<ArgumentNullException>(app != null);
            Contract.Requires<ArgumentNullException>(dependencyResolver != null);

            this.dependencyResolver = dependencyResolver;
        }

        public override void OnBeforeStart()
        {
            System.Web.Mvc.DependencyResolver.SetResolver(dependencyResolver);
        }

    }

}
