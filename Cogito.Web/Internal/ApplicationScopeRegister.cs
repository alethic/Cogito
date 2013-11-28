using System.ComponentModel.Composition;
using System.Web;

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
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public ApplicationScopeRegister()
        {

        }

        public ICompositionContext GetScope()
        {
            var ctx = HttpContext.Current;
            if (ctx == null)
                return null;

            return ctx.Application.GetCompositionContext();
        }

        public void RegisterScope(ICompositionContext context)
        {
            var ctx = HttpContext.Current;
            if (ctx == null)
                return;

            ctx.Application.SetCompositionContext(context);
        }

    }

}
