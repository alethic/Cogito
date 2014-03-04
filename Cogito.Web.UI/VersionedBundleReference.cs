using System;
using System.Linq.Expressions;

using Cogito.Resources;

namespace Cogito.Web.UI
{

    /// <summary>
    /// Referencs a bundle by an ID and version.
    /// </summary>
    public class VersionedBundleReference : 
        BundleReference
    {

        /// <summary>
        /// Builds an expression that filters bundles for the given values.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        static Expression<Func<IResourceBundle, bool>> BuildExpression(string id, string version)
        {
            if (id != null && version != null)
                return i => i.Id == id && i.Version >= version;
            else if (id != null)
                return i => i.Id == id;
            else
                return i => false;
        }

        /// <summary>
        /// Gets or sets the name of the bundle to reference.
        /// </summary>
        public string BundleId { get; set; }

        /// <summary>
        /// Gets or sets the version of the bundle to reference.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets the expression that evaluates a bundle.
        /// </summary>
        public override Expression<Func<IResourceBundle, bool>> Expression
        {
            get { return BuildExpression(BundleId, Version); }
        }

    }

}
