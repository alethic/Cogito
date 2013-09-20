using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using Cogito.Composition.Internal;

namespace Cogito.Composition
{

    /// <summary>
    /// Provides an abstraction around the MEF composition container, exposing convenience methods to parts. 
    /// </summary>
    public interface ICompositionContext : IDisposable
    {

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

        IEnumerable<System.Lazy<T>> GetExports<T>();

        IEnumerable<System.Lazy<T>> GetExports<T>(string contractName);

        IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>();

        IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(string contractName);

        System.Lazy<T> GetExport<T>();

        System.Lazy<T> GetExport<T>(string contractName);

        System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>();

        System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>(string contractName);

        T GetExportedValue<T>();

        T GetExportedValue<T>(string contractName);

        T GetExportedValueOrDefault<T>();

        T GetExportedValueOrDefault<T>(string contractName);

        IEnumerable<T> GetExportedValues<T>();

        IEnumerable<T> GetExportedValues<T>(string contractName);

        /// <summary>
        /// Creates a new composition scope.
        /// </summary>
        /// <returns></returns>
        ICompositionContext BeginScope();

    }

}
