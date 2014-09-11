using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.UI;

using Cogito.Resources;
using Cogito.Web.UI.Resources;

namespace Cogito.Web.UI
{

    /// <summary>
    /// Web control which manages referenced resources and ensures they are properly rendered in the output.
    /// </summary>
    [ParseChildren(true)]
    public class ResourceManager :
        CogitoControl
    {

        readonly IResourceBundleQuery bundles;
        readonly List<BundleReference> references;
        readonly IEnumerable<IResourceReferencePageInstaller> installers;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ResourceManager()
        {
            this.bundles = TypeResolver.Resolve<IResourceBundleQuery>();
            this.references = new List<BundleReference>();
            this.installers = TypeResolver.ResolveMany<IResourceReferencePageInstaller>();
        }

        /// <summary>
        /// Gets the set of expressions which determine which bundles are referenced.
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<BundleReference> References
        {
            get { return references; }
        }

        ///// <summary>
        ///// Adds the given dependency.
        ///// </summary>
        ///// <param name="dependency"></param>
        //public ResourceManager Requires(Expression<Func<IResourceBundle, bool>> dependency)
        //{
        //    Contract.Requires<ArgumentNullException>(dependency != null);
        //    references.Add(dependency);
        //    return this;
        //}

        ///// <summary>
        ///// Adds the given dependency.
        ///// </summary>
        ///// <param name="bundleId"></param>
        ///// <returns></returns>
        //public ResourceManager Requires(string bundleId)
        //{
        //    Contract.Requires<ArgumentNullException>(bundleId != null);
        //    return Requires(_ => _.Id == bundleId);
        //}

        ///// <summary>
        ///// Adds the given dependency.
        ///// </summary>
        ///// <param name="bundleId"></param>
        ///// <param name="minimumVersion"></param>
        ///// <returns></returns>
        //public ResourceManager Requires(string bundleId, Version minimumVersion)
        //{
        //    Contract.Requires<ArgumentNullException>(bundleId != null);
        //    return minimumVersion != null ? Requires(_ => _.Id == bundleId) : Requires(_ => _.Id == bundleId && _.Version >= minimumVersion);
        //}

        ///// <summary>
        ///// Adds the given dependency.
        ///// </summary>
        ///// <param name="bundleId"></param>
        ///// <param name="minimumVersion"></param>
        ///// <param name="maximumVersion"></param>
        ///// <returns></returns>
        //public ResourceManager Requires(string bundleId, Version minimumVersion, Version maximumVersion)
        //{
        //    Contract.Requires<ArgumentNullException>(bundleId != null);

        //    if (minimumVersion != null && maximumVersion != null)
        //        return Requires(_ => _.Id == bundleId && _.Version >= minimumVersion && _.Version <= maximumVersion);
        //    else if (maximumVersion != null)
        //        return Requires(_ => _.Id == bundleId && _.Version <= maximumVersion);
        //    else if (minimumVersion != null)
        //        return Requires(bundleId, minimumVersion);
        //    else
        //        return Requires(bundleId);
        //}

        /// <summary>
        /// Gets the matching resource.
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public IEnumerable<IResourceBundle> GetResources(BundleReference reference)
        {
            Contract.Requires<ArgumentNullException>(reference != null);

            var resources = bundles.Where(reference.Expression).ToList();
            if (resources.Count == 0)
                throw new ResourceBundleNotFoundException(reference.Expression);

            return resources;
        }

        /// <summary>
        /// Gets the dependent resources that will be included on the page.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IResource> GetResources()
        {
            return References
                .SelectMany(i => GetResources(i))
                .OrderBy(i => i.Id)
                .GroupBy(i => i.Id)
                .Select(i => i.OrderByDescending(j => j.Version).First())
                .SelectMany(i => i)
                .GroupBy(i => i.Name)
                .Select(i => i.OrderByDescending(j => j.Name).First());
        }

        protected override void OnPreRender(EventArgs args)
        {
            base.OnPreRender(args);

            // install each resource into the page, if possible
            foreach (var resource in GetResources())
                Install(resource);
        }

        /// <summary>
        /// Installs the resource into the page.
        /// </summary>
        /// <param name="resource"></param>
        void Install(IResource resource)
        {
            foreach (var installer in installers)
                if (installer.Install(Page, resource))
                    break;
        }

    }

}
