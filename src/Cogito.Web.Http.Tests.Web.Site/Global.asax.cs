using System.Web.Http;

namespace Cogito.Web.Http.Tests.Web.Site
{

    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

    }

}