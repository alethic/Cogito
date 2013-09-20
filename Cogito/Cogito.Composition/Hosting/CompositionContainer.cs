using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Manages the composition of parts. This class serves as an implementation of a specicialized version of <see
    /// cref="CompositionContainer"/> which is preconfigured with a dynamic catalog collection, dynamic export provider
    /// collection and simplified support for begining a new scope.
    /// </summary>
    public class CompositionContainer : CompositionContainerCore
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CompositionContainer()
            : this(
                parent: null,
                catalog: new AssemblyCatalog(typeof(CompositionContainer).Assembly),
                provider: null)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CompositionContainer(
            System.ComponentModel.Composition.Hosting.CompositionContainer parent)
            : this(
                parent: parent,
                catalog: null,
                provider: null)
        {
            Contract.Requires<ArgumentNullException>(parent != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CompositionContainer(
            System.ComponentModel.Composition.Hosting.CompositionContainer parent = null,
            IEnumerable<ComposablePartCatalog> catalogs = null,
            IEnumerable<ExportProvider> providers = null,
            CompositionOptions options = DEFAULT_COMPOSITION_OPTIONS,
            bool importParentCatalog = true,
            bool importParent = true)
            : base(
                parent,
                catalogs: catalogs,
                providers: providers,
                options: options,
                importParentCatalog: importParentCatalog && parent != null,
                importParent: importParent && parent != null)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="catalog"></param>
        /// <param name="provider"></param>
        /// <param name="options"></param>
        /// <param name="importParentCatalog"></param>
        /// <param name="importParent"></param>
        protected CompositionContainer(
            System.ComponentModel.Composition.Hosting.CompositionContainer parent = null,
            ComposablePartCatalog catalog = null,
            ExportProvider provider = null,
            CompositionOptions options = DEFAULT_COMPOSITION_OPTIONS,
            bool importParentCatalog = true,
            bool importParent = true)
            : base(
                parent,
                catalogs: catalog != null ? new[] { catalog } : null,
                providers: provider != null ? new[] { provider } : null,
                options: options,
                importParentCatalog: importParentCatalog && parent != null,
                importParent: importParent && parent != null)
        {

        }

        protected override void OnInit()
        {
            // initiate init events
            this.BeginInit();
        }

    }

}
