using System;
using System.Activities;
using System.Activities.Statements;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Creates a <see cref="TryCatch"/> block around the specified <see cref="Activity"/>s.
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>
        public static TryCatch Try(params Activity[] activities)
        {
            if (activities == null)
                throw new ArgumentNullException(nameof(activities));

            return new TryCatch()
            {
                Try = Sequence(activities),
            };
        }

        /// <summary>
        /// Creates a <see cref="TryCatch"/> block around the specified <see cref="Activity"/>.
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public static TryCatch Try(Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException(nameof(activity));

            return new TryCatch()
            {
                Try = activity,
            };
        }

        /// <summary>
        /// Appends a new exception catcher to the <see cref="TryCatch"/> block.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="tryCatch"></param>
        /// <returns></returns>
        public static TryCatch Catch<TException>(this TryCatch tryCatch)
            where TException : Exception
        {
            if (tryCatch == null)
                throw new ArgumentNullException(nameof(tryCatch));

            tryCatch.Catches.Add(new Catch<TException>());

            return tryCatch;
        }

        /// <summary>
        /// Appends a new exception catcher to the <see cref="TryCatch"/> block.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="tryCatch"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TryCatch Catch<TException>(this TryCatch tryCatch, ActivityAction<TException> action)
            where TException : Exception
        {
            if (tryCatch == null)
                throw new ArgumentNullException(nameof(tryCatch));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            tryCatch.Catches.Add(new Catch<TException>()
            {
                Action = action,
            });

            return tryCatch;
        }

        /// <summary>
        /// Appends a new exception catcher to the <see cref="TryCatch"/> block.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="tryCatch"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TryCatch Catch<TException>(this TryCatch tryCatch, Func<DelegateInArgument<TException>, Activity> action)
            where TException : Exception
        {
            if (tryCatch == null)
                throw new ArgumentNullException(nameof(tryCatch));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return tryCatch.Catch(Delegate(action));
        }

        /// <summary>
        /// Appends a new exception catcher to the <see cref="TryCatch"/> block.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="tryCatch"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TryCatch Catch<TException>(this TryCatch tryCatch, Func<TException, Task> action)
            where TException : Exception
        {
            if (tryCatch == null)
                throw new ArgumentNullException(nameof(tryCatch));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return tryCatch.Catch<TException>(arg => Invoke(action, arg));
        }

    }

}
