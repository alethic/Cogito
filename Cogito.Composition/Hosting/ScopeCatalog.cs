using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Filters the underlying catalog for exports available in the specified scope.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    public class ScopeCatalog<TScope> :
        ComposablePartCatalog
    {

        readonly ComposablePartCatalog parent;
        readonly HashSet<Type> scopes;
        readonly HashSet<string> identities;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public ScopeCatalog(ComposablePartCatalog parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Gets the part definitions that are contained in the catalog.
        /// </summary>
        public override IQueryable<ComposablePartDefinition> Parts
        {
            get { return GetParts(); }
        }

        /// <summary>
        /// Implements the retrieval of parts from this catalog.
        /// </summary>
        /// <returns></returns>
        IQueryable<ComposablePartDefinition> GetParts()
        {
            return parent.Parts
                .Select(i => new ScopedPartDefinition(i));
        }

    }

}
