using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    /// <summary>
    /// Executes the given <see cref="Action{T}"/> per element.
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    public class ForEachAsyncActionActivity<TElement> :
        NativeActivity<TElement>
    {

        readonly Variable<IEnumerable<TElement>> source;
        readonly ForEach<TElement> forEach;
        readonly AsyncActionActivity<TElement> action;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ForEachAsyncActionActivity()
        {
            var arg = new DelegateInArgument<TElement>();

            forEach = new ForEach<TElement>()
            {
                Body = new ActivityAction<TElement>()
                {
                    Argument = arg,
                    Handler = action = new AsyncActionActivity<TElement>(arg),
                },
                Values = source = new Variable<IEnumerable<TElement>>(),
            };
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public ForEachAsyncActionActivity(InArgument<IEnumerable<TElement>> source, Func<TElement, Task> action)
        {
            Source = source;
            Action = action;
        }

        /// <summary>
        /// Gets the set of elements to execute for.
        /// </summary>
        [RequiredArgument]
        public InArgument<IEnumerable<TElement>> Source { get; set; }

        /// <summary>
        /// The <see cref="Action"/> to invoke for each element.
        /// </summary>
        [RequiredArgument]
        public Func<TElement, Task> Action
        {
            get { return action.Action; }
            set { action.Action = value; }
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationVariable(source);
            metadata.AddImplementationChild(forEach);
            metadata.AddImplementationChild(action);
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.SetValue(source, context.GetValue(Source));
            context.ScheduleActivity(forEach);
        }

    }

}
