using System.Web;
using System.Web.Routing;

using Cogito.Application.Lifecycle;
using Cogito.Composition;
using Cogito.Composition.Hosting;
using Cogito.Web.Mvc;

namespace ISIS.HigherGround.Web.Site
{

    public class Global : HttpApplication
    {

        public static readonly ICompositionContext CompositionContext = 
            new DefaultCompositionContainer();

        public static readonly ILifecycleManager<IMvcApplication> MvcLifecycle =
            CompositionContext.GetExportedValue<ILifecycleManager<IMvcApplication>>();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Global()
            : base()
        {
            this.WithMvcComposition(CompositionContext, RouteTable.Routes);
        }

        public void Application_Start()
        {
            MvcLifecycle.Start();
        }

    }

}