using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace Cogito.Web.Http.Tests.Web.Site
{

    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.Services.Add(typeof(ValueProviderFactory), new HeaderValueProviderFactory());
            config.MapHttpAttributeRoutes();
        }

    }

}
