using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using Cogito.Composition.Scoping;
using Cogito.Composition.Services;

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
        readonly Type[] scopes;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="catalog"></param>
        public CompositionContainer(ComposablePartCatalog catalog)
            : base(new AggregateCatalog())
        {
            this.parent = null;
            this.scopes = null;
            this.aggregateCatalog = (AggregateCatalog)base.Catalog;

            // set root catalog and add
            AddCatalog(rootCatalog = catalog);

            // initialize container
            Init();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="scopes"></param>
        public CompositionContainer(CompositionContainer parent, params Type[] scopes)
            : base(new AggregateCatalog(), new FilteredExportProvider(parent, i => ScopeMetadataServices.GetVisibility(i) == Visibility.Inherit))
        {
            this.parent = parent;
            this.scopes = scopes;
            this.aggregateCatalog = (AggregateCatalog)base.Catalog;

            // set root catalog and add
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
            aggregateCatalog.Catalogs.Add(new ScopeCatalog(catalog, scopes));
        }

        /// <summary>
        /// 
        /// </summary>
        void Init()
        {
            // export container reference
            this.ComposeExportedValue<CompositionContainerRef>(new CompositionContainerRef(this));

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
