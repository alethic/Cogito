using System;
using System.Diagnostics.Contracts;
using System.Threading;

namespace Cogito.Threading
{

    public class QueuedSynchronizationContextTask
    {

        readonly SendOrPostCallback callback;
        readonly object state;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public QueuedSynchronizationContextTask(SendOrPostCallback callback, object state)
        {
            Contract.Requires<ArgumentNullException>(callback != null);

            this.callback = callback;
            this.state = state;
        }

        public SendOrPostCallback Callback
        {
            get { return callback; }
        }

        public object State
        {
            get { return state; }
        }

    }

}
