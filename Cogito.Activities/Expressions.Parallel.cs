using System;
using System.Activities;
using System.Activities.Statements;

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
            if (branches == null)
                throw new ArgumentNullException(nameof(branches));

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
            if (branches == null)
                throw new ArgumentNullException(nameof(branches));

            var parallel = new Parallel();
            foreach (var i in branches)
                parallel.Branches.Add(i);

            return parallel;
        }

    }

}
