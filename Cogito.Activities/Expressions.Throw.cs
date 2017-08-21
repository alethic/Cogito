using System;
using System.Activities;
using System.Activities.Statements;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Throw Throw<TException>(DelegateInArgument<TException> exception, string displayName = null)
            where TException : Exception
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            return new Throw()
            {
                DisplayName = displayName,
                Exception = Cast<TException, Exception>(exception, displayName),
            };
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Throw Throw<TException>(Activity<TException> exception, string displayName = null)
            where TException : Exception
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            return new Throw()
            {
                DisplayName = displayName,
                Exception = Cast<TException, Exception>(exception, displayName),
            };
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Throw Throw<TException>(Func<Task<TException>> exception, string displayName = null)
            where TException : Exception
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            return Throw(Invoke(exception, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="Exception"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Throw Throw(DelegateInArgument<Exception> exception, string displayName = null)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            return new Throw()
            {
                DisplayName = displayName,
                Exception = exception,
            };
        }

        /// <summary>
        /// Throws a <typeparam name="Exception"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Throw Throw(Activity<Exception> exception, string displayName = null)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            return new Throw()
            {
                DisplayName = displayName,
                Exception = exception,
            };
        }

        /// <summary>
        /// Throws a <typeparam name="Exception"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static Throw Throw(Func<Task<Exception>> exception, string displayName = null)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            return Throw(Invoke(exception, displayName), displayName);
        }

    }

}
