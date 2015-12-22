using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Cogito.Activities
{

    public class Retry :
        NativeActivity
    {

        Variable<int> attempts = new Variable<int>();
        Variable<List<Exception>> exceptions = new Variable<List<Exception>>();

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
        /// Collection of <see cref="RetryCatch"/> elements used to handle exceptions.
        /// </summary>
        public Collection<RetryCatch> Catches { get; } = new Collection<RetryCatch>();

        /// <summary>
        /// Creates and validates a description of the <see cref="Activity"/>.
        /// </summary>
        /// <param name="metadata"></param>
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddImplementationVariable(attempts);
            metadata.AddImplementationVariable(exceptions);
            metadata.SetDelegatesCollection(new Collection<ActivityDelegate>(Catches.Select(i => i.GetAction()).ToList()));
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
            var c = FindCatch(propagatedException);
            if (c != null)
            {
                // dispatch to exception handler, which will handle, and then retry the body
                c.ScheduleAction(context, propagatedException, OnCatchComplete, OnCatchFault);
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
        void OnCatchComplete(NativeActivityContext context, ActivityInstance completedInstance)
        {
            TryScheduleBody(context);
        }

        /// <summary>
        /// Invoked when a <see cref="RetryCatch"/> faultssss.
        /// </summary>
        /// <param name="faultContext"></param>
        /// <param name="propagatedException"></param>
        /// <param name="propagatedFrom"></param>
        void OnCatchFault(NativeActivityFaultContext faultContext, Exception propagatedException, ActivityInstance propagatedFrom)
        {

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

        /// <summary>
        /// Finds the <see cref="RetryCatch"/> object that will handle the given <see cref="Exception"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        RetryCatch FindCatch(Exception exception)
        {
            return Catches.FirstOrDefault(i => i.ExceptionType == exception.GetType() || i.ExceptionType.IsAssignableFrom(exception.GetType()));
        }

    }

}
