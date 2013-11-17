using System.Diagnostics;

using Cogito.Composition.Services;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Exists to ensure that the container init functionality is operating.
    /// </summary>
    [OnInitInvokeAttribute]
    public class ContainerInitTrace : 
        IOnInitInvoke
    {

        public void Invoke()
        {
            Util.Trace.TraceEvent(TraceEventType.Verbose, 2, "ContainerInitTrace");
        }

    }

}
