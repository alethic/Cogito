using System.Threading;

namespace Cogito.Threading
{

    /// <summary>
    /// <see cref="SynchronizationContext"/> implementation that immediately executes it's tasks.
    /// </summary>
    public class SynchronousSynchronizationContext :
         SynchronizationContext
    {

        public override void Post(SendOrPostCallback d, object state)
        {
            d(state);
        }

        public override void Send(SendOrPostCallback d, object state)
        {
            d(state);
        }

    }

}
