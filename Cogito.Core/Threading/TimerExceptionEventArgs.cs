using System;
using System.Threading;

namespace Cogito.Threading
{

    /// <summary>
    /// Arguments passed when an exception occurs on the timer.
    /// </summary>
    public class TimerExceptionEventArgs :
        ThreadExceptionEventArgs
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public TimerExceptionEventArgs(Exception exception)
            : base(exception)
        {

        }

    }

}
