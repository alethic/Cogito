using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
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

        /// <summary>
        /// Gets the path for the given resource.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static string GetResourcePath(IResource resource)
        {
            Contract.Requires<ArgumentNullException>(resource != null);

            return GetResourcePath(
                resource.Bundle.Id,
                resource.Bundle.Version.ToString(), 
                resource.Name);
        }

        /// <summary>
        /// Gets the path for the given resource properties.
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="version"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetResourcePath(string bundleId, string version, string name)
        {
            return string.Format("/r/{0};{1}/{2}",
                bundleId,
                version,
                name);
        }

        /// <summary>
        /// Gets the path for the given resource properties.
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetResourcePath(string bundleId, string name)
        {
            return string.Format("/r/{0}/{1}",
                bundleId,
                name);
        }

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

            Get["/^(?:(?<Bundle>[^;/]+)(;(?<Version>[^/]+))?/(?<Name>.+))$"] = x => GetResource(
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
