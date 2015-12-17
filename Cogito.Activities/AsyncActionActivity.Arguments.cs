
using System;
using System.Activities;
using System.Diagnostics.Contracts;
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

        Func<NativeActivityContext, TArg1, Task> action;

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
        public AsyncActionActivity(Func<NativeActivityContext, TArg1, Task> action)
            : this()
        {
            Contract.Requires<ArgumentNullException>(action != null);

            this.action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, Task> Action
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Arg1 { get; set; }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return action(context, context.GetValue(Arg1)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 2 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2> :
        AsyncNativeActivity
    {

        Func<NativeActivityContext, TArg1, TArg2, Task> action;

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
        public AsyncActionActivity(Func<NativeActivityContext, TArg1, TArg2, Task> action)
            : this()
        {
            Contract.Requires<ArgumentNullException>(action != null);

            this.action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, Task> Action
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Arg1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Arg2 { get; set; }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return action(context, context.GetValue(Arg1), context.GetValue(Arg2)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 3 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3> :
        AsyncNativeActivity
    {

        Func<NativeActivityContext, TArg1, TArg2, TArg3, Task> action;

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
        public AsyncActionActivity(Func<NativeActivityContext, TArg1, TArg2, TArg3, Task> action)
            : this()
        {
            Contract.Requires<ArgumentNullException>(action != null);

            this.action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, TArg3, Task> Action
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Arg1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Arg2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Arg3 { get; set; }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return action(context, context.GetValue(Arg1), context.GetValue(Arg2), context.GetValue(Arg3)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 4 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> :
        AsyncNativeActivity
    {

        Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, Task> action;

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
        public AsyncActionActivity(Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, Task> action)
            : this()
        {
            Contract.Requires<ArgumentNullException>(action != null);

            this.action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, Task> Action
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Arg1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Arg2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Arg3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Arg4 { get; set; }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return action(context, context.GetValue(Arg1), context.GetValue(Arg2), context.GetValue(Arg3), context.GetValue(Arg4)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 5 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> :
        AsyncNativeActivity
    {

        Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task> action;

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
        public AsyncActionActivity(Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task> action)
            : this()
        {
            Contract.Requires<ArgumentNullException>(action != null);

            this.action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task> Action
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Arg1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Arg2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Arg3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Arg4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Arg5 { get; set; }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return action(context, context.GetValue(Arg1), context.GetValue(Arg2), context.GetValue(Arg3), context.GetValue(Arg4), context.GetValue(Arg5)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 6 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> :
        AsyncNativeActivity
    {

        Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> action;

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
        public AsyncActionActivity(Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> action)
            : this()
        {
            Contract.Requires<ArgumentNullException>(action != null);

            this.action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> Action
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Arg1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Arg2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Arg3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Arg4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Arg5 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Arg6 { get; set; }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return action(context, context.GetValue(Arg1), context.GetValue(Arg2), context.GetValue(Arg3), context.GetValue(Arg4), context.GetValue(Arg5), context.GetValue(Arg6)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 7 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> :
        AsyncNativeActivity
    {

        Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> action;

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
        public AsyncActionActivity(Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> action)
            : this()
        {
            Contract.Requires<ArgumentNullException>(action != null);

            this.action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> Action
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Arg1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Arg2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Arg3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Arg4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Arg5 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Arg6 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg7> Arg7 { get; set; }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return action(context, context.GetValue(Arg1), context.GetValue(Arg2), context.GetValue(Arg3), context.GetValue(Arg4), context.GetValue(Arg5), context.GetValue(Arg6), context.GetValue(Arg7)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 8 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> :
        AsyncNativeActivity
    {

        Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> action;

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
        public AsyncActionActivity(Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> action)
            : this()
        {
            Contract.Requires<ArgumentNullException>(action != null);

            this.action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> Action
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Arg1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Arg2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Arg3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Arg4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Arg5 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Arg6 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg7> Arg7 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg8> Arg8 { get; set; }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return action(context, context.GetValue(Arg1), context.GetValue(Arg2), context.GetValue(Arg3), context.GetValue(Arg4), context.GetValue(Arg5), context.GetValue(Arg6), context.GetValue(Arg7), context.GetValue(Arg8)).BeginToAsync(callback, state);
        }

        protected override void EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            ((Task)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (action == null)
                metadata.AddValidationError("Action is required.");
        }

    }


}

