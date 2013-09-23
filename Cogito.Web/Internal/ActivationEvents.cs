using System;

using Cogito.Web.Internal;

using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(ActivationEvents), "OnPreStart")]
[assembly: PostApplicationStartMethod(typeof(ActivationEvents), "OnPostStart")]
[assembly: ApplicationShutdownMethod(typeof(ActivationEvents), "OnShutdown")]

namespace Cogito.Web.Internal
{

    /// <summary>
    /// Raises events signaling state changes in response to the lifetime of the ASP.Net application.
    /// </summary>
    static class ActivationEvents
    {

        public static event EventHandler PreStart;
        public static event EventHandler PostStart;
        public static event EventHandler Shutdown;

        public static bool HasRunPreStart { get; private set; }

        public static bool HasRunPostStart { get; private set; }

        public static bool HasRunShutdown { get; private set; }

        public static void OnPreStart()
        {
            HasRunPreStart = true;

            if (PreStart != null)
                PreStart(null, EventArgs.Empty);
        }

        public static void OnPostStart()
        {
            HasRunPostStart = true;

            if (PostStart != null)
                PostStart(null, EventArgs.Empty);
        }

        public static void OnShutdown()
        {
            HasRunShutdown = true;

            if (Shutdown != null)
                Shutdown(null, EventArgs.Empty);
        }

    }

}
