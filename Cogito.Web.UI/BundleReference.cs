using System;
using System.Linq.Expressions;

using Cogito.Resources;

namespace Cogito.Web.UI
{

    /// <summary>
    /// Describes a reference to a bundle.
    /// </summary>
    public abstract class BundleReference
    {

        /// <summary>
        /// Gets the expression that filters for resource bundle.
        /// </summary>
        public abstract Expression<Func<IResourceBundle, bool>> Expression { get; }

    }

}
