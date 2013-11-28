using System.Web.UI;

using Cogito.Composition;
using Cogito.Composition.Web;

namespace Cogito.Web.UI
{

    /// <summary>
    /// Base Cogito <see cref="System.Web.UI.Control"/> type that provides composition access.
    /// </summary>
    public abstract class CogitoControl
        : Control
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
            get { return composition ?? (composition = Context.Application.GetCompositionContext().GetOrBeginScope<IWebRequestScope>()); }
        }

    }

}
