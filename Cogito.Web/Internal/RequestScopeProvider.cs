using System.Web;

using Cogito.Composition;
using Cogito.Composition.Scoping;

namespace Cogito.Web.Internal
{

    /// <summary>
    /// Provides <see cref="IRequestScope"/> containers.
    /// </summary>
    public class RequestScopeProvider : IScopeContext<IRequestScope>
    {

        public ICompositionContext GetScope()
        {
            var http = HttpContext.Current;
            if (http != null)
                return http.GetCompositionContext();

            return null;
        }

        public ICompositionContext BeginScope()
        {
            return GetScope();
        }

    }

}
