using System;
using System.Activities;
using System.Activities.Statements;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Executes <paramref name="action"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static While While(Activity<bool> condition, Activity action)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return new While(condition)
            {
                Body = action,
            };
        }

        /// <summary>
        /// Executes <paramref name="activity"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="activity"></param>
        /// <returns></returns>
        public static While While(Activity<bool> condition, Action action)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return new While(condition)
            {
                Body = Invoke(action),
            };
        }

        /// <summary>
        /// Executes <paramref name="activity"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="activity"></param>
        /// <returns></returns>
        public static While While(Activity<bool> condition, Func<Task> action)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return new While(condition)
            {
                Body = InvokeAsync(action),
            };
        }

        /// <summary>
        /// Executes <paramref name="action"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static While While(Func<bool> condition, Activity action)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return While(Invoke(condition), action);
        }

        /// <summary>
        /// Executes <paramref name="action"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static While While(Func<bool> condition, Action action)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return While(Invoke(condition), action);
        }

        /// <summary>
        /// Executes <paramref name="action"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static While While(Func<bool> condition, Func<Task> action)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return While(Invoke(condition), action);
        }

        /// <summary>
        /// Executes <paramref name="action"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static While While(Func<Task<bool>> condition, Activity action)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return While(InvokeAsync(condition), action);
        }

        /// <summary>
        /// Executes <paramref name="action"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static While While(Func<Task<bool>> condition, Action action)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return While(InvokeAsync(condition), action);
        }

        /// <summary>
        /// Executes <paramref name="action"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static While While(Func<Task<bool>> condition, Func<Task> action)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return While(InvokeAsync(condition), action);
        }

    }

}
