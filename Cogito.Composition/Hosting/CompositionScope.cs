using System;
using System.Diagnostics.Contracts;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Implements a scoped <see cref="CompositionContainer"/>.
    /// </summary>
    class CompositionScope : CompositionContainerCore
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public CompositionScope(CompositionContainerCore parent)
            : base(
                parent: parent,
                catalog: null,
                provider: null)
        {
            Contract.Requires<ArgumentNullException>(parent != null);
        }

    }

}
