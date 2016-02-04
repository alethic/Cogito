using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Cogito
{

    public static class ExceptionExtensions
    {

        /// <summary>
        /// Traces the exception to the default trace source as an error.
        /// </summary>
        /// <param name="self"></param>
        public static void Trace(this Exception self)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            System.Diagnostics.Trace.TraceError("{0:HH:mm:ss.fff} {1} {2}", DateTime.Now, self.GetType().FullName, self);
        }

        /// <summary>
        /// Unpacks any InnerExceptions hidden by <see cref="AggregateException"/>.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static IEnumerable<Exception> Expand(this Exception e)
        {
            var ae = e as AggregateException;
            if (ae != null)
                foreach (var aee in Expand(ae))
                    yield return aee;
            else
                yield return e;
        }

    }

}
