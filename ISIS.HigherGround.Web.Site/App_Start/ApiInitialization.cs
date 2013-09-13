using System.ComponentModel.Composition;
using System.Web.Http;

using Cogito.Application;
using Cogito.Web.Http;

namespace ISIS.HigherGround.Web.Site.App_Start
{

    [Export(typeof(IApplicationBeforeStart))]
    public class ApiInitialization : IApplicationBeforeStart
    {

        public void OnBeforeStart()
        {
            GlobalConfiguration.Configuration
                .WithApiComposition(Global.CompositionContext);
        }
    }

}