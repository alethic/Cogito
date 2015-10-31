using System;
using System.Diagnostics.Contracts;
using System.Threading;

using Cogito.Components;

namespace Cogito.ServiceBus.Components
{

    /// <summary>
    /// Extend this class to implement a component which runs on a single node and periodically raises a timer event.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    public abstract class SingleNodeTimer<TComponent> :
        DistributedComponent<TComponent>
        where TComponent : IComponent
    {

        Cogito.Threading.Timer timer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="interval"></param>
        /// <param name="initialInterval"></param>
        /// <param name="retryInterval"></param>
        /// <param name="repeatInterval"></param>
        public SingleNodeTimer(
            SingleNodeTimerManager<TComponent> manager,
            TimeSpan? interval = null,
            TimeSpan? initialInterval = null,
            TimeSpan? retryInterval = null,
            TimeSpan? repeatInterval = null)
            : base(manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null);

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

        protected override void OnStart()
        {
            timer.Start();
        }

        protected override void OnStop()
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
        /// Invoked when an <see cref="Exception"/> is thrown by the timer. By default this method schedules a retry
        /// at the retry interval.
        /// </summary>
        /// <param name="exception"></param>
        protected virtual void OnException(Exception exception)
        {
            Contract.Requires<ArgumentNullException>(exception != null);

            Retry();
        }

        /// <summary>
        /// Invoked from with the timer method to cause the timer to repeat on the repeat interval.
        /// </summary>
        protected void Repeat()
        {
            timer.Repeat();
        }

        /// <summary>
        /// Invoked from with the timer method to cause the timer to repeat on the retry interval.
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
                    timer = null;
                }
            }
        }

    }

}
