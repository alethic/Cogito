using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public class TaskNativeActivity :
        AsyncNativeActivity
    {

        readonly Func<NativeActivityContext, Task> action;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        public TaskNativeActivity(Func<NativeActivityContext, Task> action)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            this.action = action;
        }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            var tcs = new TaskCompletionSource<bool>(state);
            action(context).ContinueWith(i =>
            {
                if (i.IsFaulted)
                    tcs.TrySetException(i.Exception.InnerExceptions);
                else if (i.IsCanceled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(true);

                // invoke provided callback to signal completion
                if (callback != null)
                    callback(tcs.Task);
            });
            return tcs.Task;
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            try
            {
                ((Task)result).Wait();
            }
            catch (AggregateException e)
            {
                throw e.InnerException;
            }
        }

    }

}
