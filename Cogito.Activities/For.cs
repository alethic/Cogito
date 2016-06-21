using System;
using System.Activities;
using System.Activities.Validation;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Creates a for loop.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="initial"></param>
        /// <param name="condition"></param>
        /// <param name="increment"></param>
        /// <param name="createAction"></param>
        /// <returns></returns>
        public static For<TValue> For<TValue>(
            InArgument<TValue> initial,
            Func<TValue, bool> condition,
            Func<TValue, TValue> increment,
            Func<InArgument<TValue>, Activity> createAction)
        {
            Contract.Requires<ArgumentNullException>(initial != null);
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(increment != null);
            Contract.Requires<ArgumentNullException>(createAction != null);

            return For(
                initial,
                Delegate<TValue, bool>(arg => Invoke(condition, arg)),
                Delegate<TValue, TValue>(arg => Invoke(increment, arg)),
                createAction);
        }

        /// <summary>
        /// Creates a for loop.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="initial"></param>
        /// <param name="condition"></param>
        /// <param name="increment"></param>
        /// <param name="createAction"></param>
        /// <returns></returns>
        public static For<TValue> For<TValue>(
            InArgument<TValue> initial,
            ActivityFunc<TValue, bool> condition,
            ActivityFunc<TValue, TValue> increment,
            Func<InArgument<TValue>, Activity> createAction)
        {
            Contract.Requires<ArgumentNullException>(initial != null);
            Contract.Requires<ArgumentNullException>(condition != null);
            Contract.Requires<ArgumentNullException>(increment != null);
            Contract.Requires<ArgumentNullException>(createAction != null);

            return new For<TValue>()
            {
                Initial = initial,
                Condition = condition,
                Increment = increment,
                Action = Delegate(createAction),
            };
        }

    }

    /// <summary>
    /// Implements a for loop.
    /// </summary>
    public class For<TValue> :
        NativeActivity
    {

        readonly Variable<TValue> current = new Variable<TValue>();

        /// <summary>
        /// Integer value to start at.
        /// </summary>
        [DefaultValue(0)]
        public InArgument<TValue> Initial { get; set; }

        /// <summary>
        /// Returns <c>true</c> if the loop should continue.
        /// </summary>
        [RequiredArgument]
        public ActivityFunc<TValue, bool> Condition { get; set; }

        /// <summary>
        /// Gets the next value in the loop.
        /// </summary>
        [RequiredArgument]
        public ActivityFunc<TValue, TValue> Increment { get; set; }

        /// <summary>
        /// Execute this repeatidly.
        /// </summary>
        [RequiredArgument]
        public ActivityAction<TValue> Action { get; set; }

        /// <summary>
        /// Caches the metadata.
        /// </summary>
        /// <param name="metadata"></param>
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationVariable(current);

            if (Initial == null)
                metadata.AddValidationError(new ValidationError("Initial value must be provided.", false, "Initial"));

            if (Condition == null)
                metadata.AddValidationError(new ValidationError("Conditional function must be provided.", false, "Condition"));

            if (Increment == null)
                metadata.AddValidationError(new ValidationError("Increment function must be provided", false, "Increment"));

            if (Action == null)
                metadata.AddValidationError(new ValidationError("Action must be provided.", false, "Action"));
        }

        /// <summary>
        /// Implements the activity.
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(NativeActivityContext context)
        {
            // set index to starting position
            current.Set(context, Initial.Get(context));
            context.ScheduleFunc(Condition, current.Get(context), OnConditionCompleted);
        }

        /// <summary>
        /// Invoked when the conditional is completed.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        void OnConditionCompleted(NativeActivityContext context, ActivityInstance completedInstance, bool value)
        {
            if (value)
                context.ScheduleAction(Action, current.Get(context), OnActionCompleted);
        }

        /// <summary>
        /// Invoked when the action is completed.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        void OnActionCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            context.ScheduleFunc(Increment, current.Get(context), OnIncrementCompleted);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        /// <param name="value"></param>
        void OnIncrementCompleted(NativeActivityContext context, ActivityInstance completedInstance, TValue value)
        {
            current.Set(context, value);
            context.ScheduleFunc(Condition, current.Get(context), OnConditionCompleted);
        }

    }

}
