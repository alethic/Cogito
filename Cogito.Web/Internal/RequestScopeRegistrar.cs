using Cogito.Composition;
using Cogito.Composition.Scoping;

namespace Cogito.Web.Internal
{

    /// <summary>
    /// Provides <see cref="IWebRequestScope"/> containers.
    /// </summary>
    public class RequestScopeRegistrar :
        IScopeRegistrar<IWebRequestScope>
    {

        /// <summary>
        /// Gets the existing request context.
        /// </summary>
        /// <returns></returns>
        public ICompositionContext Resolve()
        {
            return WebContainerManager.GetRequestScope();
        }

        /// <summary>
        /// Registers the given composition context.
        /// </summary>
        /// <param name="composition"></param>
        public void RegisterScope(ICompositionContext composition)
        {
            WebContainerManager.RegisterRequestScope(composition);
        }

    }

}
