using System;
using System.Diagnostics.Contracts;

namespace Cogito.Build.Common
{

    /// <summary>
    /// Serves as an internal exception to propigate warnings.
    /// </summary>
    public class WarningException : Exception
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        internal WarningException(string message)
            : base(message)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(message));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        internal WarningException(string format, params object[] args)
            : base(string.Format(format, args))
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format));
            Contract.Requires<ArgumentNullException>(args != null);
        }

    }

}
