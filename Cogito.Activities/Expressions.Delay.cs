using System;
using System.Activities;
using System.Activities.Statements;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Cogito.Activities
{
    public static partial class Expressions
    {

        /// <summary>
        /// Creates an activity which delays for <paramref name="duration"/>.
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static Delay Delay(InArgument<TimeSpan> duration,
            [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(duration != null);

            return new Delay()
            {
                DisplayName = displayName,
                Duration = duration,
            };
        }

    }

}
