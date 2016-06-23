using System;
using System.Activities.Tracking;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public class RetryExceptionCaughtTrackingRecord :
        CustomTrackingRecord
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="attempts"></param>
        public RetryExceptionCaughtTrackingRecord(Exception e, int attempts) : 
            base(e.Message)
        {
            Contract.Requires<ArgumentNullException>(e != null);
        }

    }

}
