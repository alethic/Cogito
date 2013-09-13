using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace ISIS.Web.Mvc
{

    /// <summary>
    /// Implements the basics of a composition service.
    /// </summary>
    public abstract class CompositionService : ICompositionService
    {

        CompositionContainer parent;
        CompositionContainer container;
        AggregateCatalog catalog;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CompositionService()
            : this(null)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public CompositionService(CompositionContainer parent)
        {
            this.parent = parent;
            this.container = CreateContainer();
            this.container.ComposeExportedValue<ICompositionService>(this);
        }

        /// <summary>
        /// Creates the container for the service. Default implementation attaches to parent container if it is
        /// available. 
        /// </summary>
        /// <returns></returns>
        protected virtual CompositionContainer CreateContainer()
        {
            return new CompositionContainer(catalog = new AggregateCatalog(new[] { CreateCatalog() }.Where(i => i != null)),
                CompositionOptions.DisableSilentRejection |
                CompositionOptions.ExportCompositionService |
                CompositionOptions.IsThreadSafe, parent != null ? new[] { parent } : null);
        }

        /// <summary>
        /// Creates the catalog for the service. Default implementation attaches to parent catalog if there is one.
        /// </summary>
        /// <returns></returns>
        protected virtual ComposablePartCatalog CreateCatalog()
        {
            return parent != null ? parent.Catalog : null;
        }

        public virtual ICompositionService CreateScope()
        {
            return new CompositionServiceScope(container);
        }

        public void Compose(CompositionBatch batch)
        {
            container.Compose(batch);
        }

        public IEnumerable<Export> GetExports(ImportDefinition definition)
        {
            return container.GetExports(definition);
        }

        public void Register(ComposablePartCatalog catalog)
        {
            this.catalog.Catalogs.Add(catalog);
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            if (container != null)
            {
                container.Dispose();
                container = null;
            }
        }

        /// <summary>
        /// Implements ICompositionService.SatisfyImportsOnce.
        /// </summary>
        /// <param name="part"></param>
        void System.ComponentModel.Composition.ICompositionService.SatisfyImportsOnce(ComposablePart part)
        {
            parent.SatisfyImportsOnce(part);
        }

    }

}
