using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading;

using Cogito.Linq;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Retrieves exports provided by a collection of <see cref="ExportProvider" /> objects. Unlike the system provided
    /// export provider, this one supports addition of new export providers at runtime.
    /// </summary>
    public class AggregateExportProvider : ExportProvider, IDisposable
    {

        int disposed;
        ExportProviderCollection providers;

        /// <summary>
        /// Collection of aggregated providers.
        /// </summary>
        public ExportProviderCollection Providers
        {
            get { return providers; }
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AggregateExportProvider()
        {
            providers = new ExportProviderCollection();
            providers.CollectionChanged += providers_CollectionChanged;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="providers"></param>
        public AggregateExportProvider(IEnumerable<ExportProvider> providers)
            : this()
        {
            Contract.Requires<ArgumentNullException>(providers != null);

            this.providers.AddRange(providers);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="providers"></param>
        public AggregateExportProvider(params ExportProvider[] providers)
            : this(providers.Cast<ExportProvider>())
        {
            Contract.Requires<ArgumentNullException>(providers != null);
        }

        /// <summary>
        /// Invoked when an item is added or removed from the providers collection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void providers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            Contract.Requires<ArgumentNullException>(sender != null);
            Contract.Requires<ArgumentNullException>(args != null);

            // unsubscribe from old items
            foreach (var provider in args.OldItems.EmptyIfNull().Cast<ExportProvider>())
            {
                provider.ExportsChanging -= provider_ExportsChanging;
                provider.ExportsChanged -= provider_ExportsChanged;
            }

            // subscribe to new items
            foreach (var provider in args.NewItems.EmptyIfNull().Cast<ExportProvider>())
            {
                provider.ExportsChanging += provider_ExportsChanging;
                provider.ExportsChanged += provider_ExportsChanged;
            }
        }

        void provider_ExportsChanging(object sender, ExportsChangeEventArgs args)
        {
            Contract.Requires<ArgumentNullException>(sender != null);
            Contract.Requires<ArgumentNullException>(args != null);
            OnExportsChanging(args);
        }

        void provider_ExportsChanged(object sender, ExportsChangeEventArgs args)
        {
            Contract.Requires<ArgumentNullException>(sender != null);
            Contract.Requires<ArgumentNullException>(args != null);
            OnExportsChanged(args);
        }

        IEnumerable<Export> GetExportsCoreInternal(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            Contract.Requires<ArgumentNullException>(definition != null);

            foreach (var provider in providers)
                foreach (var export in provider.GetExports(definition, atomicComposition))
                    yield return export;
        }

        protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            return GetExportsCoreInternal(definition, atomicComposition);
        }

        [DebuggerStepThrough]
        void ThrowIfDisposed()
        {
            if (disposed == 1)
                throw new ObjectDisposedException(GetType().FullName);
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Interlocked.CompareExchange(ref disposed, 1, 0) == 0)
                foreach (var provider in providers)
                {
                    provider.ExportsChanging -= provider_ExportsChanging;
                    provider.ExportsChanged -= provider_ExportsChanged;
                }
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

}
