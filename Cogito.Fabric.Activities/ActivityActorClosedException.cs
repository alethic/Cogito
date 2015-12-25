using System;

namespace Cogito.Fabric.Activities
{

    public class ActivityActorClosedException :
        ActivityActorException
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ActivityActorClosedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        public ActivityActorClosedException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActivityActorClosedException()
            : base()
        {

        }

    }

}
