using System;

namespace Cogito.Core.Resources
{

    /// <summary>
    /// Describes an exception that occurred during a resource operation.
    /// </summary>
    public class ResourceException :
        Exception
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ResourceException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        public ResourceException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public ResourceException(string format, params object[] args)
            : base(string.Format(format, args))
        {

        }

    }

}
