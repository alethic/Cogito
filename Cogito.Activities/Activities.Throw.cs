using System;
using System.Activities;
using System.Activities.Statements;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        /// <summary>
        /// Throws a new <see cref="Exception"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw(InArgument<Exception> exception)
        {
            Contract.Requires<ArgumentNullException>(exception != null);

            return new Throw()
            {
                Exception = exception,
            };
        }

        /// <summary>
        /// Throws a new <see cref="Exception"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw(Activity<Exception> exception)
        {
            Contract.Requires<ArgumentNullException>(exception != null);

            return new Throw()
            {
                Exception = exception,
            };
        }

        /// <summary>
        /// Throws a new <see cref="Exception"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw(Func<Exception> exception)
        {
            Contract.Requires<ArgumentNullException>(exception != null);

            return Throw(Invoke(exception));
        }

        /// <summary>
        /// Throws a new <see cref="Exception"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg>(Func<TArg, Exception> exception, DelegateInArgument<TArg> arg)
        {
            Contract.Requires<ArgumentNullException>(exception != null);

            return Throw(Invoke(exception, arg));
        }

    }

}
