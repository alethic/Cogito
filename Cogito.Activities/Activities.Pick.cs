using System;
using System.Activities;
using System.Activities.Statements;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        /// <summary>
        /// Creates a new <see cref="Pick"/> block with the specified <paramref name="branches"/>.
        /// </summary>
        /// <param name="branches"></param>
        /// <returns></returns>
        public static Pick Pick(params PickBranch[] branches)
        {
            Contract.Requires<ArgumentNullException>(branches != null);

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
            Contract.Requires<ArgumentNullException>(trigger != null);

            return new PickBranch()
            {
                Trigger = trigger,
                Action = action,
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
            Contract.Requires<ArgumentNullException>(pick != null);
            Contract.Requires<ArgumentNullException>(trigger != null);

            pick.Branches.Add(PickBranch(trigger, action));
            return pick;
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> with the given <paramref name="trigger"/> and <paramref name="action"/>.
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="trigger"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Pick Branch(this Pick pick, Activity trigger, Action action)
        {
            Contract.Requires<ArgumentNullException>(pick != null);
            Contract.Requires<ArgumentNullException>(trigger != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return pick.Branch(trigger, Invoke(action));
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
            Contract.Requires<ArgumentNullException>(pick != null);
            Contract.Requires<ArgumentNullException>(trigger != null);

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
        public static Pick Branch(this Pick pick, Action trigger, Activity action)
        {
            Contract.Requires<ArgumentNullException>(pick != null);
            Contract.Requires<ArgumentNullException>(trigger != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return pick.Branch(Invoke(trigger), action);
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> with the given <paramref name="trigger"/> and <paramref name="action"/>.
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="trigger"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Pick Branch(this Pick pick, Action trigger, Func<Task> action)
        {
            Contract.Requires<ArgumentNullException>(pick != null);
            Contract.Requires<ArgumentNullException>(trigger != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return pick.Branch(Invoke(trigger), Invoke(action));
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> with the given <paramref name="trigger"/> and <paramref name="action"/>.
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="trigger"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Pick Branch(this Pick pick, Action trigger, Action action)
        {
            Contract.Requires<ArgumentNullException>(pick != null);
            Contract.Requires<ArgumentNullException>(trigger != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return pick.Branch(Invoke(trigger), Invoke(action));
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> with the given <paramref name="trigger"/>.
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="trigger"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Pick Branch(this Pick pick, Action trigger)
        {
            Contract.Requires<ArgumentNullException>(pick != null);
            Contract.Requires<ArgumentNullException>(trigger != null);

            return pick.Branch(Invoke(trigger));
        }

        /// <summary>
        /// Creates a new <see cref="PickBranch"/> with the given <paramref name="trigger"/> and <paramref name="action"/>.
        /// </summary>
        /// <param name="pick"></param>
        /// <param name="trigger"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Pick Branch(this Pick pick, Func<Task> trigger, Action action)
        {
            Contract.Requires<ArgumentNullException>(pick != null);
            Contract.Requires<ArgumentNullException>(trigger != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return pick.Branch(Invoke(trigger), Invoke(action));
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
            Contract.Requires<ArgumentNullException>(pick != null);
            Contract.Requires<ArgumentNullException>(trigger != null);
            Contract.Requires<ArgumentNullException>(action != null);

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
            Contract.Requires<ArgumentNullException>(pick != null);
            Contract.Requires<ArgumentNullException>(trigger != null);

            return pick.Branch(Invoke(trigger));
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
            Contract.Requires<ArgumentNullException>(pick != null);
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentNullException>(action != null);

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
        public static Pick BranchWait<TResult>(this Pick pick, InArgument<string> bookmarkName, Func<DelegateInArgument<TResult>, Activity> action)
        {
            Contract.Requires<ArgumentNullException>(pick != null);
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentNullException>(action != null);

            var arg = new DelegateInArgument<TResult>();

            pick.Branches.Add(new PickBranch()
            {
                Trigger = new Wait<TResult>(bookmarkName, arg),
                Action = action(arg),
            });

            return pick;
        }

    }

}
