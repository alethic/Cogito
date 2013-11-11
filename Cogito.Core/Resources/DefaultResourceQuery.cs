using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Resources
{

    /// <summary>
    /// Locates available <see cref="IResource"/>s.
    /// </summary>
    [Export(typeof(IResourceQuery))]
    [Export(typeof(IQueryable<IResource>))]
    public class DefaultResourceQuery :
        EnumerableQuery<IResource>,
        IResourceQuery
    {

        readonly IEnumerable<IResourceProvider> providers;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="providers"></param>
        [ImportingConstructor]
        public DefaultResourceQuery(
            [ImportMany] IEnumerable<IResourceProvider> providers)
            : base(providers.SelectMany(i => i))
        {
            Contract.Requires<ArgumentNullException>(providers != null);
            this.providers = providers;
        }

    }

}
