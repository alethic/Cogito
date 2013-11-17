using System.ComponentModel.Composition;
using System.Linq;

namespace Cogito.Resources
{

    [ResourceProvider]
    public class ResourceBundleResourceProvider :
        EnumerableQuery<IResource>,
        IResourceProvider
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundles"></param>
        [ImportingConstructor]
        public ResourceBundleResourceProvider(
            IResourceBundleQuery bundles)
            : base(bundles.SelectMany(i => i))
        {

        }

    }

}
