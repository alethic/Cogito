using System;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Implements a <see cref="ScopeCatalog"/> that filters for parts that declare no scope.
    /// </summary>
    public class RootScopeCatalog :
        ScopeCatalog
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public RootScopeCatalog(ComposablePartCatalog parent)
            : base(parent)
        {
            Contract.Requires<ArgumentNullException>(parent != null);
        }

    }

}
