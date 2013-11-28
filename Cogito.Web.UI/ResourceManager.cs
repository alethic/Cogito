using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;

using Cogito.Linq;
using Cogito.Core.Resources;
using Cogito.Resources;
using Cogito.Web.UI.Resources;

namespace Cogito.Web.UI
{

    /// <summary>
    /// Web control which manages referenced resources and ensures they are properly rendered in the output.
    /// </summary>
    public class ResourceManager :
        CogitoControl
    {

        readonly IResourceBundleQuery bundles;
        readonly List<Expression<Func<IResourceBundle, bool>>> references;
        readonly IEnumerable<IResourceReferencePageInstaller> installers;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ResourceManager()
        {
            this.bundles = Composition.GetExportedValue<IResourceBundleQuery>();
            this.references = new List<Expression<Func<IResourceBundle, bool>>>();
            this.installers = Composition.GetExportedValues<IResourceReferencePageInstaller>();
        }

        /// <summary>
        /// Gets the set of expressions which determine which bundles are referenced.
        /// </summary>
        public IEnumerable<Expression<Func<IResourceBundle, bool>>> References
        {
            get { return references; }
        }

        /// <summary>
        /// Adds the given dependency.
        /// </summary>
        /// <param name="dependency"></param>
        public ResourceManager Requires(Expression<Func<IResourceBundle, bool>> dependency)
        {
            Contract.Requires<ArgumentNullException>(dependency != null);
            references.Add(dependency);
            return this;
        }

        /// <summary>
        /// Adds the given dependency.
        /// </summary>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public ResourceManager Requires(string bundleId)
        {
            Contract.Requires<ArgumentNullException>(bundleId != null);
            return Requires(_ => _.Id == bundleId);
        }

        /// <summary>
        /// Adds the given dependency.
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="minimumVersion"></param>
        /// <returns></returns>
        public ResourceManager Requires(string bundleId, Version minimumVersion)
        {
            Contract.Requires<ArgumentNullException>(bundleId != null);
            return minimumVersion != null ? Requires(_ => _.Id == bundleId) : Requires(_ => _.Id == bundleId && _.Version >= minimumVersion);
        }

        /// <summary>
        /// Adds the given dependency.
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="minimumVersion"></param>
        /// <param name="maximumVersion"></param>
        /// <returns></returns>
        public ResourceManager Requires(string bundleId, Version minimumVersion, Version maximumVersion)
        {
            Contract.Requires<ArgumentNullException>(bundleId != null);

            if (minimumVersion != null && maximumVersion != null)
                return Requires(_ => _.Id == bundleId && _.Version >= minimumVersion && _.Version <= maximumVersion);
            else if (maximumVersion != null)
                return Requires(_ => _.Id == bundleId && _.Version <= maximumVersion);
            else if (minimumVersion != null)
                return Requires(bundleId, minimumVersion);
            else
                return Requires(bundleId);
        }

        /// <summary>
        /// Gets the dependent resources that will be included on the page.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IResource> GetResources()
        {
            foreach (var reference in References)
            {
                foreach (var bundle in bundles.Where(reference))
                {
                    foreach (var resource in bundle)
                    {
                        yield return resource;
                    }
                }
            }
        }

        protected override void OnPreRender(EventArgs args)
        {
            base.OnPreRender(args);

            foreach (var resource in GetResources())
            {
                var installer = installers
                    .FirstOrDefault(i => i.Install(Page, resource));
                if (installer == null)
                    throw new ResourceException("Could not install resource {0}", resource);
            }
        }

    }

}
