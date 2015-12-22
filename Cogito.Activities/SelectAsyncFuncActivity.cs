using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static SelectAsyncActionActivity<TSource, TResult> Select<TSource, TResult>(InArgument<IEnumerable<TSource>> source, Func<ActivityContext, TSource, Task<TResult>> select)
        {
            return new SelectAsyncActionActivity<TSource, TResult>(source, select);
        }

        public static SelectAsyncActionActivity<TSource, TResult> Select<TSource, TResult>(InArgument<TSource[]> source, Func<ActivityContext, TSource, Task<TResult>> select)
        {
            return new SelectAsyncActionActivity<TSource, TResult>(Invoke(source, i => i.AsEnumerable()), select);
        }

        public static SelectAsyncActionActivity<TSource, TResult> Select<TSource, TResult>(Func<IEnumerable<TSource>> source, Func<ActivityContext, TSource, Task<TResult>> select)
        {
            return new SelectAsyncActionActivity<TSource, TResult>(Invoke(source), select);
        }

        public static SelectAsyncActionActivity<TSource, TResult> Select<TSource, TResult>(this Activity<IEnumerable<TSource>> source, Func<ActivityContext, TSource, Task<TResult>> select)
        {
            return new SelectAsyncActionActivity<TSource, TResult>(source, select);
        }

        public static SelectAsyncActionActivity<TSource, TResult> Select<TSource, TResult>(this Activity<TSource[]> source, Func<ActivityContext, TSource, Task<TResult>> select)
        {
            return new SelectAsyncActionActivity<TSource, TResult>(Invoke<TSource[], IEnumerable<TSource>>(source, i => i.AsEnumerable()), select);
        }

        public static SelectAsyncActionActivity<TSource, TResult> Select<TSource, TResult>(InArgument<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> select)
        {
            return new SelectAsyncActionActivity<TSource, TResult>(source, (context, arg) => select(arg));
        }

        public static SelectAsyncActionActivity<TSource, TResult> Select<TSource, TResult>(InArgument<TSource[]> source, Func<TSource, Task<TResult>> select)
        {
            return new SelectAsyncActionActivity<TSource, TResult>(Invoke(source, i => i.AsEnumerable()), (context, arg) => select(arg));
        }

        public static SelectAsyncActionActivity<TSource, TResult> Select<TSource, TResult>(Func<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> select)
        {
            return new SelectAsyncActionActivity<TSource, TResult>(Invoke(source), (context, arg) => select(arg));
        }

        public static SelectAsyncActionActivity<TSource, TResult> Select<TSource, TResult>(this Activity<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> select)
        {
            return new SelectAsyncActionActivity<TSource, TResult>(source, (context, arg) => select(arg));
        }

        public static SelectAsyncActionActivity<TSource, TResult> Select<TSource, TResult>(this Activity<TSource[]> source, Func<TSource, Task<TResult>> select)
        {
            return new SelectAsyncActionActivity<TSource, TResult>(Invoke<TSource[], IEnumerable<TSource>>(source, i => i.AsEnumerable()), (context, arg) => select(arg));
        }

    }

    /// <summary>
    /// Executes the given <see cref="Action{T}"/> per element.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class SelectAsyncActionActivity<TSource, TResult> :
        NativeActivity<IEnumerable<TResult>>
    {

        readonly Variable<IEnumerable<TSource>> source;
        readonly SelectActivity<TSource, TResult> select;
        readonly AsyncFuncActivity<TSource, TResult> selector;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public SelectAsyncActionActivity()
        {
            var arg = new DelegateInArgument<TSource>();

            select = new SelectActivity<TSource, TResult>()
            {
                Select = new ActivityFunc<TSource, TResult>()
                {
                    Argument = arg,
                    Handler = selector = new AsyncFuncActivity<TSource, TResult>(arg),
                },
                Source = source = new Variable<IEnumerable<TSource>>(),
            };
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        public SelectAsyncActionActivity(InArgument<IEnumerable<TSource>> source, Func<ActivityContext, TSource, Task<TResult>> selector)
        {
            Source = source;
            Selector = selector;
        }

        /// <summary>
        /// Gets the set of elements to execute for.
        /// </summary>
        [RequiredArgument]
        public InArgument<IEnumerable<TSource>> Source { get; set; }

        /// <summary>
        /// The <see cref="Selector"/> to invoke for each element.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TSource, Task<TResult>> Selector
        {
            get { return selector.Func; }
            set { selector.Func = value; }
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationVariable(source);
            metadata.AddImplementationChild(select);
            metadata.AddImplementationChild(selector);
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.SetValue(source, context.GetValue(Source));
            context.ScheduleActivity(select, OnSelectComplete);
        }

        void OnSelectComplete(NativeActivityContext context, ActivityInstance instance, IEnumerable<TResult> result)
        {
            context.SetValue(Result, result);
        }

    }

}
