using System;
using System.Collections.Generic;
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
            if (attempts == null)
                throw new ArgumentNullException(nameof(attempts));

            this.attempts = attempts;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="attempts"></param>
        public RetryException(IEnumerable<Exception> attempts)
            : this(attempts.ToArray())
        {
            if (attempts == null)
                throw new ArgumentNullException(nameof(attempts));
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
