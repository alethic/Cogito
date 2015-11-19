using System;
using System.Diagnostics.Contracts;

using Irony;

namespace Cogito.Irony
{

    /// <summary>
    /// Indicates a parse error has occurred.
    /// </summary>
    public class ParseException :
        Exception
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ParseException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        public ParseException(string message)
            : base(message)
        {
            Contract.Requires<ArgumentNullException>(message != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        public ParseException(LogMessage message)
            : base(message.Message)
        {
            Contract.Requires<ArgumentNullException>(message != null);
        }

    }

}
