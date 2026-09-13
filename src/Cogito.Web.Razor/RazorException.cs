using System;

namespace Cogito.Web.Razor
{

    public class RazorException : Exception
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public RazorException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        public RazorException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        public RazorException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public RazorException(string format, params object[] args)
            : base(string.Format(format, args))
        {
            if (format == null)
                throw new ArgumentNullException(nameof(format));
            if (args == null)
                throw new ArgumentNullException(nameof(args));
        }

    }

}
