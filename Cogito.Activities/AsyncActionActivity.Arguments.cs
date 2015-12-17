
using System;
using System.Activities;
using System.Threading.Tasks;

using Cogito.Threading;

namespace Cogito.Activities
{


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 1 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1> :
        AsyncNativeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        public AsyncActionActivity(Func<TArg1, Task> action = null, InArgument<TArg1> arg1 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, Func<TArg1, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<TArg1, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return Action(context.GetValue(Argument1)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 2 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2> :
        AsyncNativeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public AsyncActionActivity(Func<TArg1, TArg2, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, Func<TArg1, TArg2, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, Task> Action { get; set; }

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

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return Action(context.GetValue(Argument1), context.GetValue(Argument2)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 3 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3> :
        AsyncNativeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public AsyncActionActivity(Func<TArg1, TArg2, TArg3, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, Func<TArg1, TArg2, TArg3, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, Task> Action { get; set; }

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

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return Action(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 4 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> :
        AsyncNativeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
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
        public AsyncActionActivity(Func<TArg1, TArg2, TArg3, TArg4, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, Func<TArg1, TArg2, TArg3, TArg4, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, Task> Action { get; set; }

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

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return Action(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 5 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> :
        AsyncNativeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
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
        public AsyncActionActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
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
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> Action { get; set; }

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

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return Action(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 6 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> :
        AsyncNativeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
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
        public AsyncActionActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
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
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> Action { get; set; }

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

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return Action(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 7 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> :
        AsyncNativeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
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
        public AsyncActionActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
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
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> Action { get; set; }

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

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return Action(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 8 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> :
        AsyncNativeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
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
        public AsyncActionActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
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
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> Action { get; set; }

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

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return Action(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7), context.GetValue(Argument8)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


}

