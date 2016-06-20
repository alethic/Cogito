using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cogito.Activities
{

    [DataContract]
    public class RetryState
    {

        /// <summary>
        /// Most recently caught exception.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Exception CaughtException { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool SuppressCancel { get; set; }

        /// <summary>
        /// Set of all caught and handled exceptions.
        /// </summary>
        [DataMember]
        public List<Exception> Attempts { get; set; } = 
            new List<Exception>();

    }

}
