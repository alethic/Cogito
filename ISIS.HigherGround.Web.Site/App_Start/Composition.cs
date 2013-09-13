using System.ComponentModel.Composition.Hosting;
using System.Web.Http;
using ISIS.HigherGround.Web.Site.App_Start;
using ISIS.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Composition), "PreStart")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Composition), "PostStart")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Composition), "Shutdown")]
namespace ISIS.HigherGround.Web.Site.App_Start
{

    public static class Composition
    {

        public static void PreStart()
        {
            GlobalConfiguration.Configuration.RequireComposition()
                .Register(new AssemblyCatalog(typeof(Composition).Assembly));

            GlobalConfiguration.Configuration.RequireComposition()
                .GetExportedValue<IApplicationLifecycleManager>()
                .PreStart();
        }

        public static void PostStart()
        {
            GlobalConfiguration.Configuration.RequireComposition()
                .GetExportedValue<IApplicationLifecycleManager>()
                .PostStart();
        }

        public static void Shutdown()
        {
            GlobalConfiguration.Configuration.RequireComposition()
                .GetExportedValue<IApplicationLifecycleManager>()
                .Shutdown();
        }

    }

}