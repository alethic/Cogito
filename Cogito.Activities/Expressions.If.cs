using System;
using System.Activities;
using System.Activities.Statements;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(InArgument<bool> condition, Activity then, Activity @else)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (then == null)
                throw new ArgumentNullException(nameof(then));

            return new If()
            {
                Condition = condition,
                Then = then,
                Else = @else,
            };
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(InArgument<bool> condition, Activity then)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (then == null)
                throw new ArgumentNullException(nameof(then));

            return If(condition, then, null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(Activity<bool> condition, Activity then, Activity @else)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (then == null)
                throw new ArgumentNullException(nameof(then));

            return new If()
            {
                Condition = condition,
                Then = then,
                Else = @else,
            };
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(Activity<bool> condition, Activity then)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (then == null)
                throw new ArgumentNullException(nameof(then));

            return If(condition, then, null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(Func<Task<bool>> condition, Activity then, Activity @else)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (then == null)
                throw new ArgumentNullException(nameof(then));

            return If(Invoke(condition), then, @else);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(Func<Task<bool>> condition, Activity then)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (then == null)
                throw new ArgumentNullException(nameof(then));

            return If(Invoke(condition), then, null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(InArgument<bool> condition, Func<Task> then, Func<Task> @else)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (then == null)
                throw new ArgumentNullException(nameof(then));

            return If(condition, Invoke(then), @else != null ? Invoke(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(InArgument<bool> condition, Func<Task> then)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (then == null)
                throw new ArgumentNullException(nameof(then));

            return If(condition, Invoke(then), null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(Activity<bool> condition, Func<Task> then, Func<Task> @else)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (then == null)
                throw new ArgumentNullException(nameof(then));

            return If(condition, Invoke(then), @else != null ? Invoke(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(Activity<bool> condition, Func<Task> then)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (then == null)
                throw new ArgumentNullException(nameof(then));

            return If(condition, Invoke(then), null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(Func<Task<bool>> condition, Func<Task> then, Func<Task> @else)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (then == null)
                throw new ArgumentNullException(nameof(then));

            return If(Invoke(condition), Invoke(then), @else != null ? Invoke(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(Func<Task<bool>> condition, Func<Task> then)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (then == null)
                throw new ArgumentNullException(nameof(then));

            return If(Invoke(condition), Invoke(then), null);
        }

    }

}
