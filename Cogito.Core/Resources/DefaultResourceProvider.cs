using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Cogito.Resources
{

    /// <summary>
    /// Provides <see cref="IResourcePackage"/> exports.
    /// </summary>
    [ResourceProvider]
    public class DefaultResourceProvider :
        EnumerableQuery<IResource>,
        IResourceProvider
    {

        readonly IEnumerable<IResource> resources;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resources"></param>
        [ImportingConstructor]
        public DefaultResourceProvider(
            [ImportMany] IEnumerable<IResource> resources)
            : base(resources)
        {
            this.resources = resources;
        }

    }

}
