using System;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Filtered catalog that can have filter sets added to it.
    /// </summary>
    public class DynamicFilteredCatalog :
        ComposablePartCatalog,
        INotifyComposablePartCatalogChanged
    {

        AggregateCatalog aggregate;
        FilteredCatalog filter;

        /// <summary>
        /// Initializes a new instance. By default no instances from <paramref name="source"/> are exposed.
        /// </summary>
        /// <param name="source"></param>
        public DynamicFilteredCatalog(ComposablePartCatalog source)
        {
            aggregate = new AggregateCatalog(filter = source.Filter(i => false));
            aggregate.Changing += aggregate_Changing;
            aggregate.Changed += aggregate_Changed;
        }

        void aggregate_Changing(object sender, ComposablePartCatalogChangeEventArgs args)
        {
            OnChanging(args);
        }

        void aggregate_Changed(object sender, ComposablePartCatalogChangeEventArgs args)
        {
            OnChanged(args);
        }

        /// <summary>
        /// Adds a predicate condition that exposes additional instances from the source.
        /// </summary>
        /// <param name="predicate"></param>
        public void Or(Func<ComposablePartDefinition, bool> predicate)
        {
            // filter remainder of previous filter
            aggregate.Catalogs.Add(filter = filter.Complement.Filter(i => predicate(i)));
        }

        /// <summary>
        /// Raised when the composable parts are changing.
        /// </summary>
        public event EventHandler<ComposablePartCatalogChangeEventArgs> Changing;

        /// <summary>
        /// Raises Changing.
        /// </summary>
        /// <param name="args"></param>
        void OnChanging(ComposablePartCatalogChangeEventArgs args)
        {
            if (Changing != null)
                Changing(this, args);
        }

        /// <summary>
        /// Gets the part definitions that are contained in the catalog.
        /// </summary>
        public override IQueryable<ComposablePartDefinition> Parts
        {
            get { return aggregate.Parts; }
        }

        /// <summary>
        /// Raised when the composable parts are changing.
        /// </summary>
        public event EventHandler<ComposablePartCatalogChangeEventArgs> Changed;

        /// <summary>
        /// Raises Changed.
        /// </summary>
        /// <param name="args"></param>
        void OnChanged(ComposablePartCatalogChangeEventArgs args)
        {
            if (Changed != null)
                Changed(this, args);
        }


        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (filter != null)
            {
                filter.Dispose();
                filter = null;
            }

            if (aggregate != null)
            {
                aggregate.Dispose();
                aggregate = null;
            }
        }

    }

}
