using System;
using System.Activities.Tracking;

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

        }

    }

}
