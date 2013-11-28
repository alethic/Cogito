using System.ComponentModel.Composition;
using System.Web;

using Cogito.Composition;
using Cogito.Composition.Services;

namespace Cogito.Web.Internal
{

    [OnInitInvoke]
    public class ApplicationScopeInit :
        IOnInitInvoke
    {

        readonly ICompositionContext composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        [ImportingConstructor]
        public ApplicationScopeInit(
            ICompositionContext composition)
        {
            this.composition = composition;
        }

        public void Invoke()
        {
            var ctx = HttpContext.Current;
            if (ctx == null)
                return;

            ctx.Application.SetCompositionContext(composition);
        }

    }

}
