using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;

using Cogito.Composition.Hosting;
using Cogito.Composition.Metadata;
using Cogito.Composition.Scoping;

namespace Cogito.Composition.Internal
{

    /// <summary>
    /// Wraps an existing <see cref="CompositionContainer"/> and ensures it implements <see cref="ICompositionContext"/>.
    /// </summary>
    class CompositionContextShim :
        ICompositionContext,
        ICompositionService
    {

        /// <summary>
        /// Cache to map non-generic methods to generic versions.
        /// </summary>
        static readonly ConcurrentDictionary<string, Delegate> cache =
            new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// Underlying <see cref="CompositionContainer"/>.
        /// </summary>
        System.ComponentModel.Composition.Hosting.CompositionContainer container;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="container"></param>
        public CompositionContextShim(System.ComponentModel.Composition.Hosting.CompositionContainer container)
        {
            Contract.Requires<ArgumentNullException>(container != null);

            this.container = container;
        }

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <returns></returns>
        public System.ComponentModel.Composition.Hosting.CompositionContainer AsContainer()
        {
            return container;
        }

        /// <summary>
        /// Satisifies the imports of the specified part.
        /// </summary>
        /// <param name="part"></param>
        public void SatisfyImportsOnce(ComposablePart part)
        {
            container.SatisfyImportsOnce(part);
        }

        /// <summary>
        /// Adds or removes the parts described by the <see cref="CompositionBatch"/>.
        /// </summary>
        /// <param name="batch"></param>
        public void Compose(CompositionBatch batch)
        {
            container.Compose(batch);
        }

        /// <summary>
        /// Gets all exports which match the conditions of the specified <see cref="ImportDefinition"/>.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        public IEnumerable<Export> GetExports(ImportDefinition definition)
        {
            return container.GetExports(definition);
        }

        /// <summary>
        /// Gets all exports which match the conditions of the specified <see cref="ImportDefinition"/>.
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="atomicComposition"></param>
        /// <returns></returns>
        public IEnumerable<Export> GetExports(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            return container.GetExports(definition, atomicComposition);
        }

        /// <summary>
        /// Gets all the exports with the specified contract name derived from the type parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<System.Lazy<T, IDictionary<string, object>>> GetExports<T>()
            where T : class
        {
            return container.GetExports<T, IDictionary<string, object>>();
        }

        /// <summary>
        /// Gets all the exports with the specified contract name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public IEnumerable<System.Lazy<T, IDictionary<string, object>>> GetExports<T>(string contractName)
            where T : class
        {
            return container.GetExports<T, IDictionary<string, object>>(contractName);
        }

        /// <summary>
        /// Gets all the exports with the specified contract name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contractType"></param>
        /// <returns></returns>
        public IEnumerable<System.Lazy<T, IDictionary<string, object>>> GetExports<T>(Type contractType)
            where T : class
        {
            return GetExports<T, IDictionary<string, object>>(contractType);
        }

        /// <summary>
        /// Gets all the exports with the specified contract name derived from the type parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMetadataView"></typeparam>
        /// <returns></returns>
        public IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>()
            where T : class
        {
            return container.GetExports<T, TMetadataView>();
        }

        /// <summary>
        /// Gets all the exports with the specified contract name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMetadataView"></typeparam>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(string contractName)
            where T : class
        {
            return container.GetExports<T, TMetadataView>(contractName);
        }

        /// <summary>
        /// Gets all the exports with the contract name derived from the given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMetadataView"></typeparam>
        /// <param name="contractType"></param>
        /// <returns></returns>
        public IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(Type contractType)
            where T : class
        {
            return container.GetExports(contractType, typeof(TMetadataView), null)
                .Select(i => new System.Lazy<T, TMetadataView>(() => (T)i.Value, (TMetadataView)i.Metadata));
        }

        /// <summary>
        /// Gets all the exports with the specified contract name.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="metadataViewType"></param>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public IEnumerable<System.Lazy<object, object>> GetExports(Type type, Type metadataViewType, string contractName)
        {
            return container.GetExports(type, metadataViewType, contractName);
        }

        /// <summary>
        /// Returns the export with the contract name derived from the type parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public System.Lazy<T, IDictionary<string, object>> GetExport<T>()
            where T : class
        {
            return container.GetExport<T, IDictionary<string, object>>();
        }

        /// <summary>
        /// Returns the export with the specified contract name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public System.Lazy<T, IDictionary<string, object>> GetExport<T>(string contractName)
            where T : class
        {
            return container.GetExport<T, IDictionary<string, object>>(contractName);
        }

        /// <summary>
        /// Returns the export with the contract name derived from the type parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMetadataView"></typeparam>
        /// <returns></returns>
        public System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>()
            where T : class
        {
            return container.GetExport<T, TMetadataView>();
        }

        /// <summary>
        /// Returns the export with the specified contract name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMetadataView"></typeparam>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>(string contractName)
            where T : class
        {
            return container.GetExport<T, TMetadataView>(contractName);
        }

        /// <summary>
        /// Returns the exported object with the contract name derived from the specified type parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetExportedValue<T>()
            where T : class
        {
            return container.GetExportedValue<T>();
        }

        /// <summary>
        /// Returns the exported object with the specified contract name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public T GetExportedValue<T>(string contractName)
            where T : class
        {
            return container.GetExportedValue<T>(contractName);
        }

        /// <summary>
        /// Returns the exported object with the contract name derived from the specified type parameter, or
        /// <c>null</c> if no such object can be found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetExportedValueOrDefault<T>()
            where T : class
        {
            var o = container.GetExportedValueOrDefault<T>();
            return o;
        }

        /// <summary>
        /// Returns the exported objects with the specified contract name, or <c>null</c> if no such object can be
        /// found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public T GetExportedValueOrDefault<T>(string contractName)
            where T : class
        {
            return container.GetExportedValueOrDefault<T>(contractName);
        }

        /// <summary>
        /// Returns the exported objects with the contract name derived from the specified type parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetExportedValues<T>()
            where T : class
        {
            return container.GetExportedValues<T>();
        }

        /// <summary>
        /// Returns the exported objects with the specified contract name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public IEnumerable<T> GetExportedValues<T>(string contractName)
            where T : class
        {
            return container.GetExportedValues<T>(contractName);
        }

        /// <summary>
        /// Adds the value to the container with the contract name derived from the type parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exportedValue"></param>
        /// <returns></returns>
        public ICompositionContext AddExportedValue<T>(T exportedValue)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            var b = new CompositionBatch();
            b.AddExportedValue<T>(exportedValue);
            container.Compose(b);

            return this;
        }

