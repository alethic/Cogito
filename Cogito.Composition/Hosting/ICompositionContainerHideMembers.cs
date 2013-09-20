using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace Cogito.Composition.Hosting
{

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICompositionContainerHideMembers
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        ComposablePartCatalog Catalog { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        System.Lazy<T> GetExport<T>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        System.Lazy<T> GetExport<T>(string contractName);

        [EditorBrowsable(EditorBrowsableState.Never)]
        System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>(string contractName);

        [EditorBrowsable(EditorBrowsableState.Never)]
        T GetExportedValue<T>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        T GetExportedValue<T>(string contractName);

        [EditorBrowsable(EditorBrowsableState.Never)]
        T GetExportedValueOrDefault<T>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        T GetExportedValueOrDefault<T>(string contractName);

        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<T> GetExportedValues<T>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<T> GetExportedValues<T>(string contractName);

        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<System.Lazy<T>> GetExports<T>();

        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<Export> GetExports(ImportDefinition definition);

        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<System.Lazy<T>> GetExports<T>(string contractName);

        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(string contractName);

        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<Export> GetExports(ImportDefinition definition, AtomicComposition atomicComposition);

        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<System.Lazy<object, object>> GetExports(Type type, Type metadataViewType, string contractName);

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool TryGetExports(ImportDefinition definition, AtomicComposition atomicComposition, out IEnumerable<Export> exports);

    }

}
