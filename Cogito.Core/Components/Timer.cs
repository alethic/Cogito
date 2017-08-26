using System;
using System.Threading;

namespace Cogito.Components
{

    /// <summary>
    /// Extend this class to implement a component which periodically raises a timer event.
    /// </summary>
    public abstract class Timer :
        Component
    {

        Cogito.Threading.Timer timer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="initialInterval"></param>
        /// <param name="retryInterval"></param>
        /// <param name="repeatInterval"></param>
        public Timer(
            TimeSpan? interval = null,
            TimeSpan? initialInterval = null,
            TimeSpan? retryInterval = null,
            TimeSpan? repeatInterval = null)
        {
            // initialize a new internal timer
            timer = new Threading.Timer(
                interval,
                initialInterval,
                retryInterval,
                repeatInterval);

            // subscribe to events of timer
            timer.Starting += (s, a) => OnStarting();
            timer.Stopped += (s, a) => OnStopped();
            timer.Elapsed += (s, a) => OnElapsed(a.CancellationToken);
            timer.Exception += (s, a) => OnException(a.Exception);
        }

        public override void Start()
        {
            timer.Start();
        }

        public override void Stop()
        {
            timer.Stop();
        }

        /// <summary>
        /// Invoked when the timer is starting.
        /// </summary>
        protected virtual void OnStarting()
        {

        }

        /// <summary>
        /// Invoked when the timer elapses.
        /// </summary>
        /// <param name="cancellationToken"></param>
        protected virtual void OnElapsed(CancellationToken cancellationToken)
        {

        }

        /// <summary>
        /// Invoked when the timer is stopped.
        /// </summary>
        protected virtual void OnStopped()
        {

        }

        /// <summary>
        /// Invoked when an <see cref="Exception"/> is thrown by the timer. By default this schedules a retry at the retry interval.
        /// </summary>
        /// <param name="exception"></param>
        protected virtual void OnException(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            Retry();
        }

        /// <summary>
        /// Invoke from with the timer method to cause the timer to repeat on the repeat interval.
        /// </summary>
        protected void Repeat()
        {
            timer.Repeat();
        }

        /// <summary>
        /// Invoke from with the timer method to cause the timer to repeat on the retry interval.
        /// </summary>
        protected void Retry()
        {
            timer.Retry();
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }
            }
        }

    }

}
