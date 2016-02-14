using System;
using System.Runtime.ExceptionServices;

namespace Cogito.Core
{

    /// <summary>
    /// Provides methods to assist in invoking other methods.
    /// </summary>
    public static class Invoker
    {

        /// <summary>
        /// Attempts to invoke the specified function, unwrapping any <see cref="AggregateException"/>s that may have occured.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TResult Try<TResult>(Func<TResult> func)
        {
            try
            {
                return func();
            }
            catch (AggregateException e)
            {
                foreach (var ie in e.Expand())
                    ExceptionDispatchInfo.Capture(ie).Throw();

                throw e;
            }
        }

    }

}
