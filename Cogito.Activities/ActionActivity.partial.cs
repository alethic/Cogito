using System;
using System.Activities;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 1 arguments.
    /// </summary>
    public class ActionActivity<TArg1> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1}"/> to a <see cref="ActivityAction{TArg1}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1>(ActionActivity<TArg1> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1>((arg1) =>
            {
                activity.Argument1 = arg1;
                return activity;
            }) : null;
        }
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        public ActionActivity(Action<TArg1> action = null, InArgument<TArg1> arg1 = null)
        {
            Action = action;
            Argument1 = arg1;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor)
        {
            var arg1 = Argument1.Get(context);
            return Action != null ? executor.ExecuteAsync(() => { Action(arg1); return Task.FromResult(true); }) : null;
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 2 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2}"/> to a <see cref="ActivityAction{TArg1, TArg2}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2>(ActionActivity<TArg1, TArg2> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2>((arg1, arg2) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                return activity;
            }) : null;
        }
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public ActionActivity(Action<TArg1, TArg2> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            return Action != null ? executor.ExecuteAsync(() => { Action(arg1, arg2); return Task.FromResult(true); }) : null;
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 3 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2, TArg3> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3}"/> to a <see cref="ActivityAction{TArg1, TArg2, TArg3}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2, TArg3>(ActionActivity<TArg1, TArg2, TArg3> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TArg3>((arg1, arg2, arg3) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                return activity;
            }) : null;
        }
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2, TArg3> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public ActionActivity(Action<TArg1, TArg2, TArg3> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2, TArg3> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            return Action != null ? executor.ExecuteAsync(() => { Action(arg1, arg2, arg3); return Task.FromResult(true); }) : null;
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 4 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2, TArg3, TArg4> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4}"/> to a <see cref="ActivityAction{TArg1, TArg2, TArg3, TArg4}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4>(ActionActivity<TArg1, TArg2, TArg3, TArg4> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TArg3, TArg4>((arg1, arg2, arg3, arg4) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                return activity;
            }) : null;
        }
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2, TArg3, TArg4> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public ActionActivity(Action<TArg1, TArg2, TArg3, TArg4> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2, TArg3, TArg4> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            return Action != null ? executor.ExecuteAsync(() => { Action(arg1, arg2, arg3, arg4); return Task.FromResult(true); }) : null;
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 5 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5}"/> to a <see cref="ActivityAction{TArg1, TArg2, TArg3, TArg4, TArg5}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5>(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5>((arg1, arg2, arg3, arg4, arg5) =>
            {
                activity.Argument1 = arg1;
                activity.Argument2 = arg2;
                activity.Argument3 = arg3;
                activity.Argument4 = arg4;
                activity.Argument5 = arg5;
                return activity;
            }) : null;
        }
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        public ActionActivity(Action<TArg1, TArg2, TArg3, TArg4, TArg5> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2, TArg3, TArg4, TArg5> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            return Action != null ? executor.ExecuteAsync(() => { Action(arg1, arg2, arg3, arg4, arg5); return Task.FromResult(true); }) : null;
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 6 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6}"/> to a <see cref="ActivityAction{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>((arg1, arg2, arg3, arg4, arg5, arg6) =>
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
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        public ActionActivity(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Argument6 = arg6;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            return Action != null ? executor.ExecuteAsync(() => { Action(arg1, arg2, arg3, arg4, arg5, arg6); return Task.FromResult(true); }) : null;
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 7 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7}"/> to a <see cref="ActivityAction{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>((arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>
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
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        public ActionActivity(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Argument6 = arg6;
            Argument7 = arg7;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg7> Argument7 { get; set; }

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            var arg7 = Argument7.Get(context);
            return Action != null ? executor.ExecuteAsync(() => { Action(arg1, arg2, arg3, arg4, arg5, arg6, arg7); return Task.FromResult(true); }) : null;
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given action with 8 arguments.
    /// </summary>
    public class ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> :
        AsyncTaskCodeActivity
    {
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8}"/> to a <see cref="ActivityAction{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8}"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> activity)
        {
            return activity != null ? Expressions.Delegate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>
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
        
    
        /// <summary>
        /// Converts a <see cref="ActionActivity{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8}"/> to a <see cref="ActivityDelegate"/>.
        /// </summary>
        /// <param name="activity"></param>
        public static implicit operator ActivityDelegate(ActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        public ActionActivity(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null)
        {
            Action = action;
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
            Argument4 = arg4;
            Argument5 = arg5;
            Argument6 = arg6;
            Argument7 = arg7;
            Argument8 = arg8;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg7> Argument7 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg8> Argument8 { get; set; }

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(AsyncCodeActivityContext context, AsyncTaskExecutor executor)
        {
            var arg1 = Argument1.Get(context);
            var arg2 = Argument2.Get(context);
            var arg3 = Argument3.Get(context);
            var arg4 = Argument4.Get(context);
            var arg5 = Argument5.Get(context);
            var arg6 = Argument6.Get(context);
            var arg7 = Argument7.Get(context);
            var arg8 = Argument8.Get(context);
            return Action != null ? executor.ExecuteAsync(() => { Action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8); return Task.FromResult(true); }) : null;
        }

    }


}
