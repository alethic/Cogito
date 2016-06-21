using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        public static SelectActivity<TSource, TResult> Select<TSource, TResult>(this Activity<IEnumerable<TSource>> source, ActivityFunc<TSource, TResult> select)
        {
            return new SelectActivity<TSource, TResult>(source, select);
        }

        public static SelectActivity<TSource, TResult> Select<TSource, TResult>(this Activity<TSource[]> source, ActivityFunc<TSource, TResult> select)
        {
            return new SelectActivity<TSource, TResult>(Invoke<TSource[], IEnumerable<TSource>>(source, i => i.AsEnumerable()), select);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class SelectActivity<TSource, TResult> :
        NativeActivity<IEnumerable<TResult>>
    {

        readonly Variable<IEnumerator<TSource>> source;
        readonly Variable<LinkedList<TResult>> result;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public SelectActivity()
        {
            source = new Variable<IEnumerator<TSource>>();
            result = new Variable<LinkedList<TResult>>();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="select"></param>
        public SelectActivity(InArgument<IEnumerable<TSource>> source, ActivityFunc<TSource, TResult> select)
            : this()
        {
            Source = source;
            Select = select;
        }

        /// <summary>
        /// Set of values to transform.
        /// </summary>
        [RequiredArgument]
        public InArgument<IEnumerable<TSource>> Source { get; set; }

        /// <summary>
        /// Activity which accepts an item and returns the result.
        /// </summary>
        [RequiredArgument]
        public ActivityFunc<TSource, TResult> Select { get; set; }

        /// <summary>
        /// Creates and validates a description of the <see cref="Activity"/>.
        /// </summary>
        /// <param name="metadata"></param>
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationVariable(source);
            metadata.AddImplementationVariable(result);
        }

        /// <summary>
        /// Runs the <see cref="Activity"/>'s execution logic.
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(NativeActivityContext context)
        {
            var ts = context.GetValue(Source);
            if (ts == null)
                throw new InvalidOperationException($"{nameof(SelectActivity<TSource, TResult>)} requires a non-null value.");

            // execute first item
            var ve = ts.GetEnumerator();
            if (ve.MoveNext())
            {
                context.SetValue(result, new LinkedList<TResult>()); // initialize linked list variable
                context.SetValue(source, ve);
                context.ScheduleFunc(Select, ve.Current, OnSelect);
            }
            else
                // set output empty
                context.SetValue(Result, Enumerable.Empty<TResult>());
        }

        /// <summary>
        /// Invoked when the Select activity func returns a value.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        /// <param name="value"></param>
        void OnSelect(NativeActivityContext context, ActivityInstance completedInstance, TResult value)
        {
            OnSelect(context, completedInstance, source.Get(context), value);
        }

        /// <summary>
        /// Attempts to execute the next item.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        /// <param name="ve"></param>
        void OnSelect(NativeActivityContext context, ActivityInstance completedInstance, IEnumerator<TSource> ve, TResult value)
        {
            // append result to output variable
            if (completedInstance.State == ActivityInstanceState.Closed)
                context.GetValue(result).AddLast(value);

            // cancelation was requested
            if (context.IsCancellationRequested)
            {
                context.MarkCanceled();
                ve.Dispose();
                return;
            }

            // instance was canceled
            if (completedInstance.State == ActivityInstanceState.Canceled)
            {
                context.MarkCanceled();
                ve.Dispose();
                return;
            }

            // instance was faulted
            if (completedInstance.State == ActivityInstanceState.Faulted)
            {
                context.MarkCanceled();
                ve.Dispose();
                return;
            }

            // if next item
            if (ve.MoveNext())
            {
                // schedule next execution
                context.ScheduleFunc(Select, ve.Current, OnSelect);
                return;
            }

            // set final result
            context.SetValue(Result, context.GetValue(result));
            ve.Dispose();
            return;
        }

    }

}
