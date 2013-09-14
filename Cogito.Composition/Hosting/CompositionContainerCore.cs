using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
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
        System.ComponentModel.Composition.Hosting.CompositionContainer,
        ICompositionContext,
        ICompositionContainerHideMembers
    {

        public const CompositionOptions DEFAULT_COMPOSITION_OPTIONS =
            CompositionOptions.DisableSilentRejection |
            CompositionOptions.ExportCompositionService |
            CompositionOptions.IsThreadSafe;

        System.ComponentModel.Composition.Hosting.CompositionContainer parent;
        AggregateCatalog catalog;
        Cogito.Composition.Hosting.AggregateExportProvider provider;

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
                    new[] { importParentCatalog ? parent.Catalog : null }
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
            AggregateCatalog catalog,
            Cogito.Composition.Hosting.AggregateExportProvider provider,
            CompositionOptions options)
            : base(
                catalog,
                options,
                provider)
        {
            this.parent = parent;
            this.catalog = catalog;
            this.provider = provider;
            this.AddExportedValue<ICompositionContext>(this);

            // allow overrides to begin other actions
            OnInit();
        }

        /// <summary>
        /// Invoked during construction of the container.
        /// </summary>
        protected virtual void OnInit()
        {

        }

        /// <summary>
        /// Collection of <see cref="ComposablePartCatalog"/>s which provide additional parts to this container.
        /// </summary>
        public ICollection<ComposablePartCatalog> Catalogs
        {
            get { return catalog.Catalogs; }
        }

        /// <summary>
        /// Collection of <see cref="ExportProvider"/>s which provide additional exports to this container.
        /// </summary>
        public new ICollection<ExportProvider> Providers
        {
            get { return provider.Providers; }
        }

        /// <summary>
        /// Implements ICompositionService.BeginScope.
        /// </summary>
        /// <returns></returns>
        public virtual ICompositionContext BeginScope()
        {
            return new CompositionScope(this);
        }

        /// <summary>
        /// Executes the composition specified by the given batch.
        /// </summary>
        /// <param name="batch"></param>
        public new void Compose(CompositionBatch batch)
        {
            base.Compose(batch);
        }

        /// <summary>
        /// Searches for the <see cref="Export"/>s which match the specifeid <see cref="ImportDefinition"/>.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        public new IEnumerable<Export> GetExports(ImportDefinition definition)
        {
            return base.GetExports(definition);
        }

        /// <summary>
        /// Returns a collection of all exports that match the conditions in the specified ImportDefinition object.
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="atomicComposition"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition)
        {
            return base.GetExportsCore(definition, atomicComposition);
        }

        /// <summary>
        /// Implements ICompositionService.SatisfyImportsOnce.
        /// </summary>
        /// <param name="part"></param>
        void ICompositionService.SatisfyImportsOnce(ComposablePart part)
        {
            SatisfyImportsOnce(part);
        }

    }

}
