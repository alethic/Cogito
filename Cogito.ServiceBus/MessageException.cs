using System;

namespace Cogito.ServiceBus
{

    public class MessageException :
        Exception
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        public MessageException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="innerException"></param>
        public MessageException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public MessageException(string format, params object[] args)
            : this(string.Format(format, args))
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="innerException"></param>
        /// <param name="args"></param>
        public MessageException(string format, Exception innerException, params object[] args)
            : this(string.Format(format, args), innerException)
        {

        }

    }

}
