using Owin;

namespace Cogito.Nancy.Web.UI.Tests.Site
{

    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.UseNancy(_ => _.Bootstrapper = new NancyBootstrapper());
        }

    }

}