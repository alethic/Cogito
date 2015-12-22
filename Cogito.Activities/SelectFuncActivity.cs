using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static SelectFuncActivity<TSource, TResult> Select<TSource, TResult>(InArgument<IEnumerable<TSource>> source, Func<ActivityContext, TSource, TResult> select)
        {
            return new SelectFuncActivity<TSource, TResult>(source, select);
        }

        public static SelectFuncActivity<TSource, TResult> Select<TSource, TResult>(InArgument<TSource[]> source, Func<ActivityContext, TSource, TResult> select)
        {
            return new SelectFuncActivity<TSource, TResult>(Invoke(source, i => i.AsEnumerable()), select);
        }

        public static SelectFuncActivity<TSource, TResult> Select<TSource, TResult>(Func<IEnumerable<TSource>> source, Func<ActivityContext, TSource, TResult> select)
        {
            return new SelectFuncActivity<TSource, TResult>(Invoke(source), select);
        }

        public static SelectFuncActivity<TSource, TResult> Select<TSource, TResult>(this Activity<IEnumerable<TSource>> source, Func<ActivityContext, TSource, TResult> select)
        {
            return new SelectFuncActivity<TSource, TResult>(source, select);
        }

        public static SelectFuncActivity<TSource, TResult> Select<TSource, TResult>(this Activity<TSource[]> source, Func<ActivityContext, TSource, TResult> select)
        {
            return new SelectFuncActivity<TSource, TResult>(Invoke<TSource[], IEnumerable<TSource>>(source, i => i.AsEnumerable()), select);
        }

        public static SelectFuncActivity<TSource, TResult> Select<TSource, TResult>(InArgument<IEnumerable<TSource>> source, Func<TSource, TResult> select)
        {
            return new SelectFuncActivity<TSource, TResult>(source, (context, arg) => select(arg));
        }

        public static SelectFuncActivity<TSource, TResult> Select<TSource, TResult>(InArgument<TSource[]> source, Func<TSource, TResult> select)
        {
            return new SelectFuncActivity<TSource, TResult>(Invoke(source, i => i.AsEnumerable()), (context, arg) => select(arg));
        }

        public static SelectFuncActivity<TSource, TResult> Select<TSource, TResult>(Func<IEnumerable<TSource>> source, Func<TSource, TResult> select)
        {
            return new SelectFuncActivity<TSource, TResult>(Invoke(source), (context, arg) => select(arg));
        }

        public static SelectFuncActivity<TSource, TResult> Select<TSource, TResult>(this Activity<IEnumerable<TSource>> source, Func<TSource, TResult> select)
        {
            return new SelectFuncActivity<TSource, TResult>(source, (context, arg) => select(arg));
        }

        public static SelectFuncActivity<TSource, TResult> Select<TSource, TResult>(this Activity<TSource[]> source, Func<TSource, TResult> select)
        {
            return new SelectFuncActivity<TSource, TResult>(Invoke<TSource[], IEnumerable<TSource>>(source, i => i.AsEnumerable()), (context, arg) => select(arg));
        }

    }

    /// <summary>
    /// Executes the given <see cref="Action{T}"/> per element.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class SelectFuncActivity<TSource, TResult> :
        NativeActivity<IEnumerable<TResult>>
    {

        readonly Variable<IEnumerable<TSource>> source;
        readonly SelectActivity<TSource, TResult> select;
        readonly ActivityFunc<TSource, TResult> selectFunc;
        readonly DelegateInArgument<TSource> selectorArg;
        readonly FuncActivity<TSource, TResult> selector;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public SelectFuncActivity()
        {
            select = new SelectActivity<TSource, TResult>()
            {
                Select = selectFunc = new ActivityFunc<TSource, TResult>()
                {
                    Argument = selectorArg = new DelegateInArgument<TSource>(),
                    Handler = selector = new FuncActivity<TSource, TResult>(new InArgument<TSource>(selectorArg)),
                },
                Source = source = new Variable<IEnumerable<TSource>>(),
            };
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        public SelectFuncActivity(InArgument<IEnumerable<TSource>> source, Func<ActivityContext, TSource, TResult> selector)
            : this()
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
        public Func<ActivityContext, TSource, TResult> Selector
        {
            get { return selector.Func; }
            set { selector.Func = value; }
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationVariable(source);
            metadata.AddImplementationChild(select);
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
