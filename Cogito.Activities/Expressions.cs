using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        public static Sequence Sequence(params Activity[] activities)
        {
            Contract.Requires<ArgumentNullException>(activities != null);

            var sequence = new Sequence();
            foreach (var i in activities)
                sequence.Activities.Add(i);

            return sequence;
        }

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

        public static Parallel Parallel(params Activity[] branches)
        {
            Contract.Requires<ArgumentNullException>(branches != null);

            var parallel = new Parallel();
            foreach (var i in branches)
                parallel.Branches.Add(i);

            return parallel;
        }

        public static Parallel ParallelFirst(params Activity[] branches)
        {
            Contract.Requires<ArgumentNullException>(branches != null);

            var parallel = new Parallel();
            foreach (var i in branches)
                parallel.Branches.Add(i);

            return parallel;
        }

        public static Sequence Then(this Activity activity, Activity next)
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(next != null);

            // if existing sequence, use, else wrap with new
            var sequence = activity as Sequence;
            if (sequence == null)
                sequence = new Sequence() { Activities = { activity } };

            // append next activity to sequence
            sequence.Activities.Add(next);

            return sequence;
        }

        public static Sequence ThenParallel(this Activity activity, IEnumerable<Activity> branches)
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(branches != null);

            var parallel = new Parallel();
            foreach (var i in branches)
                parallel.Branches.Add(i);

            return Then(activity, parallel);
        }

        public static Sequence ThenParallel(this Activity activity, params Activity[] next)
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(next != null);

            return ThenParallel(activity, (IEnumerable<Activity>)next);
        }

        public static Sequence ThenDelay(this Activity activity, TimeSpan duration)
        {
            Contract.Requires<ArgumentNullException>(activity != null);

            return Then(activity, new Delay()
            {
                Duration = duration,
            });
        }

        public static Sequence ThenDelay(this Activity activity, Activity<TimeSpan> duration)
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(duration != null);

            return Then(activity, new Delay()
            {
                Duration = duration,
            });
        }

        public static Activity<TResult> As<TSource, TResult>(this Activity<TSource> source)
            where TSource : TResult
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return new As<TSource, TResult>()
            {
                Operand = source,
            };
        }

        public static Parallel WithBranch(this Parallel parallel, Activity branch)
        {
            parallel.Branches.Add(branch);
            return parallel;
        }

        /// <summary>
        /// Executes the given action with <paramref name="count"/> values starting from <paramref name="start"/>.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static Activity Range(int start, int count, Func<DelegateInArgument<int>, ActionActivity<int>> body)
        {
            return For(start, i => i - count < count, i => i + 1, body);
        }

        /// <summary>
        /// Executes the given action with <paramref name="count"/> values starting from <paramref name="start"/>.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Activity Range(int start, int count, Action<int> action)
        {
            return For<int>(start, i => i - start < count, i => i + 1, arg => Invoke(action, arg));
        }   

    }

}
