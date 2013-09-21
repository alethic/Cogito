using System;
using System.Diagnostics.Contracts;

namespace Cogito.Build.Common
{

    /// <summary>
    /// Serves as an internal exception to propigate info messages.
    /// </summary>
    public class InfoException : Exception
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        internal InfoException(string message)
            : base(message)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(message));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        internal InfoException(string format, params object[] args)
            : base(string.Format(format, args))
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(format));
            Contract.Requires<ArgumentNullException>(args != null);
        }

    }

}
