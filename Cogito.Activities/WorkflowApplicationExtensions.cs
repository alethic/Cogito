using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    /// <summary>
    /// Various extension methods for working with a <see cref="WorkflowApplication"/>.
    /// </summary>
    public static class WorkflowApplicationExtensions
    {

        /// <summary>
        /// Starts or resumes a workflow instance asynchronously.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public static Task LoadAsync(this WorkflowApplication self, Guid instanceId)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            return Task.Factory.FromAsync(self.BeginLoad, self.EndLoad, instanceId, null);
        }

        /// <summary>
        /// Starts or resumes a workflow instance asynchronously.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Task RunAsync(this WorkflowApplication self)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            return Task.Factory.FromAsync(self.BeginRun, self.EndRun, null);
        }

        /// <summary>
        /// Initiates an asynchronous operation to resume the bookmark with the specified name, using the specified
        /// value, callback method, and state. The bookmark to be resumed is previously created by an activity within
        /// the workflow instance.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Task ResumeBookmarkAsync(this WorkflowApplication self, Bookmark bookmark, object value)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(bookmark != null);

            return Task.Factory.FromAsync(self.BeginResumeBookmark, self.EndResumeBookmark, bookmark, value, null);
        }

        /// <summary>
        /// Initiates an asynchronous operation to resume the bookmark with the specified name, using the specified
        /// value, callback method, and state. The bookmark to be resumed is previously created by an activity within
        /// the workflow instance.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="bookmarkName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Task ResumeBookmarkAsync(this WorkflowApplication self, string bookmarkName, object value)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(bookmarkName != null);

            return Task.Factory.FromAsync(self.BeginResumeBookmark, self.EndResumeBookmark, bookmarkName, value, null);
        }

        /// <summary>
        /// Initiates an asynchronous operation to resume the bookmark with the specified name, using the specified
        /// value, time-out interval, callback method, and state. The bookmark to be resumed is previously created by
        /// an activity within the workflow instance.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static Task ResumeBookmarkAsync(this WorkflowApplication self, Bookmark bookmark, object value, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(bookmark != null);

            return Task.Factory.FromAsync(self.BeginResumeBookmark, self.EndResumeBookmark, bookmark, value, timeout, null);
        }

        /// <summary>
        /// Initiates an asynchronous operation to resume the bookmark with the specified name, using the specified
        /// value, time-out interval, callback method, and state. The bookmark to be resumed is previously created by
        /// an activity within the workflow instance.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="bookmarkName"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static Task ResumeBookmarkAsync(this WorkflowApplication self, string bookmarkName, object value, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(bookmarkName != null);

            return Task.Factory.FromAsync(self.BeginResumeBookmark, self.EndResumeBookmark, bookmarkName, value, timeout, null);
        }

        /// <summary>
        /// Persists and a workflow instance to the instance store asychronously.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Task PersistAsync(this WorkflowApplication self)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            return Task.Factory.FromAsync(self.BeginPersist, self.EndPersist, null);
        }

        /// <summary>
        /// Persists and disposes a workflow instance asynchronously.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Task UnloadAsync(this WorkflowApplication self)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            return Task.Factory.FromAsync(self.BeginUnload, self.EndUnload, null);
        }

        /// <summary>
        /// Persists and disposes a workflow instance asynchronously using the specified timeout interval.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static Task UnloadAsync(this WorkflowApplication self, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            return Task.Factory.FromAsync(self.BeginUnload, self.EndUnload, timeout, null);
        }

    }

}
