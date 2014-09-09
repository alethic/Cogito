using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace Cogito.Composition
{

    [Export(typeof(ITypeResolver))]
    public class TypeResolver :
        ITypeResolver
    {

        readonly ICompositionContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="container"></param>
        [ImportingConstructor]
        public TypeResolver(ICompositionContext context)
        {
            this.context = context;
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
            return context.GetExports(new ContractBasedImportDefinition(
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
            return context.GetExports(new ContractBasedImportDefinition(
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
