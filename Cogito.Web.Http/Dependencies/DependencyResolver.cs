using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;

using Cogito.Composition;
using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;
using Cogito.Core;

namespace Cogito.Web.Http.Dependencies
{

    [Export(typeof(IDependencyResolver))]
    [Export(typeof(IDependencyScope))]
    public class DependencyResolver :
        IDependencyResolver
    {

        readonly ITypeResolver resolver;
        readonly IScopeService service;
        readonly Ref<CompositionContainer> _ref;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resolver"></param>
        [ImportingConstructor]
        public DependencyResolver(ITypeResolver resolver)
        {
            Contract.Requires<ArgumentNullException>(resolver != null);

            this.resolver = resolver;
            this._ref = resolver.Resolve<Func<Ref<CompositionContainer>>>()();
        }

        public IDependencyScope BeginScope()
        {
            return new DependencyResolver(service.Resolve<IWebRequestScope>());
        }

        public object GetService(Type serviceType)
        {
            return resolver.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return resolver.ResolveMany(serviceType);
        }

        public void Dispose()
        {
            _ref.Dispose();
        }

    }

}
