using System.Web.Http;
using Owin;

namespace Cogito.Fabric.Activities.Test.TestWebService
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance. 
    /// </summary>
    internal sealed class TestWebService : 
        Cogito.Fabric.Http.OwinStatelessService
    {
        
        public TestWebService()
            : base("cogito-activities-test")
        {

        }

        protected override void Configure(global::Owin.IAppBuilder appBuilder)
        {
            var http = new HttpConfiguration();
            http.MapHttpAttributeRoutes();
            appBuilder.UseWebApi(http);
        }

    }

}
