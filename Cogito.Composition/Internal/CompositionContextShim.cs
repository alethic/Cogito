using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using Cogito.Composition.Hosting;

namespace Cogito.Composition.Internal
{

    /// <summary>
    /// Wraps an existing <see cref="CompositionContainer"/> and ensures it implements <see 
    /// cref="ICompositionContext"/>.
    /// </summary>
    class CompositionContextShim : ICompositionContext, ICompositionService
    {

        System.ComponentModel.Composition.Hosting.CompositionContainer container;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="container"></param>
        public CompositionContextShim(System.ComponentModel.Composition.Hosting.CompositionContainer container)
        {
            this.container = container;
        }

        public void Compose(CompositionBatch batch)
        {
            container.Compose(batch);
        }

        public IEnumerable<Export> GetExports(ImportDefinition definition)
        {
            return container.GetExports(definition);
        }

        public IEnumerable<Export> GetExports(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            return container.GetExports(definition, atomicComposition);
        }

        public IEnumerable<System.Lazy<object, object>> GetExports(Type type, Type metadataViewType, string contractName)
        {
            return container.GetExports(type, metadataViewType, contractName);
        }

        public IEnumerable<System.Lazy<T>> GetExports<T>()
        {
            return container.GetExports<T>();
        }

        public IEnumerable<System.Lazy<T>> GetExports<T>(string contractName)
        {
            return container.GetExports<T>(contractName);
        }

        public IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>()
        {
            return container.GetExports<T, TMetadataView>();
        }

        public IEnumerable<System.Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(string contractName)
        {
            return container.GetExports<T, TMetadataView>(contractName);
        }

        public System.Lazy<T> GetExport<T>()
        {
            return container.GetExport<T>();
        }

        public System.Lazy<T> GetExport<T>(string contractName)
        {
            return container.GetExport<T>(contractName);
        }

        public System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>()
        {
            return container.GetExport<T, TMetadataView>();
        }

        public System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>(string contractName)
        {
            return container.GetExport<T, TMetadataView>(contractName);
        }

        public T GetExportedValue<T>()
        {
            return container.GetExportedValue<T>();
        }

        public T GetExportedValue<T>(string contractName)
        {
            return container.GetExportedValue<T>(contractName);
        }

        public T GetExportedValueOrDefault<T>()
        {
            return container.GetExportedValueOrDefault<T>();
        }

        public T GetExportedValueOrDefault<T>(string contractName)
        {
            return container.GetExportedValueOrDefault<T>(contractName);
        }

        public IEnumerable<T> GetExportedValues<T>()
        {
            return container.GetExportedValues<T>();
        }

        public IEnumerable<T> GetExportedValues<T>(string contractName)
        {
            return container.GetExportedValues<T>(contractName);
        }

        public ICompositionContext BeginScope()
        {
            return new CompositionScope(container);
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public void SatisfyImportsOnce(ComposablePart part)
        {
            container.SatisfyImportsOnce(part);
        }
    }

}
