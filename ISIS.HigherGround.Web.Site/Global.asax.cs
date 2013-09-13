using System;
using System.Web;
using System.Web.Http;

using ISIS.Web.Mvc;

namespace ISIS.HigherGround.Web.Site
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs args)
        {
            GlobalConfiguration.Configuration.RequireComposition()
                .GetExportedValue<IApplicationLifecycleManager>()
                .Start();
        }

    }

}