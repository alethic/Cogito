using System.Web;

using Cogito.Composition;
using Cogito.Composition.Web;
using Cogito.Composition.Scoping;

namespace Cogito.Web.Internal
{

    /// <summary>
    /// Provides <see cref="IWebRequestScope"/> containers.
    /// </summary>
    public class RequestScopeRegistrar : IScopeRegistrar<IWebRequestScope>
    {

        public ICompositionContext GetScope()
        {
            var http = HttpContext.Current;
            if (http != null)
                return http.GetCompositionContext();

            return null;
        }

        public void RegisterScope(ICompositionContext composition)
        {
            var http = HttpContext.Current;
            if (http != null)
                http.SetCompositionContext(composition);
        }

    }

}
