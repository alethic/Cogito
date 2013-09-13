using System.ComponentModel.Composition.Hosting;

using Cogito.Application;
using Cogito.Composition;

using ISIS.HigherGround.Web.Site.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Composition), "BeforeStart")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Composition), "AfterStart")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Composition), "Shutdown")]
namespace ISIS.HigherGround.Web.Site.App_Start
{

    public static class Composition
    {

        public static void BeforeStart()
        {
            Global.GetCompositionContext()
                .Register(new AssemblyCatalog(typeof(Composition).Assembly));

            Global.GetCompositionContext()
                .GetExportedValue<IApplicationLifecycleManager>()
                .BeforeStart();
        }

        public static void AfterStart()
        {
            Global.GetCompositionContext()
                .GetExportedValue<IApplicationLifecycleManager>()
                .AfterStart();
        }

        public static void Shutdown()
        {
            Global.GetCompositionContext()
                .GetExportedValue<IApplicationLifecycleManager>()
                .Shutdown();
        }

    }

}