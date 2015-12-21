using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Activities
{

    public static partial class Activities
    {
        
        public static Delay Delay(InArgument<TimeSpan> duration)
        {
            return new Delay()
            {
                Duration = duration,
            };
        }

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

        public static ForEach<TElement> ForEach<TElement, TActivity>(this Activity<IEnumerable<TElement>> values, Func<DelegateInArgument<TElement>, TActivity> activity)
            where TActivity : Activity
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(activity != null);

            var arg = new DelegateInArgument<TElement>();

            return new ForEach<TElement>()
            {
                Body = new ActivityAction<TElement>()
                {
                    Argument = arg,
                    Handler = activity(arg),
                },
                Values = values,
            };
        }

        public static ForEach<TElement> ForEach<TElement, TActivity>(this Activity<TElement[]> values, Func<DelegateInArgument<TElement>, TActivity> activity)
            where TActivity : Activity
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(activity != null);

            return ForEach(values.Select(i => i), activity);
        }

        public static ParallelForEach<TElement> ParallelForEach<TElement, TActivity>(this Activity<IEnumerable<TElement>> values, Func<DelegateInArgument<TElement>, TActivity> activity)
            where TActivity : Activity
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(activity != null);

            var arg = new DelegateInArgument<TElement>();

            return new ParallelForEach<TElement>()
            {
                Body = new ActivityAction<TElement>()
                {
                    Argument = arg,
                    Handler = activity(arg),
                },
                Values = values,
            };
        }

        public static ParallelForEach<TElement> ParallelForEach<TElement, TActivity>(this Activity<TElement[]> values, Func<DelegateInArgument<TElement>, TActivity> activity)
            where TActivity : Activity
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(activity != null);

            return ParallelForEach(values.Select(i => i), activity);
        }

        public static While While(Activity<bool> condition, Activity activity)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(activity != null);

            return new While(condition)
            {
                Body = activity,
            };
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

            return Func<TSource, TResult>(source, i => i);
        }

        public static Parallel WithBranch(this Parallel parallel, Activity branch)
        {
            parallel.Branches.Add(branch);
            return parallel;
        }

    }

}
