using System;
using System.Activities;
using System.Activities.Statements;
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
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

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
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

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
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

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
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return While(Invoke(condition), body);
        }

    }

}
