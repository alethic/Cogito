using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Func<TArg1, TResult> func, DelegateInArgument<TArg1> arg1, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TResult>(func, arg1)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Func<TArg1, TResult> func, Activity<TArg1> arg1, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TResult>(func, arg1)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Func<TArg1, TArg2, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Func<TArg1, TArg2, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
/// <typeparam name="TArg7"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
/// <param name="arg7"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
/// <typeparam name="TArg7"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
/// <param name="arg7"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
/// <typeparam name="TArg7"></typeparam>
/// <typeparam name="TArg8"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
/// <param name="arg7"></param>
/// <param name="arg8"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
            {
                DisplayName = displayName,
            };
        }

        /// <summary>
        /// Returns a <see cref="Activity"/> that executes <paramref name="func"/>.
        /// </summary>
/// <typeparam name="TArg1"></typeparam>
/// <typeparam name="TArg2"></typeparam>
/// <typeparam name="TArg3"></typeparam>
/// <typeparam name="TArg4"></typeparam>
/// <typeparam name="TArg5"></typeparam>
/// <typeparam name="TArg6"></typeparam>
/// <typeparam name="TArg7"></typeparam>
/// <typeparam name="TArg8"></typeparam>
        /// <param name="func"></param>
/// <param name="arg1"></param>
/// <param name="arg2"></param>
/// <param name="arg3"></param>
/// <param name="arg4"></param>
/// <param name="arg5"></param>
/// <param name="arg6"></param>
/// <param name="arg7"></param>
/// <param name="arg8"></param>
        /// <returns></returns>
        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
            {
                DisplayName = displayName,
            };
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 1 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TResult>(FuncActivity<TArg1, TResult> activity)
        {
            return Expressions.Delegate<TArg1, TResult>((arg1) =>
            {
                activity.Argument1 = arg1;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(FuncActivity<TArg1, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TResult> func = null, InArgument<TArg1> arg1 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, OutArgument<TResult> result = null, Func<TArg1, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TResult> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }



        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            return executor(() => Task.FromResult(Func(arg1)));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 2 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TResult>(FuncActivity<TArg1, TArg2, TResult> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TResult>((arg1, arg2) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(FuncActivity<TArg1, TArg2, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TResult> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }



        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            return executor(() => Task.FromResult(Func(arg1, arg2)));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 3 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TArg3, TResult>(FuncActivity<TArg1, TArg2, TArg3, TResult> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TResult>((arg1, arg2, arg3) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(FuncActivity<TArg1, TArg2, TArg3, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TResult> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }



        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            return executor(() => Task.FromResult(Func(arg1, arg2, arg3)));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 4 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TArg3, TArg4, TResult>(FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TResult>((arg1, arg2, arg3, arg4) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TResult> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }



        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            return executor(() => Task.FromResult(Func(arg1, arg2, arg3, arg4)));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 5 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>((arg1, arg2, arg3, arg4, arg5) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                activity.Argument5 = arg5;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }



        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            return executor(() => Task.FromResult(Func(arg1, arg2, arg3, arg4, arg5)));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 6 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>((arg1, arg2, arg3, arg4, arg5, arg6) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                activity.Argument5 = arg5;
                activity.Argument6 = arg6;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }



        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            return executor(() => Task.FromResult(Func(arg1, arg2, arg3, arg4, arg5, arg6)));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 7 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>((arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                activity.Argument5 = arg5;
                activity.Argument6 = arg6;
                activity.Argument7 = arg7;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg7> Argument7 { get; set; }



        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            var arg7 = Argument7.Get(context);
            return executor(() => Task.FromResult(Func(arg1, arg2, arg3, arg4, arg5, arg6, arg7)));
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 8 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> activity)
        {
            return Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                activity.Argument5 = arg5;
                activity.Argument6 = arg6;
                activity.Argument7 = arg7;
                activity.Argument8 = arg8;
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg7> Argument7 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg8> Argument8 { get; set; }



        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            var arg7 = Argument7.Get(context);
            var arg8 = Argument8.Get(context);
            return executor(() => Task.FromResult(Func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)));
        }

    }


}

