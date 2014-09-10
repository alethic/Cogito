using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Cogito.Composition.Hosting;

namespace Cogito.Composition.Scoping
{

    [PartMetadata(CompositionConstants.ScopeMetadataKey, typeof(IEveryScope))]
    [Export(typeof(ScopeManager))]
    [ExportMetadata(CompositionConstants.VisibilityMetadataKey, Visibility.Local)]
    public class ScopeTypeResolver :
        IScopeTypeResolver
    {

        readonly IScopeService service;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="service"></param>
        public ScopeTypeResolver(IScopeService service)
        {
            this.service = service;
        }
        
        public object Resolve(Type objectType, Type scopeType)
        {
            return service.Resolve(scopeType).Resolve(objectType);
        }

        public T Resolve<T>(Type scopeType)
        {
            return service.Resolve(scopeType).Resolve<T>();
        }

        public T Resolve<T, TScope>()
        {
            return service.Resolve<TScope>().Resolve<T>();
        }

        public IEnumerable<object> ResolveMany(Type objectType, Type scopeType)
        {
            return service.Resolve(scopeType).ResolveMany(objectType);
        }

        public IEnumerable<T> ResolveMany<T>(Type scopeType)
        {
            return service.Resolve(scopeType).ResolveMany<T>();
        }

        public IEnumerable<T> ResolveMany<T, TScope>()
        {
            return service.Resolve<TScope>().ResolveMany<T>();
        }

    }

}
