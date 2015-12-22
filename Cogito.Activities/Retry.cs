using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cogito.Activities
{

    public class Retry :
        NativeActivity
    {

        Variable<int> attempts;
        Variable<List<Exception>> exceptions;

        /// <summary>
        /// Number of tries to attempt.
        /// </summary>
        [DefaultValue(1)]
        public InArgument<int> MaxAttempts { get; set; }

        /// <summary>
        /// Number of attempts that were made.
        /// </summary>
        public OutArgument<int> Attempts { get; set; }

        /// <summary>
        /// Body to execute.
        /// </summary>
        [RequiredArgument]
        public Activity Body { get; set; }

        /// <summary>
        /// Aggregate of exceptions that occurred during retry.
        /// </summary>
        public OutArgument<IEnumerable<Exception>> Exceptions { get; set; }

        /// <summary>
        /// Executed when an exception occurs.
        /// </summary>
        public ActivityAction<Exception> OnException { get; set; }

        /// <summary>
        /// Creates and validates a description of the <see cref="Activity"/>.
        /// </summary>
        /// <param name="metadata"></param>
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationVariable(attempts = new Variable<int>());
            metadata.AddImplementationVariable(exceptions = new Variable<List<Exception>>());
        }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        /// <summary>
        /// Executes the <see cref="Activity"/>.
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(NativeActivityContext context)
        {
            context.SetValue(attempts, 0);
            context.SetValue(exceptions, new List<Exception>());
            TryScheduleBody(context);
        }

        /// <summary>
        /// Invoked when the body completes.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="instance"></param>
        void OnBodyCompleted(NativeActivityContext context, ActivityInstance instance)
        {
            if (instance.State != ActivityInstanceState.Faulted)
                BeforeExit(context);
        }

        /// <summary>
        /// Invoked when an error occurs in the body.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="propagatedException"></param>
        /// <param name="propagatedFrom"></param>
        void OnBodyFaulted(NativeActivityFaultContext context, Exception propagatedException, ActivityInstance propagatedFrom)
        {
            // clear out children faults, we will expose our own
            context.HandleFault();
            context.CancelChild(propagatedFrom);

            // record exception
            exceptions.Get(context).Add(propagatedException);

            // if user wants to be notified upon an exception
            if (OnException != null)
            {
                // dispatch to exception handler, which will handle, and then retry the body
                context.ScheduleAction(OnException, propagatedException, OnExceptionCompleted);
                return;
            }

            // schedule the body to execute again
            TryScheduleBody(context);
        }

        /// <summary>
        /// Invoked when the exception handler is complete.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        void OnExceptionCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            TryScheduleBody(context);
        }

        /// <summary>
        /// Schedules the body to execute, after decrementing the attempts counter
        /// </summary>
        /// <param name="context"></param>
        void TryScheduleBody(NativeActivityContext context)
        {
            if (attempts.Get(context) < MaxAttempts.Get(context))
            {
                context.SetValue(attempts, context.GetValue(attempts) + 1);
                context.ScheduleActivity(Body, OnBodyCompleted, OnBodyFaulted);
            }
            else
            {
                BeforeExit(context);

                // throw exception if there are any
                var l = exceptions.Get(context);
                if (l.Count > 0)
                    throw new RetryException(attempts.Get(context), l);
            }
        }

        /// <summary>
        /// Executes just before the activity is to be closed.
        /// </summary>
        /// <param name="context"></param>
        void BeforeExit(NativeActivityContext context)
        {
            context.SetValue(Attempts, context.GetValue(attempts));
            context.SetValue(Exceptions, exceptions.Get(context));
        }

    }

    public class Retry<TResult> :
        NativeActivity<TResult>
    {

        protected override void Execute(NativeActivityContext context)
        {
            throw new NotImplementedException();
        }

    }

}
