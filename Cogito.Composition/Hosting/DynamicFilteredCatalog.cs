using System;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Filtered catalog that can have filter sets added to it.
    /// </summary>
    public class DynamicFilteredCatalog : ComposablePartCatalog
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
        /// Gets the part definitions that are contained in the catalog.
        /// </summary>
        public override IQueryable<ComposablePartDefinition> Parts
        {
            get { return aggregate.Parts; }
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
