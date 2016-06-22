using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

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
            Contract.Requires<ArgumentNullException>(activities != null);

            return Sequence((IEnumerable<Activity>)activities);
        }

        /// <summary>
        /// Executes the given set of activities in sequence.
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>
        public static Sequence Sequence(IEnumerable<Activity> activities)
        {
            Contract.Requires<ArgumentNullException>(activities != null);

            var sequence = new Sequence();
            foreach (var i in activities)
                sequence.Activities.Add(i);

            return sequence;
        }

    }

}
