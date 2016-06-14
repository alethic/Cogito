using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Activities
{

    /// <summary>
    /// Exception that occurs when a <see cref="Retry"/> <see cref="Activity"/> finally gives up.
    /// </summary>
    [Serializable]
    public class RetryException :
        Exception
    {

        readonly Exception[] attempts;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="attempts"></param>
        public RetryException(params Exception[] attempts)
            : base($"Permanent failure after {attempts.Length} attempts.")
        {
            Contract.Requires<ArgumentNullException>(attempts != null);

            this.attempts = attempts;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="attempts"></param>
        public RetryException(IEnumerable<Exception> attempts)
            : this(attempts.ToArray())
        {
            Contract.Requires<ArgumentNullException>(attempts != null);
        }

        /// <summary>
        /// Execeptions that occurred during the attempts.
        /// </summary>
        public Exception[] Attempts
        {
            get { return attempts; }
        }

    }

}
