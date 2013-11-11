using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Cogito.Resources
{

    /// <summary>
    /// Provides <see cref="IResourceBundleProvider"/> exports.
    /// </summary>
    [ResourceBundleProvider]
    public class DefaultResourceBundleProvider :
        EnumerableQuery<IResourceBundle>,
        IResourceBundleProvider
    {

        readonly IEnumerable<IResourceBundle> bundles;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="packages"></param>
        [ImportingConstructor]
        public DefaultResourceBundleProvider(
            [ImportMany] IEnumerable<IResourceBundle> packages)
            : base(packages)
        {
            this.bundles = packages;
        }

    }

}
