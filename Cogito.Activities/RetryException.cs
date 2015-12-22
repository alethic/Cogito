using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Activities
{

    /// <summary>
    /// Exception that occurs when a <see cref="Retry"/> <see cref="Activity"/> finally gives up.
    /// </summary>
    public class RetryException :
        Exception
    {

        readonly Exception[] innerExceptions;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="attempts"></param>
        /// <param name="innerExceptions"></param>
        public RetryException(int attempts, params Exception[] innerExceptions)
            : base($"Permanent failure after {attempts}.", innerExceptions.FirstOrDefault())
        {
            Contract.Requires<ArgumentNullException>(attempts > 0);
            Contract.Requires<ArgumentNullException>(innerExceptions != null);

            this.innerExceptions = innerExceptions;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="innerExceptions"></param>
        public RetryException(int attempts, IEnumerable<Exception> innerExceptions)
            : this(attempts, innerExceptions.ToArray())
        {
            Contract.Requires<ArgumentNullException>(attempts > 0);
            Contract.Requires<ArgumentNullException>(innerExceptions != null);
        }

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<Exception> InnerExceptions
        {
            get { return new ReadOnlyCollection<Exception>(innerExceptions); }
        }

    }

}
