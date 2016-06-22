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
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(InArgument<bool> condition, Activity then, Activity @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

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
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

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
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

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
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

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
        public static If If(Func<bool> condition, Activity then, Activity @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(Invoke(condition), then, @else);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(Func<bool> condition, Activity then)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

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
        public static If If(Func<Task<bool>> condition, Activity then, Activity @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(InvokeAsync(condition), then, @else);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(Func<Task<bool>> condition, Activity then)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(InvokeAsync(condition), then, null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(InArgument<bool> condition, Action then, Action @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(condition, Invoke(then), @else != null ? Invoke(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(InArgument<bool> condition, Action then)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

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
        public static If If(Activity<bool> condition, Action then, Action @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(condition, Invoke(then), @else != null ? Invoke(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(Activity<bool> condition, Action then)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

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
        public static If If(Func<bool> condition, Action then, Action @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(Invoke(condition), Invoke(then), @else != null ? Invoke(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(Func<bool> condition, Action then)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(Invoke(condition), Invoke(then), null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(Func<Task<bool>> condition, Action then, Action @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(InvokeAsync(condition), Invoke(then), @else != null ? Invoke(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(Func<Task<bool>> condition, Action then)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(InvokeAsync(condition), Invoke(then), null);
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
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(condition, InvokeAsync(then), @else != null ? InvokeAsync(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(InArgument<bool> condition, Func<Task> then)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(condition, InvokeAsync(then), null);
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
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(condition, InvokeAsync(then), @else != null ? InvokeAsync(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(Activity<bool> condition, Func<Task> then)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(condition, InvokeAsync(then), null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(Func<bool> condition, Func<Task> then, Func<Task> @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(Invoke(condition), InvokeAsync(then), @else != null ? InvokeAsync(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(Func<bool> condition, Func<Task> then)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(Invoke(condition), InvokeAsync(then), null);
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
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(InvokeAsync(condition), InvokeAsync(then), @else != null ? InvokeAsync(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        public static If If(Func<Task<bool>> condition, Func<Task> then)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(InvokeAsync(condition), InvokeAsync(then), null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(InArgument<bool> condition, Func<Task> then, Action @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(condition, InvokeAsync(then), @else != null ? Invoke(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(Activity<bool> condition, Action then, Func<Task> @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(condition, Invoke(then), @else != null ? InvokeAsync(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(Func<bool> condition, Func<Task> then, Action @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(Invoke(condition), InvokeAsync(then), @else != null ? Invoke(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(Func<Task<bool>> condition, Func<Task> then, Action @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(InvokeAsync(condition), InvokeAsync(then), @else != null ? Invoke(@else) : null);
        }

        /// <summary>
        /// Evaluates the condition. If <c>true</c> the <paramref name="then"/> activity is executed; otherwise the
        /// <paramref name="@else"/> activity is executed.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        /// <returns></returns>
        public static If If(Func<Task<bool>> condition, Action then, Func<Task> @else)
        {
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(then != null);

            return If(InvokeAsync(condition), Invoke(then), @else != null ? InvokeAsync(@else) : null);
        }

    }

}
