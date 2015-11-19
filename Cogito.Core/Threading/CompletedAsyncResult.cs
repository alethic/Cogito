using System;
using System.Threading;

namespace Cogito.Threading
{

    /// <summary>
    /// <see cref="IAsyncResult"/> implementation that is completed.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CompletedAsyncResult<T> :
        IAsyncResult
    {

        readonly T result;
        readonly object state;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public CompletedAsyncResult(T result, AsyncCallback callback, object state)
        {
            this.result = result;
            this.state = state;
        }

        public T Result
        {
            get { return result; }
        }

        public object AsyncState
        {
            get { return (object)state; }
        }

        public WaitHandle AsyncWaitHandle
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool CompletedSynchronously
        {
            get { return true; }
        }

        public bool IsCompleted
        {
            get { return true; }
        }

    }

}
