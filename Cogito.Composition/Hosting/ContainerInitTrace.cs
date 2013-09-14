using System.Diagnostics;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Exists to ensure that the container init functionality is operating.
    /// </summary>
    [OnContainerInit]
    public class ContainerInitTrace : IContainerInit
    {

        public void OnInit()
        {
            Util.Trace.TraceEvent(TraceEventType.Verbose, 2, "ContainerInitTrace");
        }

    }

}
