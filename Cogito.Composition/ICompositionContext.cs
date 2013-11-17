using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;

using Cogito.Composition.Scoping;

namespace Cogito.Composition
{

    [ContractClassFor(typeof(ICompositionContext))]
    abstract class ICompositionContext_Contract : ICompositionContext
    {

        public CompositionContainer AsContainer()
        {
            throw new NotImplementedException();
        }

        public void Compose(CompositionBatch batch)
        {
            Contract.Requires<ArgumentNullException>(batch != null);
            throw new NotImplementedException();
        }

        public IEnumerable<Export> GetExports(ImportDefinition definition)
        {
            Contract.Requires<ArgumentNullException>(definition != null);
            throw new NotImplementedException();
        }

        public IEnumerable<Export> GetExports(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            Contract.Requires<ArgumentNullException>(definition != null);
            Contract.Requires<ArgumentNullException>(atomicComposition != null);
            throw new NotImplementedException();
        }

        public IEnumerable<Lazy<object, object>> GetExports(Type type, Type metadataViewType, string contractName)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(metadataViewType != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

        public IEnumerable<Lazy<T, IDictionary<string, object>>> GetExports<T>()
            where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lazy<T, IDictionary<string, object>>> GetExports<T>(string contractName)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

        public IEnumerable<Lazy<T, IDictionary<string, object>>> GetExports<T>(Type contractType)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            throw new NotImplementedException();
        }

        public IEnumerable<Lazy<T, TMetadataView>> GetExports<T, TMetadataView>()
            where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(string contractName)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

        public IEnumerable<Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(Type contractType)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            throw new NotImplementedException();
        }

        public Lazy<T, IDictionary<string, object>> GetExport<T>()
            where T : class
        {
            throw new NotImplementedException();
        }

