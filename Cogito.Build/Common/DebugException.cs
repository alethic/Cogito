using System;
using System.Diagnostics.Contracts;

namespace Cogito.Build.Common
{

    /// <summary>
    /// Serves as an internal exception to propigate debug messages.
    /// </summary>
    public class DebugException : Exception
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        internal DebugException(string message)
            : base(message)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(message));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        internal DebugException(string format, params object[] args)
            : base(string.Format(format, args))
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format));
            Contract.Requires<ArgumentNullException>(args != null);
        }

    }

}
