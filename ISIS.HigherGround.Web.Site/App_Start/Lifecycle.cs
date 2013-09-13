using Cogito.Application;
using Cogito.Composition;

using ISIS.HigherGround.Web.Site;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Lifecycle), "BeforeStart")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Lifecycle), "AfterStart")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Lifecycle), "Shutdown")]

namespace ISIS.HigherGround.Web.Site
{

    /// <summary>
    /// Ensures the application lifecycle manager gets notified on lifecycle state changes.
    /// </summary>
    public static class Lifecycle
    {

        /// <summary>
        /// Gets the composition context registered with ASP.Net.
        /// </summary>
        static ICompositionContext CompositionContext
        {
            get { return Global.CompositionContext; }
        }

        public static void BeforeStart()
        {
            if (CompositionContext != null)
                CompositionContext
                    .GetExportedValue<IApplicationLifecycleManager>()
                    .BeforeStart();
        }

        public static void AfterStart()
        {
            if (CompositionContext != null)
                CompositionContext
                    .GetExportedValue<IApplicationLifecycleManager>()
                    .AfterStart();
        }

        public static void Shutdown()
        {
            if (CompositionContext != null)
                CompositionContext
                    .GetExportedValue<IApplicationLifecycleManager>()
                    .Shutdown();
        }

    }

}