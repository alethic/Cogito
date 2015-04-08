using System;
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

    }

}
