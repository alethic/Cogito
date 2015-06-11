using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Timers;

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

        static readonly TimeSpan DEFAULT_INTERVAL = TimeSpan.FromMinutes(5);
        static readonly TimeSpan DEFAULT_INITIAL_INTERVAL = TimeSpan.FromSeconds(5);
        static readonly TimeSpan DEFAULT_RETRY_INTERVAL = TimeSpan.FromMinutes(1);
        static readonly TimeSpan DEFAULT_REPEAT_INTERVAL = TimeSpan.FromSeconds(2);

        readonly object sync = new object();
        TimeSpan initialInterval;
        TimeSpan interval;
        TimeSpan retryInterval;
        TimeSpan repeatInterval;
        System.Timers.Timer timer;
        CancellationTokenSource cts;
        bool repeat;
        bool retry;
        bool disposed;

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

            this.interval = interval ?? DEFAULT_INTERVAL;
            this.initialInterval = initialInterval ?? DEFAULT_INITIAL_INTERVAL;
            this.retryInterval = retryInterval ?? DEFAULT_RETRY_INTERVAL;
            this.repeatInterval = repeatInterval ?? DEFAULT_REPEAT_INTERVAL;
        }

        protected override void OnStart()
        {
            lock (sync)
            {
                // dispose of existing timer
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }

                cts = new CancellationTokenSource();
                timer = new System.Timers.Timer();
                timer.Interval = initialInterval.TotalMilliseconds;
                timer.AutoReset = false;
                timer.Elapsed += timer_Elapsed;
                timer.Start();
            }
        }

        protected override void OnStop()
        {
            // signal any outstanding timer invocations to cancel
            if (cts != null)
            {
                cts.Cancel();
                cts = null;
            }

            lock (sync)
            {
                if (cts != null)
                {
                    cts.Cancel();
                    cts = null;
                }

                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }
            }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs args)
        {
            lock (sync)
            {
                // by default do not do fast repeat
                repeat = false;
                retry = false;

                try
                {
                    Trace.TraceInformation("{0}: OnTimer (entered)", GetType().Name);
                    OnTimer(cts.Token);
                    Trace.TraceInformation("{0}: OnTimer (exit)", GetType().Name);
                }
                catch (OperationCanceledException)
                {
                    // ignore
                }
                catch (Exception e)
                {
                    OnException(e);
                }
                finally
                {
                    // resume timer
                    if (timer != null)
                    {
                        timer.Interval = GetNextInterval().TotalMilliseconds;
                        timer.Start();
                    }
                }
            }
        }

        /// <summary>
        /// Gets the appropriate <see cref="TimeSpan"/> for the next interval based on the current state.
        /// </summary>
        /// <returns></returns>
        TimeSpan GetNextInterval()
        {
            if (repeat)
                return repeatInterval;
            else if (retry)
                return retryInterval;
            else
                return interval;
        }

        /// <summary>
        /// Invoked when the timer elapses.
        /// </summary>
        /// <param name="cancellationToken"></param>
        protected virtual void OnTimer(CancellationToken cancellationToken)
        {

        }

        /// <summary>
        /// Invoked when an <see cref="Exception"/> is thrown by the timer.
        /// </summary>
        /// <param name="exception"></param>
        protected virtual void OnException(Exception exception)
        {
            Contract.Requires<ArgumentNullException>(exception != null);

            exception.Trace();

            Retry();
        }

        /// <summary>
        /// Invoked from with the timer method to cause the timer to repeat on the repeat interval.
        /// </summary>
        protected void Repeat()
        {
            repeat = true;
        }

        /// <summary>
        /// Invoked from with the timer method to cause the timer to repeat on the retry interval.
        /// </summary>
        protected void Retry()
        {
            retry = true;
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            lock (sync)
            {
                if (disposed)
                    return;

                if (disposing)
                {
                    if (cts != null)
                    {
                        cts.Cancel();
                        cts = null;
                    }

                    if (timer != null)
                    {
                        timer.Stop();
                        timer.Dispose();
                        timer = null;
                    }
                }

                base.Dispose(disposing);

                disposed = true;
            }
        }

    }

}