        /// <summary>
        /// Adds the value to the container with the specified contract name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contractName"></param>
        /// <param name="exportedValue"></param>
        /// <returns></returns>
        public ICompositionContext AddExportedValue<T>(string contractName, T exportedValue)
            where T : class
        {
            var b = new CompositionBatch();
            b.AddExportedValue(contractName, exportedValue);
            container.Compose(b);

            return this;
        }

        /// <summary>
        /// Adds the value to the container with the contract name derived from the specified type.
        /// </summary>
        /// <param name="contractType"></param>
        /// <param name="exportedValue"></param>
        /// <returns></returns>
        public ICompositionContext AddExportedValue(Type contractType, object exportedValue)
        {
            var b = new CompositionBatch();
            b.AddExport(new Export(ExportMetadataServices.CreateExportDefinition(contractType), () => exportedValue));
            container.Compose(b);

            return this;
        }

        /// <summary>
        /// Adds the value to the container with the specified contract name.
        /// </summary>
        /// <param name="contractName"></param>
        /// <param name="identityType"></param>
        /// <param name="exportedValue"></param>
        /// <returns></returns>
        public ICompositionContext AddExportedValue(string contractName, Type identityType, object exportedValue)
        {
            var b = new CompositionBatch();
            b.AddExport(new Export(ExportMetadataServices.CreateExportDefinition(contractName, identityType), () => exportedValue));
            container.Compose(b);

            return this;
        }

        /// <summary>
        /// Composes the imports or exports of the specified value, and adds the specified value to the container with
        /// the contract name derived from the type parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exportedValue"></param>
        /// <returns></returns>
        public ICompositionContext ComposeExportedValue<T>(T exportedValue)
            where T : class
        {
            var b = new CompositionBatch();
            b.AddPart(exportedValue);
            container.Compose(b);

            return this;
        }

