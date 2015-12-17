
using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

using Cogito.Threading;

namespace Cogito.Activities
{


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 1 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TResult> :
        AsyncNativeActivity<TResult>
    {

        Func<NativeActivityContext, TArg1, Task<TResult>> func;

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
        public AsyncFuncActivity(Func<NativeActivityContext, TArg1, Task<TResult>> func)
            : this()
        {
            Contract.Requires<ArgumentNullException>(func != null);

            this.func = func;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, Task<TResult>> Func
        {
            get { return func; }
            set { func = value; }
        }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Arg1 { get; set; }

        protected override IAsyncResult BeginExecute(NativeActivityContext context, AsyncCallback callback, object state)
        {
            return func(context, context.GetValue(Arg1)).BeginToAsync(callback, state);
        }

        protected override TResult EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            return ((Task<TResult>)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 2 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TResult> :
        AsyncNativeActivity<TResult>
    {

        Func<NativeActivityContext, TArg1, TArg2, Task<TResult>> func;

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
        public AsyncFuncActivity(Func<NativeActivityContext, TArg1, TArg2, Task<TResult>> func)
            : this()
        {
            Contract.Requires<ArgumentNullException>(func != null);

            this.func = func;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, Task<TResult>> Func
        {
            get { return func; }
            set { func = value; }
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
            return func(context, context.GetValue(Arg1), context.GetValue(Arg2)).BeginToAsync(callback, state);
        }

        protected override TResult EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            return ((Task<TResult>)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 3 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> :
        AsyncNativeActivity<TResult>
    {

        Func<NativeActivityContext, TArg1, TArg2, TArg3, Task<TResult>> func;

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
        public AsyncFuncActivity(Func<NativeActivityContext, TArg1, TArg2, TArg3, Task<TResult>> func)
            : this()
        {
            Contract.Requires<ArgumentNullException>(func != null);

            this.func = func;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, TArg3, Task<TResult>> Func
        {
            get { return func; }
            set { func = value; }
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
            return func(context, context.GetValue(Arg1), context.GetValue(Arg2), context.GetValue(Arg3)).BeginToAsync(callback, state);
        }

        protected override TResult EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            return ((Task<TResult>)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 4 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> :
        AsyncNativeActivity<TResult>
    {

        Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, Task<TResult>> func;

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
        public AsyncFuncActivity(Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, Task<TResult>> func)
            : this()
        {
            Contract.Requires<ArgumentNullException>(func != null);

            this.func = func;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, Task<TResult>> Func
        {
            get { return func; }
            set { func = value; }
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
            return func(context, context.GetValue(Arg1), context.GetValue(Arg2), context.GetValue(Arg3), context.GetValue(Arg4)).BeginToAsync(callback, state);
        }

        protected override TResult EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            return ((Task<TResult>)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 5 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> :
        AsyncNativeActivity<TResult>
    {

        Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func;

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
        public AsyncFuncActivity(Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func)
            : this()
        {
            Contract.Requires<ArgumentNullException>(func != null);

            this.func = func;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> Func
        {
            get { return func; }
            set { func = value; }
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
            return func(context, context.GetValue(Arg1), context.GetValue(Arg2), context.GetValue(Arg3), context.GetValue(Arg4), context.GetValue(Arg5)).BeginToAsync(callback, state);
        }

        protected override TResult EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            return ((Task<TResult>)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 6 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> :
        AsyncNativeActivity<TResult>
    {

        Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func;

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
        public AsyncFuncActivity(Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func)
            : this()
        {
            Contract.Requires<ArgumentNullException>(func != null);

            this.func = func;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> Func
        {
            get { return func; }
            set { func = value; }
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
            return func(context, context.GetValue(Arg1), context.GetValue(Arg2), context.GetValue(Arg3), context.GetValue(Arg4), context.GetValue(Arg5), context.GetValue(Arg6)).BeginToAsync(callback, state);
        }

        protected override TResult EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            return ((Task<TResult>)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 7 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> :
        AsyncNativeActivity<TResult>
    {

        Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func;

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
        public AsyncFuncActivity(Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func)
            : this()
        {
            Contract.Requires<ArgumentNullException>(func != null);

            this.func = func;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> Func
        {
            get { return func; }
            set { func = value; }
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
            return func(context, context.GetValue(Arg1), context.GetValue(Arg2), context.GetValue(Arg3), context.GetValue(Arg4), context.GetValue(Arg5), context.GetValue(Arg6), context.GetValue(Arg7)).BeginToAsync(callback, state);
        }

        protected override TResult EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            return ((Task<TResult>)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 8 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> :
        AsyncNativeActivity<TResult>
    {

        Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func;

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
        public AsyncFuncActivity(Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func)
            : this()
        {
            Contract.Requires<ArgumentNullException>(func != null);

            this.func = func;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        public Func<NativeActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> Func
        {
            get { return func; }
            set { func = value; }
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
            return func(context, context.GetValue(Arg1), context.GetValue(Arg2), context.GetValue(Arg3), context.GetValue(Arg4), context.GetValue(Arg5), context.GetValue(Arg6), context.GetValue(Arg7), context.GetValue(Arg8)).BeginToAsync(callback, state);
        }

        protected override TResult EndExecute(NativeActivityContext context, IAsyncResult result)
        {
            return ((Task<TResult>)result).EndToAsync();
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


}

