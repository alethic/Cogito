using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

namespace Cogito.Activities
{

    /// <summary>
    /// Executes the given <see cref="Action{T}"/> per element.
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    public class ForEachActionActivity<TElement> :
        NativeActivity<TElement>
    {

        readonly Variable<IEnumerable<TElement>> source;
        readonly ForEach<TElement> forEach;
        readonly ActionActivity<TElement> action;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ForEachActionActivity()
        {
            var arg = new DelegateInArgument<TElement>();

            forEach = new ForEach<TElement>()
            {
                Body = new ActivityAction<TElement>()
                {
                    Argument = arg,
                    Handler = action = new ActionActivity<TElement>(arg),
                },
                Values = source = new Variable<IEnumerable<TElement>>(),
            };
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public ForEachActionActivity(InArgument<IEnumerable<TElement>> source, Action<TElement> action)
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
        public Action<TElement> Action
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
