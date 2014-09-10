using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Cogito.Composition.Hosting;
using Cogito.Core;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Local-scope manager available to every scope.
    /// </summary>
    [PartMetadata(CompositionConstants.ScopeMetadataKey, typeof(IEveryScope))]
    [Export(typeof(ScopeManager))]
    [ExportMetadata(CompositionConstants.VisibilityMetadataKey, Visibility.Local)]
    public class ScopeService :
        IScopeService
    {

        public Func<CompositionContainer> container;
        public IEnumerable<IScopeProvider> registrars;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="registrars"></param>
        [ImportingConstructor]
        public ScopeService(
            Func<CompositionContainer> container,
            [ImportMany] IEnumerable<IScopeProvider> registrars)
        {
            this.container = container;
            this.registrars = registrars;
        }

        public ITypeResolver Resolve(Type scopeType)
        {
            // find existing resolver
            var scope = registrars.Select(i => i.Resolve(scopeType)).FirstOrDefault(i => i != null);
            if (scope != null)
                return scope.GetExportedValue<ITypeResolver>();

            return Create(scopeType);
        }

        ITypeResolver Create(Type scopeType)
        {
            // generate new container and obtain resolver
            var scope = new CompositionContainer(container(), scopeType);
            if (scope == null)
                throw new NullReferenceException("Generated scope container does not contain ITypeResolver.");

            // register new container
            foreach (var registrar in registrars)
                registrar.Register(scopeType, scope);

            // return new resolver
            return scope.GetExportedValue<ITypeResolver>();
        }

        public ITypeResolver Resolve<T>()
        {
            return Resolve(typeof(T));
        }

    }

}
