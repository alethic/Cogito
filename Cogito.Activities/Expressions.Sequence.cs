using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Executes the given set of activities in sequence.
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>
        public static Sequence Sequence(params Activity[] activities)
        {
            if (activities == null)
                throw new ArgumentNullException(nameof(activities));

            return Sequence((IEnumerable<Activity>)activities);
        }

        /// <summary>
        /// Executes the given set of activities in sequence.
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>
        public static Sequence Sequence(IEnumerable<Activity> activities)
        {
            if (activities == null)
                throw new ArgumentNullException(nameof(activities));

            var sequence = new Sequence();
            foreach (var i in activities)
                sequence.Activities.Add(i);

            return sequence;
        }

    }

}
