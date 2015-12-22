using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Cogito.Activities
{



    public static partial class Activities
    {

        /// <summary>
        /// Retries the previous activity <paramref name="maxAttempts"/> number of times.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="maxAttempts"></param>
        /// <param name="catches"></param>
        /// <returns></returns>
        public static Retry Retry(this ActivityAction<int> activity, InArgument<int> maxAttempts, InArgument<TimeSpan> delay, params RetryCatch[] catches)
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(maxAttempts != null);
            Contract.Requires<ArgumentNullException>(catches != null);

            var retry = new Retry()
            {
                Body = activity,
                MaxAttempts = maxAttempts,
                Delay = delay,
            };

            foreach (var i in catches)
                retry.Catches.Add(i);

            return retry;
        }

        /// <summary>
        /// Retries the previous activity <paramref name="maxAttempts"/> number of times.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="maxAttempts"></param>
        /// <param name="delay"></param>
        /// <param name="catches"></param>
        /// <returns></returns>
        public static Retry Retry(this Activity activity, InArgument<int> maxAttempts, InArgument<TimeSpan> delay, params RetryCatch[] catches)
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(maxAttempts != null);
            Contract.Requires<ArgumentNullException>(catches != null);

            return Retry(Delegate<int>(arg => activity), maxAttempts, delay, catches);
        }

        /// <summary>
        /// Retries the previous activity <paramref name="maxAttempts"/> number of times.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="maxAttempts"></param>
        /// <param name="catches"></param>
        /// <returns></returns>
        public static Retry Retry(this Activity activity, InArgument<int> maxAttempts, params RetryCatch[] catches)
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(maxAttempts != null);
            Contract.Requires<ArgumentNullException>(catches != null);

            return Retry(activity, maxAttempts, null, catches);
        }

        /// <summary>
        /// Retries the previous activity <paramref name="maxAttempts"/> number of times.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="maxAttempts"></param>
        /// <param name="delay"></param>
        /// <param name="catch"></param>
        /// <returns></returns>
        public static Retry Retry<TException>(this ActivityAction<int> activity, InArgument<int> maxAttempts, InArgument<TimeSpan> delay, ActivityAction<TException, int> @catch)
            where TException : Exception
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(maxAttempts != null);
            Contract.Requires<ArgumentNullException>(@catch != null);

            return Retry(activity, maxAttempts, delay, new RetryCatch<TException>() { Action = @catch });
        }

        /// <summary>
        /// Retries the previous activity <paramref name="maxAttempts"/> number of times.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="maxAttempts"></param>
        /// <param name="catch"></param>
        /// <returns></returns>
        public static Retry Retry<TException>(this ActivityAction<int> activity, InArgument<int> maxAttempts, ActivityAction<TException, int> @catch)
            where TException : Exception
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(maxAttempts != null);
            Contract.Requires<ArgumentNullException>(@catch != null);

            return Retry(activity, maxAttempts, null, @catch);
        }

        /// <summary>
        /// Retries the previous activity <paramref name="maxAttempts"/> number of times.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="maxAttempts"></param>
        /// <param name="delay"></param>
        /// <param name="catch"></param>
        /// <returns></returns>
        public static Retry Retry<TException>(this Activity activity, InArgument<int> maxAttempts, InArgument<TimeSpan> delay, ActivityAction<TException, int> @catch)
            where TException : Exception
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(maxAttempts != null);
            Contract.Requires<ArgumentNullException>(@catch != null);

            return Retry(activity, maxAttempts, delay, new RetryCatch<TException>() { Action = @catch });
        }

        /// <summary>
        /// Retries the previous activity <paramref name="maxAttempts"/> number of times.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="maxAttempts"></param>
        /// <param name="delay"></param>
        /// <param name="catch"></param>
        /// <returns></returns>
        public static Retry Retry<TException>(this Activity activity, InArgument<int> maxAttempts, ActivityAction<TException, int> @catch)
            where TException : Exception
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(maxAttempts != null);
            Contract.Requires<ArgumentNullException>(@catch != null);

            return Retry(activity, maxAttempts, null, @catch);
        }

        /// <summary>
        /// Sets the delay between retries.
        /// </summary>
        /// <param name="retry"></param>
        /// <param name="maxAttempts"></param>
        /// <returns></returns>
        public static Retry WithAttempts(this Retry retry, InArgument<int> maxAttempts)
        {
            Contract.Requires<ArgumentNullException>(retry != null);
            Contract.Requires<ArgumentNullException>(maxAttempts != null);

            retry.MaxAttempts = maxAttempts;
            return retry;
        }

        /// <summary>
        /// Sets the delay between retries.
        /// </summary>
        /// <param name="retry"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static Retry WithDelay(this Retry retry, InArgument<TimeSpan> delay)
        {
            Contract.Requires<ArgumentNullException>(retry != null);
            Contract.Requires<ArgumentNullException>(delay != null);

            retry.Delay = delay;
            return retry;
        }

        /// <summary>
        /// Handles a <see cref="Exception"/> for the given <see cref="Retry"/>.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="retry"></param>
        /// <param name="maxAttempts"></param>
        /// <param name="catch"></param>
        /// <returns></returns>
        public static Retry Catch<TException>(this Retry retry, ActivityAction<TException, int> @catch)
            where TException : Exception
        {
            Contract.Requires<ArgumentNullException>(retry != null);
            Contract.Requires<ArgumentNullException>(@catch != null);

            retry.Catches.Add(new RetryCatch<TException>() { Action = @catch });
            return retry;
        }

        /// <summary>
        /// Handles a <see cref="Exception"/> for the given <see cref="Retry"/>.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="retry"></param>
        /// <param name="catch"></param>
        /// <returns></returns>
        public static Retry Catch<TException>(this Retry retry, Activity @catch)
            where TException : Exception
        {
            Contract.Requires<ArgumentNullException>(retry != null);
            Contract.Requires<ArgumentNullException>(@catch != null);

            return Catch(retry, Delegate<Exception, int>((attempts, exception) => @catch));
        }

        /// <summary>
        /// Handles a <see cref="Exception"/> for the given <see cref="Retry"/>.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="retry"></param>
        /// <param name="catch"></param>
        /// <returns></returns>
        public static Retry Catch<TException>(this Retry retry, Action<TException> @catch)
            where TException : Exception
        {
            Contract.Requires<ArgumentNullException>(retry != null);
            Contract.Requires<ArgumentNullException>(@catch != null);

            return Catch(retry, Delegate<TException, int>((attempts, exception) => Invoke(@catch, exception)));
        }

        /// <summary>
        /// Handles a <see cref="Exception"/> for the given <see cref="Retry"/>.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="retry"></param>
        /// <param name="catch"></param>
        /// <returns></returns>
        public static Retry Catch<TException>(this Retry retry, Action<TException, int> @catch)
            where TException : Exception
        {
            Contract.Requires<ArgumentNullException>(retry != null);
            Contract.Requires<ArgumentNullException>(@catch != null);

            return Catch(retry, Delegate<TException, int>((exception, attempts) => Invoke(@catch, exception, attempts)));
        }

        /// <summary>
        /// Handles a <see cref="Exception"/> for the given <see cref="Retry"/>.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="retry"></param>
        /// <param name="catch"></param>
        /// <returns></returns>
        public static Retry Catch<TException>(this Retry retry, Func<TException, Task> @catch)
            where TException : Exception
        {
            Contract.Requires<ArgumentNullException>(retry != null);
            Contract.Requires<ArgumentNullException>(@catch != null);

            return Catch(retry, Delegate<TException, int>((exception, attempts) => Invoke(@catch, exception)));
        }

        /// <summary>
        /// Handles a <see cref="Exception"/> for the given <see cref="Retry"/>.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="retry"></param>
        /// <param name="catch"></param>
        /// <returns></returns>
        public static Retry Catch<TException>(this Retry retry, Func<TException, int, Task> @catch)
            where TException : Exception
        {
            Contract.Requires<ArgumentNullException>(retry != null);
            Contract.Requires<ArgumentNullException>(@catch != null);

            return Catch(retry, Delegate<TException, int>((exception, attempts) => Invoke(@catch, exception, attempts)));
        }

    }

    /// <summary>
    /// Retries the body a number of times before faulting.
    /// </summary>
    public class Retry :
        NativeActivity
    {

        Variable<int> attempts = new Variable<int>();
        Variable<List<Exception>> exceptions = new Variable<List<Exception>>();
        Delay delay;

        /// <summary>
        /// Number of tries to attempt.
        /// </summary>
        [DefaultValue(1)]
        public InArgument<int> MaxAttempts { get; set; }

        /// <summary>
        /// Amount of time to delay before retrying again.
        /// </summary>
        public InArgument<TimeSpan> Delay { get; set; }

        /// <summary>
        /// Number of attempts that were made.
        /// </summary>
        public OutArgument<int> Attempts { get; set; }

        /// <summary>
        /// Body to execute.
        /// </summary>
        [RequiredArgument]
        public ActivityAction<int> Body { get; set; }

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
            metadata.AddImplementationChild(delay = new Delay() { Duration = new InArgument<TimeSpan>(ctx => ctx.GetValue(Delay)) });
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
                c.ScheduleAction(context, propagatedException, context.GetValue(attempts), OnCatchComplete, OnCatchFault);
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
            if (Delay != null)
                context.ScheduleActivity(delay, OnDelayComplete);
            else
                TryScheduleBody(context);
        }

        /// <summary>
        /// Invoked when the delay is complete.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        void OnDelayComplete(NativeActivityContext context, ActivityInstance completedInstance)
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
                context.ScheduleAction(Body, context.GetValue(attempts), OnBodyCompleted, OnBodyFaulted);
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

    /// <summary>
    /// Retries the body a number of times before faulting.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class Retry<TResult> :
        NativeActivity<TResult>
    {

        Variable<int> attempts = new Variable<int>();
        Variable<List<Exception>> exceptions = new Variable<List<Exception>>();
        Delay delay;

        /// <summary>
        /// Number of tries to attempt.
        /// </summary>
        [DefaultValue(1)]
        public InArgument<int> MaxAttempts { get; set; }

        /// <summary>
        /// Amount of time to delay before retrying again.
        /// </summary>
        public InArgument<TimeSpan> Delay { get; set; }

        /// <summary>
        /// Number of attempts that were made.
        /// </summary>
        public OutArgument<int> Attempts { get; set; }

        /// <summary>
        /// Body to execute.
        /// </summary>
        [RequiredArgument]
        public ActivityFunc<int, TResult> Body { get; set; }

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
            metadata.AddImplementationChild(delay = new Delay() { Duration = new InArgument<TimeSpan>(ctx => ctx.GetValue(Delay)) });
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
        void OnBodyCompleted(NativeActivityContext context, ActivityInstance instance, TResult result)
        {
            if (instance.State != ActivityInstanceState.Faulted)
            {
                BeforeExit(context);
                Result.Set(context, result);
            }
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
                c.ScheduleAction(context, propagatedException, context.GetValue(attempts), OnCatchComplete, OnCatchFault);
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
            if (Delay != null)
                context.ScheduleActivity(delay, OnDelayComplete);
            else
                TryScheduleBody(context);
        }

        /// <summary>
        /// Invoked when the delay is complete.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        void OnDelayComplete(NativeActivityContext context, ActivityInstance completedInstance)
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
                context.ScheduleFunc(Body, context.GetValue(attempts), OnBodyCompleted, OnBodyFaulted);
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
