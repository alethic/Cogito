using System.Web;
using System.Web.Routing;

using Cogito.Application.Lifecycle;
using Cogito.Composition.Hosting;
using Cogito.Web.Mvc;

namespace ISIS.HigherGround.Web.Site
{

    public class Global : HttpApplication
    {

        static readonly DefaultCompositionContainer Container =
            new DefaultCompositionContainer();

        static readonly ILifecycleManager<IMvcApplication> MvcLifecycle =
            Container.GetExportedValue<ILifecycleManager<IMvcApplication>>();

        /// <summary>
        /// Dispatch initialization events as early as possible.
        /// </summary>
        static Global()
        {
            // early initialization
            MvcLifecycle.Init();
        }

        public void Application_Start()
        {
            this.WithMvcComposition(Container, RouteTable.Routes);
            MvcLifecycle.Start();
        }

    }

}