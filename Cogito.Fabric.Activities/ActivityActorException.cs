using System;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Exception thrown when an Activity actor fails.
    /// </summary>
    public class ActivityActorException :
        Exception
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        internal ActivityActorException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        internal ActivityActorException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal ActivityActorException()
            : base()
        {

        }

    }

}
