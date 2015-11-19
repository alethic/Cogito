using System.Threading;

namespace Cogito.Threading
{

    public class TimerElapsedEventArgs :
        TimerEventArgs
    {

        readonly CancellationToken cancellationToken;


        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public TimerElapsedEventArgs(CancellationToken cancellationToken)
        {
            this.cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Gets the <see cref="CancellationToken"/> which signifies whether the <see cref="Timer"/> has been stopped.
        /// </summary>
        public CancellationToken CancellationToken
        {
            get { return cancellationToken; }
        }

    }

}
