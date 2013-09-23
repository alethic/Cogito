using Cogito.Application.Lifecycle;

namespace Cogito.Web.UI.Internal
{

    [OnStart(typeof(IWebModule))]
    public class PageHandlerFactorySetup : WebLifecycleListener
    {

        public override void OnStart()
        {
            
        }

    }

}
