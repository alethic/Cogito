using System;
using System.Activities;
using System.Activities.Statements;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Invokes <paramref name="branches"/> in parallel, canceling if <paramref name="condition"/> is met.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="branches"></param>
        /// <returns></returns>
        public static Parallel Parallel(Activity<bool> condition, params Activity[] branches)
        {
            Contract.Requires<ArgumentNullException>(branches != null);

            var parallel = new Parallel()
            {
                CompletionCondition = condition,
            };

            foreach (var i in branches)
                parallel.Branches.Add(i);

            return parallel;
        }

        /// <summary>
        /// Invokes <paramref name="branches"/> in parallel.
        /// </summary>
        /// <param name="branches"></param>
        /// <returns></returns>
        public static Parallel Parallel(params Activity[] branches)
        {
            Contract.Requires<ArgumentNullException>(branches != null);

            var parallel = new Parallel();
            foreach (var i in branches)
                parallel.Branches.Add(i);

            return parallel;
        }

    }

}
