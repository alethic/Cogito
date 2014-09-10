using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using Cogito.Composition.Scoping;
using Cogito.Composition.Services;
using Cogito.Core;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Cogito enhanced <see cref="CompositionContainer"/> that supports scoping.
    /// </summary>
    public class CompositionContainer
        : System.ComponentModel.Composition.Hosting.CompositionContainer
    {

        readonly CompositionContainer parent;
        readonly ComposablePartCatalog rootCatalog;
        readonly AggregateCatalog aggregateCatalog;
        readonly Type scopeType;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="catalog"></param>
        public CompositionContainer(ComposablePartCatalog catalog)
            : base(new AggregateCatalog())
        {
            this.parent = null;
            this.scopeType = null;
            this.aggregateCatalog = (AggregateCatalog)base.Catalog;

            // set root catalog and add
            if (catalog != null)
                AddCatalog(rootCatalog = catalog);

            // initialize container
            Init();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="scopeType"></param>
        public CompositionContainer(CompositionContainer parent, Type scopeType)
            : base(new AggregateCatalog(), new FilteredExportProvider(parent, i => ScopeMetadataServices.GetVisibility(i) == Visibility.Inherit))
        {
            Contract.Requires<ArgumentNullException>(parent != null);

            this.parent = parent;
            this.scopeType = scopeType;
            this.aggregateCatalog = (AggregateCatalog)base.Catalog;

            // set root catalog and add
            if (parent.rootCatalog != null)
                AddCatalog(rootCatalog = parent.rootCatalog);

            // initialize container
            Init();
        }

        /// <summary>
        /// Adds the given catalog to this container, filtered for the supported container scopes.
        /// </summary>
        /// <param name="catalog"></param>
        internal void AddCatalog(ComposablePartCatalog catalog)
        {
            Contract.Requires<ArgumentNullException>(catalog != null);

            aggregateCatalog.Catalogs.Add(new ScopeCatalog(catalog, scopeType));
        }

        /// <summary>
        /// 
        /// </summary>
        void Init()
        {
            // export container reference
            this.ComposeExportedValue<ContainerExport>(new ContainerExport(this));

            // invoke any initialization routines
            foreach (var init in GetExportedValues<IOnInitInvoke>())
                init.Invoke();
        }

        /// <summary>
        /// Releases the resources of the container.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            // invoke any disposal routines
            foreach (var init in GetExportedValues<IOnDisposeInvoke>())
                init.Invoke();

            base.Dispose(disposing);
        }

    }

}
