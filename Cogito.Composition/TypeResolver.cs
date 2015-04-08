using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;
using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;

namespace Cogito.Composition
{

    /// <summary>
    /// Default <see cref="ITypeResolver"/> implementation.
    /// </summary>
    [PartMetadata(CompositionConstants.ScopeMetadataKey, typeof(IEveryScope))]
    [Export(typeof(ITypeResolver))]
    [ExportMetadata(CompositionConstants.VisibilityMetadataKey, Visibility.Local)]
    public class TypeResolver :
        ITypeResolver
    {

        readonly IContainerProvider provider;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="provider"></param>
        [ImportingConstructor]
        public TypeResolver(IContainerProvider provider)
        {
            Contract.Requires<ArgumentNullException>(provider != null);

            this.provider = provider;
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            return ResolveMany(type)
                .FirstOrDefault();
        }

        public IEnumerable<T> ResolveMany<T>()
        {
            return ResolveMany(typeof(T))
                .OfType<T>();
        }

        public IEnumerable<object> ResolveMany(Type type)
        {
            return ResolveManyLazy(type)
                .Select(i => i.Value);
        }

        public Lazy<T, IDictionary<string, object>> ResolveLazy<T>()
        {
            return ResolveManyLazy<T>()
                .FirstOrDefault();
        }

        public IEnumerable<Lazy<T, IDictionary<string, object>>> ResolveManyLazy<T>()
        {
            return provider.GetContainer().GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(typeof(T)),
                    AttributedModelServices.GetTypeIdentity(typeof(T)),
                    null,
                    ImportCardinality.ZeroOrMore,
                    false,
                    false,
                    CreationPolicy.Any))
                .Select(i => new Lazy<T, IDictionary<string, object>>(() => (T)i.Value, i.Metadata));
        }

        public Lazy<object, IDictionary<string, object>> ResolveLazy(Type type)
        {
            return ResolveManyLazy(type)
                .FirstOrDefault();
        }

        public IEnumerable<Lazy<object, IDictionary<string, object>>> ResolveManyLazy(Type type)
        {
            return provider.GetContainer().GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(type),
                    AttributedModelServices.GetTypeIdentity(type),
                    null,
                    ImportCardinality.ZeroOrMore,
                    false,
                    false,
                    CreationPolicy.Any))
                .Select(i => new Lazy<object, IDictionary<string, object>>(() => i.Value, i.Metadata));
        }

    }

}
