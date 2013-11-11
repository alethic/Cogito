using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Resources
{

    /// <summary>
    /// Locates available <see cref="IResourceBundle"/>s.
    /// </summary>
    [Export(typeof(IResourceBundleQuery))]
    [Export(typeof(IQueryable<IResourceBundle>))]
    public class DefaultResourceBundleQuery :
        EnumerableQuery<IResourceBundle>,
        IResourceBundleQuery
    {

        readonly IEnumerable<IResourceBundleProvider> providers;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="providers"></param>
        [ImportingConstructor]
        public DefaultResourceBundleQuery(
            [ImportMany] IEnumerable<IResourceBundleProvider> providers)
            : base(providers.SelectMany(i => i))
        {
            Contract.Requires<ArgumentNullException>(providers != null);

            this.providers = providers;
        }

    }

}
