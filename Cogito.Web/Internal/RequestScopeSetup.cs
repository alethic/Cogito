using Cogito.Application.Lifecycle;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace Cogito.Web.Internal
{

    [OnBeforeStart(typeof(IWebModule))]
    public class RequestScopeSetup : WebLifecycleListener
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public RequestScopeSetup()
        {

        }

        public override void OnBeforeStart()
        {
            //DynamicModuleUtility.RegisterModule(typeof(RequestScopeModule));
        }

    }

}
