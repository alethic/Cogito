using System;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.Fabric.Activities
{

    public static class ActivityActorExtensions
    {

        /// <summary>
        /// Invokes the given action using an actor timer.
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="action"></param>
        public static void ScheduleInvokeWithTimer(this IActivityActor actor, Func<Task> action)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(action != null);

            // hoist timer so it can be unregistered
            IActorTimer timer = null;

            // schedule timer
            timer = actor.RegisterTimer(
                o => { actor.UnregisterTimer(timer); return action(); },
                null,
                TimeSpan.FromMilliseconds(1),
                TimeSpan.FromMilliseconds(-1));
        }

        /// <summary>
        /// Gets the actor reminder with the specified actor reminder name, or <c>null</c> if no such reminder exists.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <returns></returns>
        public static IActorReminder TryGetReminder(this IActivityActor actor, string reminderName)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(reminderName != null);

            try
            {
                return actor.GetReminder(reminderName);
            }
            catch (FabricException e) when (e.ErrorCode == FabricErrorCode.Unknown)
            {
                // ignore
            }

            return null;
        }

    }

}
