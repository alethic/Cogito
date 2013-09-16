using System;

using Cogito.Web.Internal;

using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(ActivationEvents), "OnPreStart")]
[assembly: PostApplicationStartMethod(typeof(ActivationEvents), "OnPostStart")]
[assembly: ApplicationShutdownMethod(typeof(ActivationEvents), "OnShutdown")]

namespace Cogito.Web.Internal
{

    /// <summary>
    /// Raises events signaling state changes.
    /// </summary>
    static class ActivationEvents
    {

        public static event EventHandler PreStart;
        public static event EventHandler PostStart;
        public static event EventHandler Shutdown;

        public static void OnPreStart()
        {
            if (PreStart != null)
                PreStart(null, EventArgs.Empty);
        }

        public static void OnPostStart()
        {
            if (PostStart != null)
                PostStart(null, EventArgs.Empty);
        }

        public static void OnShutdown()
        {
            if (Shutdown != null)
                Shutdown(null, EventArgs.Empty);
        }

    }

}
