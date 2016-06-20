using System;
using System.Activities;
using System.Windows.Markup;

namespace Cogito.Activities
{

    /// <summary>
    /// Represents a handled exception on a <see cref="Retry"/>.
    /// </summary>
    public abstract class RetryCatch
    {

        /// <summary>
        /// Gets the type of <see cref="Exception"/> to handle.
        /// </summary>
        public abstract Type ExceptionType { get; }

        /// <summary>
        /// Gets a <see cref="ActivityDelegate"/> for this <see cref="RetryCatch"/>.
        /// </summary>
        /// <returns></returns>
        internal abstract ActivityDelegate GetAction();

        /// <summary>
        /// Schedules the <see cref="ActivityAction{Exception}"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <param name="attempts"></param>
        /// <param name="completionCallback"></param>
        /// <param name="faultCallback"></param>
        internal abstract void ScheduleAction(NativeActivityContext context, Exception exception, int attempts, CompletionCallback completionCallback, FaultCallback faultCallback);

    }

    /// <summary>
    /// Represents a handled exception on a <see cref="Retry"/>.
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    [ContentProperty("Action")]
    public class RetryCatch<TException> :
        RetryCatch
        where TException : Exception
    {

        /// <summary>
        /// Gets the type of <see cref="Exception"/> to handle.
        /// </summary>
        public override Type ExceptionType
        {
            get { return typeof(TException); }
        }

        /// <summary>
        /// Gets a <see cref="ActivityAction"/> for this <see cref="RetryCatch"/>.
        /// </summary>
        /// <returns></returns>
        internal override ActivityDelegate GetAction()
        {
            return Action;
        }

        /// <summary>
        /// <see cref="ActivityAction{TException}"/> to be executed.
        /// </summary>
        public ActivityAction<TException, int> Action { get; set; }

        /// <summary>
        /// Schedules the <see cref="ActivityAction{Exception}"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <param name="attempts"></param>
        /// <param name="completionCallback"></param>
        /// <param name="faultCallback"></param>
        internal override void ScheduleAction(NativeActivityContext context, Exception exception, int attempts, CompletionCallback completionCallback, FaultCallback faultCallback)
        {
            if (Action != null)
                context.ScheduleAction(Action, (TException)exception, attempts, completionCallback, faultCallback);
            else
                completionCallback(context, null);
        }

    }

}
