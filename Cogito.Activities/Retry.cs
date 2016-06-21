using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
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
        /// <returns></returns>
        public static Retry Catch<TException>(this Retry retry)
            where TException : Exception
        {
            Contract.Requires<ArgumentNullException>(retry != null);

            retry.Catches.Add(new RetryCatch<TException>() { Action = null });
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

            return Catch(retry, Delegate<TException, int>((exception, attempts) => @catch));
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

            return Catch(retry, Delegate<TException, int>((exception, attempts) => Invoke(@catch, exception)));
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

        Variable<RetryState> state = new Variable<RetryState>();
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
        /// Body to execute.
        /// </summary>
        [RequiredArgument]
        public ActivityAction<int> Body { get; set; }

        /// <summary>
        /// Exceptions that occurred during retry.
        /// </summary>
        public OutArgument<Exception[]> Attempts { get; set; }

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
            metadata.AddImplementationVariable(state);
            metadata.AddImplementationChild(delay = new Delay() { Duration = new InArgument<TimeSpan>(ctx => ctx.GetValue(Delay)) });
            metadata.SetDelegatesCollection(new Collection<ActivityDelegate>(Catches.Select(i => i.GetAction()).ToList()));
            metadata.AddDelegate(Body);
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
            // initialize current state
            state.Set(context, new RetryState());

            // begin by scheduling body execution
            NextExecution(context);
        }

        /// <summary>
        /// Returns <c>true</c> if we have not hit our execution limit.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        bool ExecuteAgain(NativeActivityContext context)
        {
            return state.Get(context).Attempts.Count() < MaxAttempts.Get(context);
        }

        /// <summary>
        /// Invoked when the body completes.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="instance"></param>
        void OnBodyCompleted(NativeActivityContext context, ActivityInstance instance)
        {
            var state = this.state.Get(context);
            state.SuppressCancel = true;

            // we caught an exception
            var e = state.CaughtException;
            if (e != null)
            {
                // forget caught exception
                state.CaughtException = null;

                // discover if exception is handled
                var c = FindCatch(e);
                if (c != null)
                {
                    // record exception
                    state.Attempts.Add(e);

                    // signal that we have handled an exception, cancel child
                    context.Track(new RetryExceptionCaughtTrackingRecord(e, state.Attempts.Count()));

                    // dispatch to exception handler, which will handle, and then retry the body
                    c.ScheduleAction(context, e, state.Attempts.Count(), OnCatchComplete, OnCatchFault);
                }
            }
            else
            {
                BeforeExit(context);
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
            var state = this.state.Get(context);

            // discover if exception is handled, if so cancel children and record
            var c = FindCatch(propagatedException);
            if (c != null)
            {
                context.CancelChild(propagatedFrom);
                state.CaughtException = propagatedException;
                context.HandleFault();
            }
        }

        /// <summary>
        /// Invoked when the exception handler is complete.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        void OnCatchComplete(NativeActivityContext context, ActivityInstance completedInstance)
        {
            var state = this.state.Get(context);

            // should we delay, and are we going to be running again?
            if (Delay != null)
            {
                if (ExecuteAgain(context))
                    context.ScheduleActivity(delay, OnDelayComplete);
                else
                    OnDelayComplete(context, null);
            }
            else
                NextExecution(context);
        }

        /// <summary>
        /// Invoked when a <see cref="RetryCatch"/> faultssss.
        /// </summary>
        /// <param name="faultContext"></param>
        /// <param name="propagatedException"></param>
        /// <param name="propagatedFrom"></param>
        void OnCatchFault(NativeActivityFaultContext faultContext, Exception propagatedException, ActivityInstance propagatedFrom)
        {
            var state = this.state.Get(faultContext);

            // append new exception to exception list
            if (propagatedException != null)
                state.Attempts.Add(propagatedException);

            // do not handle, allow to fail
            BeforeExit(faultContext);
        }

        /// <summary>
        /// Invoked when the delay is complete.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        void OnDelayComplete(NativeActivityContext context, ActivityInstance completedInstance)
        {
            NextExecution(context);
        }

        /// <summary>
        /// Schedules the body to execute, after decrementing the attempts counter.
        /// </summary>
        /// <param name="context"></param>
        void NextExecution(NativeActivityContext context)
        {
            var state = this.state.Get(context);

            if (ExecuteAgain(context))
            {
                context.ScheduleAction(Body, state.Attempts.Count() + 1, OnBodyCompleted, OnBodyFaulted);
            }
            else
            {
                BeforeExit(context);
                ThrowFinal(context);
            }
        }

        /// <summary>
        /// Executes just before the activity is to be closed.
        /// </summary>
        /// <param name="context"></param>
        void BeforeExit(NativeActivityContext context)
        {
            var state = this.state.Get(context);

            context.SetValue(Attempts, state.Attempts.ToArray());
        }

        /// <summary>
        /// Throws any final exceptions if they exist.
        /// </summary>
        /// <param name="context"></param>
        void ThrowFinal(NativeActivityContext context)
        {
            var state = this.state.Get(context);
            if (state.Attempts.Count > 0)
                throw new RetryException(state.Attempts);
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

        Variable<RetryState> state = new Variable<RetryState>();
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
        /// Body to execute.
        /// </summary>
        [RequiredArgument]
        public ActivityFunc<int, TResult> Body { get; set; }

        /// <summary>
        /// Exceptions that occurred during retry.
        /// </summary>
        public OutArgument<Exception[]> Attempts { get; set; }

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
            metadata.AddImplementationVariable(state);
            metadata.AddImplementationChild(delay = new Delay() { Duration = new InArgument<TimeSpan>(ctx => ctx.GetValue(Delay)) });
            metadata.SetDelegatesCollection(new Collection<ActivityDelegate>(Catches.Select(i => i.GetAction()).ToList()));
            metadata.AddDelegate(Body);
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
            // initialize current state
            state.Set(context, new RetryState());

            // begin by scheduling body execution
            NextExecution(context);
        }

        /// <summary>
        /// Returns <c>true</c> if we have not hit our execution limit.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        bool ExecuteAgain(NativeActivityContext context)
        {
            return state.Get(context).Attempts.Count() < MaxAttempts.Get(context);
        }

        /// <summary>
        /// Invoked when the body completes.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="instance"></param>
        /// <param name="result"></param>
        void OnBodyCompleted(NativeActivityContext context, ActivityInstance instance, TResult result)
        {
            var state = this.state.Get(context);
            state.SuppressCancel = true;

            // we caught an exception
            var e = state.CaughtException;
            if (e != null)
            {
                // forget caught exception
                state.CaughtException = null;

                // discover if exception is handled
                var c = FindCatch(e);
                if (c != null)
                {
                    // record exception
                    state.Attempts.Add(e);

                    // signal that we have handled an exception, cancel child
                    context.Track(new RetryExceptionCaughtTrackingRecord(e, state.Attempts.Count()));

                    // dispatch to exception handler, which will handle, and then retry the body
                    c.ScheduleAction(context, e, state.Attempts.Count(), OnCatchComplete, OnCatchFault);
                }
            }
            else
            {
                Result.Set(context, result);
                BeforeExit(context);
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
            var state = this.state.Get(context);

            // discover if exception is handled, if so cancel children and record
            var c = FindCatch(propagatedException);
            if (c != null)
            {
                context.CancelChild(propagatedFrom);
                state.CaughtException = propagatedException;
                context.HandleFault();
            }
        }

        /// <summary>
        /// Invoked when the exception handler is complete.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        void OnCatchComplete(NativeActivityContext context, ActivityInstance completedInstance)
        {
            var state = this.state.Get(context);

            // should we delay, and are we going to be running again?
            if (Delay != null)
            {
                if (ExecuteAgain(context))
                    context.ScheduleActivity(delay, OnDelayComplete);
                else
                    OnDelayComplete(context, null);
            }
            else
                NextExecution(context);
        }

        /// <summary>
        /// Invoked when a <see cref="RetryCatch"/> faultssss.
        /// </summary>
        /// <param name="faultContext"></param>
        /// <param name="propagatedException"></param>
        /// <param name="propagatedFrom"></param>
        void OnCatchFault(NativeActivityFaultContext faultContext, Exception propagatedException, ActivityInstance propagatedFrom)
        {
            var state = this.state.Get(faultContext);

            // append new exception to exception list
            if (propagatedException != null)
                state.Attempts.Add(propagatedException);

            // do not handle, allow to fail
            BeforeExit(faultContext);
        }

        /// <summary>
        /// Invoked when the delay is complete.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        void OnDelayComplete(NativeActivityContext context, ActivityInstance completedInstance)
        {
            NextExecution(context);
        }

        /// <summary>
        /// Schedules the body to execute, after decrementing the attempts counter.
        /// </summary>
        /// <param name="context"></param>
        void NextExecution(NativeActivityContext context)
        {
            var state = this.state.Get(context);

            if (ExecuteAgain(context))
            {
                context.ScheduleFunc(Body, state.Attempts.Count() + 1, OnBodyCompleted, OnBodyFaulted);
            }
            else
            {
                BeforeExit(context);
                ThrowFinal(context);
            }
        }

        /// <summary>
        /// Executes just before the activity is to be closed.
        /// </summary>
        /// <param name="context"></param>
        void BeforeExit(NativeActivityContext context)
        {
            var state = this.state.Get(context);

            context.SetValue(Attempts, state.Attempts.ToArray());
        }

        /// <summary>
        /// Throws any final exceptions if they exist.
        /// </summary>
        /// <param name="context"></param>
        void ThrowFinal(NativeActivityContext context)
        {
            var state = this.state.Get(context);
            if (state.Attempts.Count > 0)
                throw new RetryException(state.Attempts);
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
