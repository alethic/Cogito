using System;
using System.Activities;
using System.Activities.Statements;

namespace Cogito.Activities
{
    public static partial class Expressions
    {

        /// <summary>
        /// Creates an activity which delays for <paramref name="duration"/>.
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static Delay Delay(InArgument<TimeSpan> duration, string displayName = null)
        {
            if (duration == null)
                throw new ArgumentNullException(nameof(duration));

            return new Delay()
            {
                DisplayName = displayName,
                Duration = duration,
            };
        }

    }

}