        public Lazy<T, IDictionary<string, object>> GetExport<T>(Type contractType)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            throw new NotImplementedException();
        }

        public Lazy<object, IDictionary<string, object>> GetExport(Type contractType)
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            throw new NotImplementedException();
        }

        public Lazy<T, IDictionary<string, object>> GetExport<T>(string contractName)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

        public Lazy<T, TMetadataView> GetExport<T, TMetadataView>()
            where T : class
        {
            throw new NotImplementedException();
        }

        public Lazy<T, TMetadataView> GetExport<T, TMetadataView>(string contractName)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

        public Lazy<T, TMetadataView> GetExport<T, TMetadataView>(Type contractType)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            throw new NotImplementedException();
        }

        public Lazy<object, IDictionary<string, object>> GetExport(string contractName)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

        public T GetExportedValue<T>()
            where T : class
        {
            throw new NotImplementedException();
        }

        public T GetExportedValue<T>(string contractName)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

        public object GetExportedValueOrDefault(Type contractType)
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            throw new NotImplementedException();
        }

        public T GetExportedValueOrDefault<T>()
            where T : class
        {
            throw new NotImplementedException();
        }

        public T GetExportedValueOrDefault<T>(string contractName)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

        public object GetExportedValueOrDefault(Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetExportedValues<T>()
            where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetExportedValues(Type contractType)
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetExportedValues<T>(string contractName)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetExportedValues(Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

        public ICompositionContext ComposeExportedValue<T>(T exportedValue)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(exportedValue != null);
            throw new NotImplementedException();
        }

        public ICompositionContext ComposeExportedValue<T>(string contractName, T exportedValue)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            Contract.Requires<ArgumentNullException>(exportedValue != null);
            throw new NotImplementedException();
        }

        public ICompositionContext ComposeExportedValue(Type contractType, object exportedValue)
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);
            throw new NotImplementedException();
        }

        public ICompositionContext ComposeExportedValue(Type type, string contractName, object exportedValue)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            Contract.Requires<ArgumentNullException>(exportedValue != null);
            throw new NotImplementedException();
        }

        public ICompositionContext AddExportedValue<T>(T exportedValue)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(exportedValue != null);
            throw new NotImplementedException();
        }

        public ICompositionContext AddExportedValue<T>(string contractName, T exportedValue)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            Contract.Requires<ArgumentNullException>(exportedValue != null);
            throw new NotImplementedException();
        }

        public ICompositionContext AddExportedValue(Type contractType, object exportedValue)
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);
            throw new NotImplementedException();
        }

        public ICompositionContext AddExportedValue(string contractName, Type identityType, object exportedValue)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            Contract.Requires<ArgumentNullException>(identityType != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);
            throw new NotImplementedException();
        }

        public ICompositionContext GetOrBeginScope<TScope>()
            where TScope : IScope
        {
            throw new NotImplementedException();
        }

        public ICompositionContext GetOrBeginScope(Type scopeType)
        {
            Contract.Requires<ArgumentNullException>(scopeType != null);
            Contract.Requires<ArgumentException>(typeof(IScope).IsAssignableFrom(scopeType));
            throw new NotImplementedException();
        }

        public ICompositionContext BeginScope<TScope>()
            where TScope : IScope
        {
            throw new NotImplementedException();
        }

        public ICompositionContext BeginScope(Type scopeType)
        {
            Contract.Requires<ArgumentNullException>(scopeType != null);
            Contract.Requires<ArgumentException>(typeof(IScope).IsAssignableFrom(scopeType));
            throw new NotImplementedException();
        }

        public ICompositionContext GetScope<TScope>()
            where TScope : IScope
        {
            throw new NotImplementedException();
        }

        public ICompositionContext GetScope(Type scopeType)
        {
            Contract.Requires<ArgumentNullException>(scopeType != null);
            Contract.Requires<ArgumentException>(typeof(IScope).IsAssignableFrom(scopeType));
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object GetExportedValue(Type contractType)
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            throw new NotImplementedException();
        }

        public object GetExportedValue(Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

        public object GetExportedValue(Type contractType)
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            throw new NotImplementedException();
        }

        public object GetExportedValue(Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(contractName));
            throw new NotImplementedException();
        }

    }

    /// <summary>
    /// Provides an abstraction around the MEF composition container, exposing convenience methods to parts. 
    /// </summary>
    [ContractClass(typeof(ICompositionContext_Contract))]
    public interface ICompositionContext : IDisposable
    {

        /// <summary>
        /// Returns the container that implements the context, if possible.
        /// </summary>
        /// <returns></returns>
        CompositionContainer AsContainer();

        /// <summary>
        /// Executes the given <see cref="CompositionBatch"/> in the service.
        /// </summary>
        /// <param name="batch"></param>
        void Compose(CompositionBatch batch);

        /// <summary>
        /// Queries the <see cref="ICompositionContext"/> for exports which match the specified <see cref="ImportDefinition"/>.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        IEnumerable<Export> GetExports(ImportDefinition definition);

        IEnumerable<Export> GetExports(ImportDefinition definition, AtomicComposition atomicComposition);

        IEnumerable<System.Lazy<object, object>> GetExports(Type type, Type metadataViewType, string contractName);

        IEnumerable<System.Lazy<T, IDictionary<string, object>>> GetExports<T>()
            where T : class;

        IEnumerable<System.Lazy<T, IDictionary<string, object>>> GetExports<T>(string contractName)
            where T : class;

        IEnumerable<System.Lazy<T, IDictionary<string, object>>> GetExports<T>(Type contractType)
            where T : class;

        /// <summary>
        /// Gets the exports for the contract name derived from <typeparamref name="T"/>, returning the metadata view 
        /// <typeparamref name="TMetadataView"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMetadataView"></typeparam>
        /// <returns></returns>
        IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>()
            where T : class;

        /// <summary>
        /// Gets the exports for the contract name, returning the metadata view <typeparamref name="TMetadataView"/>,
        /// that implement <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMetadataView"></typeparam>
        /// <param name="contractName"></param>
        /// <returns></returns>
        IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(string contractName)
            where T : class;

        /// <summary>
        /// Gets the exports for the contract name derived from <paramref name="contractType"/> which are assignable to
        /// <typeparamref name="T"/>, with metadata view <typeparamref name="TMetadataView"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TMetadataView"></typeparam>
        /// <param name="contractType"></param>
        /// <returns></returns>
        IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(Type contractType)
            where T : class;

        System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>()
            where T : class;

        System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>(Type contractType)
            where T : class;

        System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>(string contractName)
            where T : class;

        System.Lazy<T, IDictionary<string, object>> GetExport<T>()
            where T : class;

        System.Lazy<T, IDictionary<string, object>> GetExport<T>(Type contractType)
            where T : class;

        System.Lazy<T, IDictionary<string, object>> GetExport<T>(string contractName)
            where T : class;

        System.Lazy<object, IDictionary<string, object>> GetExport(Type contractType);

        System.Lazy<object, IDictionary<string, object>> GetExport(string contractName);

        T GetExportedValue<T>()
            where T : class;

        T GetExportedValue<T>(string contractName)
            where T : class;

        object GetExportedValue(Type contractType);

        object GetExportedValue(Type type, string contractName);

        T GetExportedValueOrDefault<T>()
            where T : class;

        T GetExportedValueOrDefault<T>(string contractName)
            where T : class;

        object GetExportedValueOrDefault(Type contractType);

        object GetExportedValueOrDefault(Type type, string contractName);

        IEnumerable<T> GetExportedValues<T>()
            where T : class;

        IEnumerable<object> GetExportedValues(Type contractType);

        IEnumerable<T> GetExportedValues<T>(string contractName)
            where T : class;

        IEnumerable<object> GetExportedValues(Type type, string contractName);

        ICompositionContext ComposeExportedValue<T>(T exportedValue)
            where T : class;

        ICompositionContext ComposeExportedValue<T>(string contractName, T exportedValue)
            where T : class;

        ICompositionContext ComposeExportedValue(Type contractType, object exportedValue);

        ICompositionContext ComposeExportedValue(Type type, string contractName, object exportedValue);

        ICompositionContext AddExportedValue<T>(T exportedValue)
            where T : class;

        ICompositionContext AddExportedValue<T>(string contractName, T exportedValue)
            where T : class;

        ICompositionContext AddExportedValue(Type contractType, object exportedValue);

        ICompositionContext AddExportedValue(string contractName, Type identityType, object exportedValue);

        /// <summary>
        /// Gets or begins a scope of the specified type.
        /// </summary>
        /// <typeparam name="TScope"></typeparam>
        /// <returns></returns>
        ICompositionContext GetOrBeginScope<TScope>()
            where TScope : IScope;

        /// <summary>
        /// Gets or begins a scope of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        ICompositionContext GetOrBeginScope(Type scopeType);

        /// <summary>
        /// Begins a new scope of the specified type.
        /// </summary>
        /// <typeparam name="TScope"></typeparam>
        /// <returns></returns>
        ICompositionContext BeginScope<TScope>()
            where TScope : IScope;

        /// <summary>
        /// Begins a new scope of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        ICompositionContext BeginScope(Type scopeType);

        /// <summary>
        /// Gets an existing scope of the specified type.
        /// </summary>
        /// <typeparam name="TScope"></typeparam>
        /// <returns></returns>
        ICompositionContext GetScope<TScope>()
            where TScope : IScope;

        /// <summary>
        /// Gets an existing scope of the specified type.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <returns></returns>
        ICompositionContext GetScope(Type scopeType);

    }

}
