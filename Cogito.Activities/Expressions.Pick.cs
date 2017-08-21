using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Creates a new <see cref="Pick"/> block with the specified <paramref name="branches"/>.
        /// </summary>
        /// <param name="branches"></param>
        /// <returns></returns>
        public static Pick Pick(params PickBranch[] branches)
        {
            if (branches == null)
                throw new ArgumentNullException(nameof(branches));

            var pick = new Pick();
            foreach (var i in branches)
                pick.Branches.Add(i);
            return pick;
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> with the given <paramref name="trigger"/> and <paramref name="action"/>.
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static PickBranch PickBranch(Activity trigger, Activity action = null)
        {
            if (trigger == null)
                throw new ArgumentNullException(nameof(trigger));

            return new PickBranch()
            {
                Trigger = trigger,
                Action = action,
            };
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> with the given <paramref name="trigger"/> and <paramref name="action"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="trigger"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static PickBranch PickBranch<T>(ActivityFunc<T> trigger, ActivityAction<T> action)
        {
            if (trigger == null)
                throw new ArgumentNullException(nameof(trigger));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var arg = new Variable<T>();

            return new PickBranch()
            {
                Variables = { arg },
                Trigger = new InvokeFunc<T>()
                {
                    Func = trigger,
                    Result = arg,
                },
                Action = new InvokeAction<T>()
                {
                    Action = action,
                    Argument = arg,
                }
            };
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> with the given <paramref name="trigger"/> and <paramref name="action"/>.
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="trigger"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Pick Branch(this Pick pick, Activity trigger, Activity action)
        {
            if (pick == null)
                throw new ArgumentNullException(nameof(pick));
            if (trigger == null)
                throw new ArgumentNullException(nameof(trigger));

            pick.Branches.Add(PickBranch(trigger, action));
            return pick;
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> with the given <paramref name="trigger"/>.
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="trigger"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Pick Branch(this Pick pick, Activity trigger)
        {
            if (pick == null)
                throw new ArgumentNullException(nameof(pick));
            if (trigger == null)
                throw new ArgumentNullException(nameof(trigger));

            pick.Branches.Add(PickBranch(trigger));
            return pick;
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> with the given <paramref name="trigger"/> and <paramref name="action"/>.
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="trigger"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Pick Branch(this Pick pick, Func<Task> trigger, Func<Task> action)
        {
            if (pick == null)
                throw new ArgumentNullException(nameof(pick));
            if (trigger == null)
                throw new ArgumentNullException(nameof(trigger));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return pick.Branch(Invoke(trigger), Invoke(action));
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> with the given <paramref name="trigger"/>.
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="trigger"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Pick Branch(this Pick pick, Func<Task> trigger)
        {
            if (pick == null)
                throw new ArgumentNullException(nameof(pick));
            if (trigger == null)
                throw new ArgumentNullException(nameof(trigger));

            return pick.Branch(Invoke(trigger));
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> that waits for the given bookmark.
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="bookmarkName"></param>
        /// <returns></returns>
        public static Pick BranchWait(this Pick pick, InArgument<string> bookmarkName)
        {
            if (pick == null)
                throw new ArgumentNullException(nameof(pick));
            if (bookmarkName == null)
                throw new ArgumentNullException(nameof(bookmarkName));

            return pick.Branch(Wait(bookmarkName));
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> that waits for the given bookmark before running <paramref name="action"/>.
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="bookmarkName"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Pick BranchWait(this Pick pick, InArgument<string> bookmarkName, Activity action)
        {
            if (pick == null)
                throw new ArgumentNullException(nameof(pick));
            if (bookmarkName == null)
                throw new ArgumentNullException(nameof(bookmarkName));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return pick.Branch(Wait(bookmarkName), action);
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> that waits for the given bookmark with a value before running <paramref name="action"/>.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="pick"></param>
        /// <param name="bookmarkName"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Pick BranchWait<TResult>(this Pick pick, InArgument<string> bookmarkName, Func<InArgument<TResult>, Activity> action)
        {
            if (pick == null)
                throw new ArgumentNullException(nameof(pick));
            if (bookmarkName == null)
                throw new ArgumentNullException(nameof(bookmarkName));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var arg = new DelegateInArgument<TResult>();

            pick.Branches.Add(new PickBranch()
            {
                Trigger = new Wait<TResult>(bookmarkName, arg),
                Action = action(arg),
            });

            return pick;
        }

        /// <summary>
        /// Creates a new <see cref="Pick"/> that waits for any of the given <see cref="Activity"/>s to complete.
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>
        public static Pick PickAny(params Activity[] activities)
        {
            if (activities == null)
                throw new ArgumentNullException(nameof(activities));

            var pick = new Pick();

            foreach (var activity in activities)
                pick.Branch(activity);

            return pick;
        }

    }

}
