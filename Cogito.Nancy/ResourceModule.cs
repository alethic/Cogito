using System.ComponentModel.Composition;
using System.Linq;

using Cogito.Composition.Scoping;
using Cogito.Composition.Web;
using Cogito.Resources;

using Nancy;

namespace Cogito.Nancy
{

    /// <summary>
    /// Provides access to resource bundles.
    /// </summary>
    [Export(typeof(INancyModule))]
    [PartScope(typeof(IWebRequestScope))]
    public class ResourceModule :
        NancyModule
    {

        readonly IResourceQuery resources;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public ResourceModule(
            IResourceQuery resources)
            : base("/r")
        {
            this.resources = resources;

            Get["{Bundle}/{Version}/{Name*}"] = x => GetResource(
                (string)x.Bundle,
                (string)x.Version,
                (string)x.Name);
        }

        /// <summary>
        /// Gets the resource.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        dynamic GetResource(
            string bundleId,
            string version,
            string name)
        {
            return resources
                .Where(i => i.Bundle.Id == bundleId)
                .Where(i => i.Bundle.Version.ToString().Equals(version))
                .Where(i => i.Name == name);
        }

    }

}
