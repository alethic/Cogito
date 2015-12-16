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

        /// <summary>
        /// Implements an end operation.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static T End(IAsyncResult result)
        {
            return ((CompletedAsyncResult<T>)result).result;
        }

        readonly WaitHandle wh = new ManualResetEvent(true);
        readonly T result;
        readonly AsyncCallback callback;
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
            this.callback = callback;
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
            get { return wh; }
        }

        public bool CompletedSynchronously
        {
            get { return true; }
        }

        public bool IsCompleted
        {
            get { return true; }
        }

        public AsyncCallback AsyncCallback
        {
            get { return callback; }
        }

    }

}
