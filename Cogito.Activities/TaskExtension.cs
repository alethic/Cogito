using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    /// <summary>
    /// Provides helper services to <see cref="AsyncNativeActivity"/>.
    /// </summary>
    public class TaskExtension
    {

        readonly static TaskExtension defaultValue = new TaskExtension(t => t());

        /// <summary>
        /// Gets the default <see cref="TaskExtension"/> instance.
        /// </summary>
        public static TaskExtension Default
        {
            get { return defaultValue; }
        }


        readonly Func<Func<Task>, Task> dispatcher;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="dispatcher"></param>
        public TaskExtension(Func<Func<Task>, Task> dispatcher)
        {
            Contract.Requires<ArgumentNullException>(dispatcher != null);

            this.dispatcher = dispatcher;
        }

        /// <summary>
        /// Invokes the given action on the dispatcher.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Task Invoke(Func<Task> action)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return dispatcher(action);
        }

        /// <summary>
        /// Invokes the given function on the dispatcher.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public async Task<TResult> Invoke<TResult>(Func<Task<TResult>> func)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            TResult result = default(TResult);

            await dispatcher(async () =>
            {
                result = await func();
            });

            return result;
        }

        /// <summary>
        /// Invokes the given action on the dispatcher.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Task Invoke(Action action)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return dispatcher(() =>
            {
                action();
                return Task.FromResult(true);
            });
        }

        /// <summary>
        /// Invokes the given action on the dispatcher.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public async Task<TResult> Invoke<TResult>(Func<TResult> func)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            TResult result = default(TResult);

            await dispatcher(() =>
            {
                result = func();
                return Task.FromResult(true);
            });

            return result;
        }

    }

}
