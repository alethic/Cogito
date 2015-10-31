using System;
using System.Threading;

namespace Cogito.Threading
{

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
