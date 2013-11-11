using System;

using Irony;

namespace Cogito.Irony
{

    /// <summary>
    /// Indicates a parse error has occurred.
    /// </summary>
    public class ParseException : Exception
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        public ParseException(LogMessage message)
            : base(message.Message)
        {

        }

    }

}