        /// <summary>
        /// Composes the imports or exports of the specified value, and adds the specified value to the container with
        /// the specified contract name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contractName"></param>
        /// <param name="exportedValue"></param>
        /// <returns></returns>
        public ICompositionContext ComposeExportedValue<T>(string contractName, T exportedValue)
            where T : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Composes the imports or exports of the specified value, and adds the specified value to the container with
        /// the contract name derived from the specified type.
        /// </summary>
        /// <param name="contractType"></param>
        /// <param name="exportedValue"></param>
        /// <returns></returns>
        public ICompositionContext ComposeExportedValue(Type contractType, object exportedValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Composes the imports or exports of the specified value, and adds the specified value to the container with
        /// the specified contract name.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="contractName"></param>
        /// <param name="exportedValue"></param>
        /// <returns></returns>
        public ICompositionContext ComposeExportedValue(Type type, string contractName, object exportedValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the exported value for the contract name derived from the specified type.
        /// </summary>
        /// <param name="contractType"></param>
        /// <returns></returns>
        public object GetExportedValue(Type contractType)
        {
            var p1 = Expression.Parameter(typeof(CompositionContextShim));
            var lm = Expression.Lambda(
                Expression.Call(
                    typeof(CompositionContextShim),
                    "GetExportedValue",
                    new[] { contractType },
                    p1),
                p1);

            return cache.GetOrAdd(
                    string.Format("GetExportedValue({0})", AttributedModelServices.GetContractName(contractType)),
                    _ => lm.Compile())
                .DynamicInvoke(this);
        }

        /// <summary>
        /// Gets the exported value for the specified contract name.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public object GetExportedValue(Type type, string contractName)
        {
            var p1 = Expression.Parameter(typeof(CompositionContextShim));
            var p2 = Expression.Parameter(typeof(string));
            var lm = Expression.Lambda(
                Expression.Call(
                    typeof(CompositionContextShim),
                    "GetExportedValue",
                    new[] { type },
                    p1, p2),
                p1, p2);

            return cache.GetOrAdd(
                    string.Format("GetExportedValue({0},{1})", contractName, AttributedModelServices.GetContractName(type)),
                    _ => lm.Compile())
                .DynamicInvoke(this);
        }

        /// <summary>
        /// Gets the exported value, or <c>null</c>, for the contract name derived from the specified type.
        /// </summary>
        /// <param name="contractType"></param>
        /// <returns></returns>
        public object GetExportedValueOrDefault(Type contractType)
        {
            var p1 = Expression.Parameter(typeof(CompositionContextShim));
            var lm = Expression.Lambda(
                Expression.Call(
                    p1,
                    "GetExportedValueOrDefault",
                    new[] { contractType }),
                p1);

            return cache.GetOrAdd(
                    string.Format("GetExportedValueOrDefault({0})", AttributedModelServices.GetContractName(contractType)),
                    _ => lm.Compile())
                .DynamicInvoke(this);
        }

        /// <summary>
        /// Gets the exported value for the specified contract name, or <c>null</c>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public object GetExportedValueOrDefault(Type type, string contractName)
        {
            var p1 = Expression.Parameter(typeof(CompositionContextShim));
            var p2 = Expression.Parameter(typeof(string));
            var lm = Expression.Lambda(
                Expression.Call(
                    typeof(CompositionContextShim),
                    "GetExportedValueOrDefault",
                    new[] { type },
                    p1, p2),
                p1, p2);

            return cache.GetOrAdd(
                    string.Format("GetExportedValueOrDefault({0},{1})", contractName, AttributedModelServices.GetContractName(type)),
                    _ => lm.Compile())
                .DynamicInvoke(this);
        }

        /// <summary>
        /// Gets the exported values for the contract name derived from the specified type.
        /// </summary>
        /// <param name="contractType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetExportedValues(Type contractType)
        {
            var p1 = Expression.Parameter(typeof(CompositionContextShim));
            var lm = Expression.Lambda(
                Expression.Call(
                    p1,
                    "GetExportedValues",
                    new[] { contractType }),
                p1);

            return (IEnumerable<object>)cache.GetOrAdd(
                    string.Format("GetExportedValues({0})", AttributedModelServices.GetContractName(contractType)),
                    _ => lm.Compile())
                .DynamicInvoke(this);
        }

        /// <summary>
        /// Gets the exported values for the specified contract name.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public IEnumerable<object> GetExportedValues(Type type, string contractName)
        {
            var p1 = Expression.Parameter(typeof(CompositionContextShim));
            var p2 = Expression.Parameter(typeof(string));
            var lm = Expression.Lambda(
                Expression.Call(
                    p1,
                    "GetExportedValues",
                    new[] { type },
                    new[] { p2 }),
                p1, p2);

            return (IEnumerable<object>)cache.GetOrAdd(
                    string.Format("GetExportedValues({0})", AttributedModelServices.GetTypeIdentity(type)),
                    _ => lm.Compile())
                .DynamicInvoke(this, contractName);
        }

        /// <summary>
        /// Gets the export for the contract name derived from the specified type.
        /// </summary>
        /// <param name="contractType"></param>
        /// <returns></returns>
        public System.Lazy<object, IDictionary<string, object>> GetExport(Type contractType)
        {
            var p1 = Expression.Parameter(typeof(CompositionContextShim));
            var lm = Expression.Lambda(
                Expression.Call(
                    p1,
                    "GetExport",
                    new[] { contractType }),
                p1);

            var lz = cache.GetOrAdd(
                    string.Format("GetExport({0})", AttributedModelServices.GetContractName(contractType)),
                    _ => lm.Compile())
                .DynamicInvoke(this);

            return new System.Lazy<object, IDictionary<string, object>>(() =>
                (object)((dynamic)lz).Value,
                (IDictionary<string, object>)((dynamic)lz).Metadata);
        }

        /// <summary>
        /// Gets the export for the specified contract name.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public System.Lazy<object, IDictionary<string, object>> GetExport(Type type, string contractName)
        {
            throw new NotImplementedException();
        }

        public System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>(Type contractType)
            where T : class
        {
            return GetExport<T, TMetadataView>(AttributedModelServices.GetContractName(contractType));
        }

        public System.Lazy<T, IDictionary<string, object>> GetExport<T>(Type contractType)
            where T : class
        {
            return GetExport<T, IDictionary<string, object>>(AttributedModelServices.GetContractName(contractType));
        }

        public System.Lazy<object, IDictionary<string, object>> GetExport(string contractName)
        {
            return GetExport<object, IDictionary<string, object>>(contractName);
        }

        /// <summary>
        /// Gets the exports for the contract name derived from the specified type.
        /// </summary>
        /// <param name="contractType"></param>
        /// <returns></returns>
        public IEnumerable<System.Lazy<object, IDictionary<string, object>>> GetExports(Type contractType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the exports for the specifed contract name.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="contractName"></param>
        /// <returns></returns>
        public IEnumerable<System.Lazy<object, IDictionary<string, object>>> GetExports(Type type, string contractName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Begins a new composition scope of the specified type.
        /// </summary>
        /// <typeparam name="TScope"></typeparam>
        /// <returns></returns>
        public ICompositionContext GetOrBeginScope<TScope>()
            where TScope : IScope
        {
            return GetOrBeginScope(typeof(TScope));
        }

        /// <summary>
        /// Begins a new composition scope of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        public ICompositionContext GetOrBeginScope(Type scopeType)
        {
            return GetExportedValue<ScopeProvider>().GetOrBeginScope(scopeType);
        }

        /// <summary>
        /// Begins a new composition scope of the specified type.
        /// </summary>
        /// <typeparam name="TScope"></typeparam>
        /// <returns></returns>
        public ICompositionContext BeginScope<TScope>()
            where TScope : IScope
        {
            return BeginScope(typeof(IScope));
        }

        /// <summary>
        /// Begins a new composition scope of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        public ICompositionContext BeginScope(Type scopeType)
        {
            return GetExportedValue<ScopeProvider>().BeginScope(scopeType);
        }

        /// <summary>
        /// Gets or begins a composition scope of the specified type.
        /// </summary>
        /// <typeparam name="TScope"></typeparam>
        /// <returns></returns>
        public ICompositionContext GetScope<TScope>()
            where TScope : IScope
        {
            return GetScope(typeof(TScope));
        }

        /// <summary>
        /// Gets or begins a composition scope of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        public ICompositionContext GetScope(Type scopeType)
        {
            return GetExportedValue<ScopeProvider>().GetScope(scopeType);
        }

        /// <summary>
        /// Creates a composition scope of the specified type.
        /// </summary>
        /// <typeparam name="TScope"></typeparam>
        /// <returns></returns>
        public ICompositionContext CreateScope<TScope>()
            where TScope : IScope
        {
            return CreateScope(typeof(TScope));
        }

        /// <summary>
        /// Creates a composition scope of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        public ICompositionContext CreateScope(Type scopeType)
        {
            return CompositionScope.CreateScope(container, scopeType).AsContext();
        }

        /// <summary>
        /// Disposes of the context.
        /// </summary>
        public void Dispose()
        {
            container.Dispose();
        }

    }

}
