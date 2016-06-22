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
        /// Executes <paramref name="body"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static While While(Activity<bool> condition, Activity body)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new While(condition)
            {
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="activity"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static While While(Activity<bool> condition, Func<Task> body)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new While(condition)
            {
                Body = Invoke(body),
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static While While(Func<Task<bool>> condition, Activity body)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return While(Invoke(condition), body);
        }

        /// <summary>
        /// Executes <paramref name="body"/> until <paramref name="condition"/> returns <c>false</c>.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static While While(Func<Task<bool>> condition, Func<Task> body)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return While(Invoke(condition), body);
        }

    }

}
