using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Waits for the given bookmark, and then executes <paramref name="func"/>.
        /// </summary>
        /// <typeparam name="TWait"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="bookmarkName"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Activity<TResult> WaitThen<TWait, TResult>(InArgument<string> bookmarkName, ActivityFunc<TWait, TResult> func)
        {
            if (bookmarkName == null)
                throw new ArgumentNullException(nameof(bookmarkName));
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            var waitVar = new Variable<TWait>();
            var rsltArg = new DelegateOutArgument<TResult>();

            return new InvokeFunc<TResult>()
            {
                Func = new ActivityFunc<TResult>()
                {
                    Handler = new Sequence()
                    {
                        Variables = { waitVar },
                        Activities =
                        {
                            new Wait<TWait>()
                            {
                                BookmarkName = bookmarkName,
                                Result = waitVar,
                            },
                            new InvokeFunc<TWait, TResult>()
                            {
                                Func = func,
                                Argument = waitVar,
                                Result = rsltArg,
                            }
                        }
                    },
                    Result = rsltArg,
                },
            };
        }

        /// <summary>
        /// Waits for the given bookmark, and then executes <paramref name="func"/>.
        /// </summary>
        /// <typeparam name="TWait"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="bookmarkName"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Activity WaitThen<TWait>(InArgument<string> bookmarkName, ActivityAction<TWait> func)
        {
            if (bookmarkName == null)
                throw new ArgumentNullException(nameof(bookmarkName));
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            var waitVar = new Variable<TWait>();
            
            return new Sequence()
            {
                Variables = { waitVar },
                Activities =
                {
                    new Wait<TWait>()
                    {
                        BookmarkName = bookmarkName,
                        Result = waitVar,
                    },
                    new InvokeAction<TWait>()
                    {
                        Action = func,
                        Argument = waitVar,
                    },
                }
            };
        }

        /// <summary>
        /// Waits for the given bookmark, and then executes <paramref name="func"/>.
        /// </summary>
        /// <typeparam name="TWait"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="bookmarkName"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Activity<TResult> WaitThen<TWait, TResult>(InArgument<string> bookmarkName, Func<TWait, Task<TResult>> func)
        {
            if (bookmarkName == null)
                throw new ArgumentNullException(nameof(bookmarkName));
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            return WaitThen(bookmarkName, Delegate<TWait, TResult>((arg) => Invoke(func, arg)));
        }

        /// <summary>
        /// Waits for the given bookmark, and then executes <paramref name="action"/>.
        /// </summary>
        /// <typeparam name="TWait"></typeparam>
        /// <param name="bookmarkName"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Activity WaitThen<TWait>(InArgument<string> bookmarkName, Func<TWait, Task> action)
        {
            if (bookmarkName == null)
                throw new ArgumentNullException(nameof(bookmarkName));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return WaitThen(bookmarkName, Delegate<TWait>((arg) => Invoke(action, arg)));
        }

    }

}
