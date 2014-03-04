using System.Linq;
using System.Web.UI;

using Cogito.Composition;

namespace Cogito.Web.UI
{

    /// <summary>
    /// Base Cogito <see cref="System.Web.UI.Control"/> type that provides composition access.
    /// </summary>
    public abstract class CogitoControl :
        Control
    {

        ICompositionContext composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CogitoControl()
        {

        }

        /// <summary>
        /// Gets a reference to the <see cref="ICompositionContext"/> for the current request.
        /// </summary>
        public ICompositionContext Composition
        {
            get { return composition ?? (composition = WebContainerManager.GetOrCreateRequestScope()); }
        }

        /// <summary>
        /// Resolves the URL to reach the target object.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string ResolveUrl(object target)
        {
            if (target is string)
                return base.ResolveUrl((string)target);

            // find first resolved url to target
            return Composition.GetExportedValues<IUrlResolver>()
                .Select(i => i.ResolveUrl(target))
                .FirstOrDefault();
        }

    }

}
