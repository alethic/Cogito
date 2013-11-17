using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Manages the composition of parts. This class serves as a base implementation of a specicialized version of <see
    /// cref="CompositionContainer"/> which is preconfigured with a dynamic catalog collection and dynamic export
    /// provider collection.
    /// </summary>
    public abstract class CompositionContainerCore :
        System.ComponentModel.Composition.Hosting.CompositionContainer
    {

        public const CompositionOptions DEFAULT_COMPOSITION_OPTIONS =
            CompositionOptions.DisableSilentRejection |
            CompositionOptions.ExportCompositionService |
            CompositionOptions.IsThreadSafe;

        /// <summary>
        /// Gets the parent catalog for the given container.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        static ComposablePartCatalog GetParentCatalog(System.ComponentModel.Composition.Hosting.CompositionContainer container)
        {
            // user catalog is separate in our implementation (exclude filteredCatalog)
            var cogito = container as CompositionContainerCore;
            if (cogito != null)
                return cogito.userCatalog;

            return container.Catalog;
        }

        System.ComponentModel.Composition.Hosting.CompositionContainer parent;
        FilteredCatalog filteredCatalog;
        AggregateCatalog userCatalog;
        FilteredExportProvider filteredProvider;
        AggregateExportProvider userProvider;
        ICompositionContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="catalog"></param>
        /// <param name="provider"></param>
        /// <param name="options"></param>
        /// <param name="importParentCatalog"></param>
        /// <param name="importParent"></param>
        protected CompositionContainerCore(
            System.ComponentModel.Composition.Hosting.CompositionContainer parent = null,
            ComposablePartCatalog catalog = null,
            ExportProvider provider = null,
            CompositionOptions options = DEFAULT_COMPOSITION_OPTIONS,
            bool importParentCatalog = true,
            bool importParent = true)
            : this(
                parent,
                catalogs: catalog != null ? new[] { catalog } : null,
                providers: provider != null ? new[] { provider } : null,
                options: options,
                importParentCatalog: importParentCatalog && parent != null,
                importParent: importParent && parent != null)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="catalogs"></param>
        /// <param name="providers"></param>
        /// <param name="options"></param>
        /// <param name="importParentCatalog"></param>
        /// <param name="importParent"></param>
        protected CompositionContainerCore(
            System.ComponentModel.Composition.Hosting.CompositionContainer parent = null,
            IEnumerable<ComposablePartCatalog> catalogs = null,
            IEnumerable<ExportProvider> providers = null,
            CompositionOptions options = DEFAULT_COMPOSITION_OPTIONS,
            bool importParentCatalog = true,
            bool importParent = true)
            : this(
                parent,
                new AggregateCatalog(
                    new[] { importParentCatalog ? GetParentCatalog(parent) : null }
                        .Concat(catalogs ?? Enumerable.Empty<ComposablePartCatalog>())
                        .Where(i => i != null)),
                new AggregateExportProvider(
                    new[] { importParent ? parent : null }
                        .Concat(providers ?? Enumerable.Empty<ExportProvider>())
                        .Where(i => i != null)),
                options)
        {
            Contract.Requires<ArgumentException>(!(parent == null && importParentCatalog), "Cannot import parent catalog without parent.");
            Contract.Requires<ArgumentException>(!(parent == null && importParent), "Cannot import parent without parent.");

            this.parent = parent;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="catalog"></param>
        /// <param name="options"></param>
        /// <param name="provider"></param>
        CompositionContainerCore(
            System.ComponentModel.Composition.Hosting.CompositionContainer parent,
            AggregateCatalog userCatalog,
            AggregateExportProvider userProvider,
            CompositionOptions options)
            : base(
                new AggregateCatalog(),
                options,
                new AggregateExportProvider())
        {
            Contract.Requires<ArgumentNullException>(userCatalog != null);
            Contract.Requires<ArgumentNullException>(userProvider != null);

            this.parent = parent;
            this.userCatalog = userCatalog;
            this.userProvider = userProvider;
            this.context = this.AsContext();
            this.context.AddExportedValue<ICompositionContext>(this.context);

            // establish filtered components
            this.filteredCatalog = new FilteredCatalog(userCatalog, PartFilter);
            this.filteredProvider = new FilteredExportProvider(userProvider, ExportFilter);
            ((AggregateCatalog)base.Catalog).Catalogs.Add(filteredCatalog);
            ((AggregateExportProvider)base.Providers[0]).Providers.Add(filteredProvider);
        }

        /// <summary>
        /// Set of <see cref="ComposablePartCatalog"/>s provided by the user.
        /// </summary>
        public ICollection<ComposablePartCatalog> Catalogs
        {
            get { return userCatalog.Catalogs; }
        }

        /// <summary>
        /// Set of <see cref="ExportProviders"/> provided by the user.
        /// </summary>
        public new ICollection<ExportProvider> Providers
        {
            get { return userProvider.Providers; }
        }

        /// <summary>
        /// Implements a filter around the available parts. Override this method to implement such things as scope
        /// filters.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        protected virtual bool PartFilter(ComposablePartDefinition definition)
        {
            return true;
        }

        /// <summary>
        /// Implements a filter around the available exports. Override this method to implement such things as scope
        /// filters.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        protected virtual bool ExportFilter(ExportDefinition definition)
        {
            return true;
        }

        /// <summary>
        /// Returns a collection of all exports that match the conditions in the specified <see cref="ImportDefinition"/>.
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="atomicComposition"></param>
        /// <returns></returns>
        protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            return base.GetExportsCore(definition, atomicComposition).ToList();
        }

    }

}
