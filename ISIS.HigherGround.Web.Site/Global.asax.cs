using System.Web;
using System.Web.Http;
using Cogito.Application;
using Cogito.Composition.Hosting;
using Cogito.Web;
using Cogito.Web.Http;
using Cogito.Web.Mvc;

using ISIS.HigherGround.Web.Site;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Global), "BeforeStart")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Global), "AfterStart")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Global), "Shutdown")]

namespace ISIS.HigherGround.Web.Site
{

    public class Global : HttpApplication
    {

        static readonly DefaultCompositionContainer Container =
            new DefaultCompositionContainer();

        static readonly IApplicationLifecycleManager Lifecycle =
            Container.GetExportedValue<IApplicationLifecycleManager>();

        public static void BeforeStart()
        {
            Lifecycle.BeforeStart();
        }

        public static void Start()
        {
            Lifecycle.Start();
        }

        public static void AfterStart()
        {
            Lifecycle.AfterStart();
        }

        public static void Shutdown()
        {
            Lifecycle.Shutdown();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Global()
            : base()
        {
            // configure MVC with container
        }

        public void Application_Start()
        {
            this
                .WithComposition(Container)
                .WithMvcComposition(Container);

            GlobalConfiguration.Configuration
                .WithApiComposition(Container);

            Start();
        }

    }

}