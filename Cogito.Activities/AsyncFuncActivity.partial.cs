using System;
using System.Activities;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 1 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TResult>(AsyncFuncActivity<TArg1, TResult> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TResult>((arg1) =>
            {
                activity.Argument1 = arg1;
                return activity;
            }) : null;
        }

        public static implicit operator ActivityDelegate(AsyncFuncActivity<TArg1, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        public AsyncFuncActivity(Func<TArg1, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1;
            Result = result;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, Task<TResult>> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            return executor(() => Func(arg1));
        }

    }
    
    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 2 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TResult>(AsyncFuncActivity<TArg1, TArg2, TResult> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TResult>((arg1, arg2) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                return activity;
            }) : null;
        }

        public static implicit operator ActivityDelegate(AsyncFuncActivity<TArg1, TArg2, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        public AsyncFuncActivity(Func<TArg1, TArg2, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1;
            Argument2 = arg2;
            Result = result;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, Task<TResult>> Func { get; set; }

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

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            return executor(() => Func(arg1, arg2));
        }

    }
    
    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 3 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TArg3, TResult>(AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TArg3, TResult>((arg1, arg2, arg3) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                return activity;
            }) : null;
        }

        public static implicit operator ActivityDelegate(AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
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
        public AsyncFuncActivity(Func<TArg1, TArg2, TArg3, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Result = result;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, TArg3, Task<TResult>> Func { get; set; }

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

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            return executor(() => Func(arg1, arg2, arg3));
        }

    }
    
    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 4 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TArg3, TArg4, TResult>(AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TResult>((arg1, arg2, arg3, arg4) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                return activity;
            }) : null;
        }

        public static implicit operator ActivityDelegate(AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
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
        public AsyncFuncActivity(Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Result = result;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> Func { get; set; }

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

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            return executor(() => Func(arg1, arg2, arg3, arg4));
        }

    }
    
    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 5 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>((arg1, arg2, arg3, arg4, arg5) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                activity.Argument5 = arg5;
                return activity;
            }) : null;
        }

        public static implicit operator ActivityDelegate(AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
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
        public AsyncFuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Result = result;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> Func { get; set; }

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

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            return executor(() => Func(arg1, arg2, arg3, arg4, arg5));
        }

    }
    
    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 6 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>((arg1, arg2, arg3, arg4, arg5, arg6) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                activity.Argument5 = arg5;
                activity.Argument6 = arg6;
                return activity;
            }) : null;
        }

        public static implicit operator ActivityDelegate(AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
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
        public AsyncFuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Argument6 = arg6;
            Result = result;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> Func { get; set; }

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

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            return executor(() => Func(arg1, arg2, arg3, arg4, arg5, arg6));
        }

    }
    
    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 7 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>((arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                activity.Argument5 = arg5;
                activity.Argument6 = arg6;
                activity.Argument7 = arg7;
                return activity;
            }) : null;
        }

        public static implicit operator ActivityDelegate(AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
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
        public AsyncFuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Argument6 = arg6;
            Argument7 = arg7;
            Result = result;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> Func { get; set; }

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

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            var arg7 = Argument7.Get(context);
            return executor(() => Func(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
        }

    }
    
    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 8 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>
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
            }) : null;
        }

        public static implicit operator ActivityDelegate(AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
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
        public AsyncFuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Argument6 = arg6;
            Argument7 = arg7;
            Argument8 = arg8;
            Result = result;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> Func { get; set; }

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
            return executor(() => Func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
        }

    }
    

}