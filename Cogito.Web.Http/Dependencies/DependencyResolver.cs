using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;

using Cogito.Composition;
using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;

namespace Cogito.Web.Http.Dependencies
{

    [Export(typeof(IDependencyResolver))]
    [Export(typeof(IDependencyScope))]
    [PartMetadata(CompositionConstants.ScopeMetadataKey, typeof(IEveryScope))]
    [ExportMetadata(CompositionConstants.VisibilityMetadataKey, Visibility.Local)]
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
        public DependencyResolver(
            ITypeResolver resolver,
            IScopeService service)
        {
            Contract.Requires<ArgumentNullException>(resolver != null);
            Contract.Requires<ArgumentNullException>(service != null);

            this.resolver = resolver;
            this.service = service;
            this._ref = resolver.Resolve<IContainerProvider>().GetContainerRef();
        }

        public IDependencyScope BeginScope()
        {
            return service.Resolve<IWebRequestScope>().Resolve<IDependencyResolver>();
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
