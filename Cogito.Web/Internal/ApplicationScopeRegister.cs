using Cogito.Composition;
using Cogito.Composition.Scoping;

namespace Cogito.Web.Internal
{

    /// <summary>
    /// Registers the root scope in the Web application.
    /// </summary>
    public class ApplicationScopeRegister :
        IScopeRegistrar<IRootScope>
    {

        /// <summary>
        /// Gets the composition context registered with the web application.
        /// </summary>
        /// <returns></returns>
        public ICompositionContext Resolve()
        {
            return WebContainerManager.GetApplicationScope();
        }

        /// <summary>
        /// Registers the given root scope with the web application.
        /// </summary>
        /// <param name="composition"></param>
        public void RegisterScope(ICompositionContext composition)
        {
            WebContainerManager.RegisterApplicationScope(composition);
        }

    }

}
