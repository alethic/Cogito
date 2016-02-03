using System;
using System.Activities.Tracking;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

using Cogito.Threading;

namespace Cogito.Fabric.Activities
{

    public partial class ActivityActorTrackingParticipant :
        TrackingParticipant
    {

        readonly IActivityActorInternal actor;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal ActivityActorTrackingParticipant(IActivityActorInternal actor)
        {
            Contract.Requires<ArgumentNullException>(actor != null);

            this.actor = actor;
        }

        protected override IAsyncResult BeginTrack(TrackingRecord record, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return Task.Run(() => Track(record, timeout)).BeginToAsync(callback, state);
        }

        protected override void EndTrack(IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void Track(TrackingRecord record, TimeSpan timeout)
        {
            if (ActivityActorEventSource.Current.IsEnabled())
            {
                TrackRecord(record);
            }
        }

    }

}
