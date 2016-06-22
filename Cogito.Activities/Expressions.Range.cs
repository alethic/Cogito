using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Executes the given action with <paramref name="count"/> values starting from <paramref name="start"/>.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Activity Range(int start, int count, Func<DelegateInArgument<int>, Activity<int>> action)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return For(
                start,
                Delegate<int, bool>(arg => Invoke(i => Task.FromResult(i - start < count), arg)),
                Delegate<int, int>(arg => Invoke(i => Task.FromResult(i + 1), arg)),
                action);
        }

        /// <summary>
        /// Executes the given action with <paramref name="count"/> values starting from <paramref name="start"/>.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Activity Range(int start, int count, Func<int, Task> action)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            return For(
                start,
                Delegate<int, bool>(arg => Invoke(i => Task.FromResult(i - start < count), arg)),
                Delegate<int, int>(arg => Invoke(i => Task.FromResult(i + 1), arg)),
                action);
        }

    }

}
