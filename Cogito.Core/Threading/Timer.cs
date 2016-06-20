using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Timers;

namespace Cogito.Threading
{

    /// <summary>
    /// Provides an event timer with advanced features.
    /// </summary>
    public class Timer
    {

        public static readonly TimeSpan DEFAULT_INTERVAL = TimeSpan.FromMinutes(5);
        public static readonly TimeSpan DEFAULT_INITIAL_INTERVAL = TimeSpan.FromSeconds(5);
        public static readonly TimeSpan DEFAULT_RETRY_INTERVAL = TimeSpan.FromMinutes(1);
        public static readonly TimeSpan DEFAULT_REPEAT_INTERVAL = TimeSpan.FromSeconds(2);

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
            this.interval = interval ?? DEFAULT_INTERVAL;
            this.initialInterval = initialInterval ?? DEFAULT_INITIAL_INTERVAL;
            this.retryInterval = retryInterval ?? DEFAULT_RETRY_INTERVAL;
            this.repeatInterval = repeatInterval ?? DEFAULT_REPEAT_INTERVAL;
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void Start()
        {
            lock (sync)
            {
                OnStarting(new TimerEventArgs());

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

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void Stop()
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

                OnStopped(new TimerEventArgs());
            }
        }

        /// <summary>
        /// Invoked when the internal timer elapses.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void timer_Elapsed(object sender, ElapsedEventArgs args)
        {
            lock (sync)
            {
                // by default do not do fast repeat
                repeat = false;
                retry = false;

                try
                {
                    Trace.TraceInformation("{0}: OnTimer (entered)", GetType().FullName);
                    OnElapsed(new TimerElapsedEventArgs(cts.Token));
                    Trace.TraceInformation("{0}: OnTimer (exit)", GetType().FullName);
                }
                catch (OperationCanceledException)
                {
                    // ignore
                }
                catch (Exception e)
                {
                    OnException(new TimerExceptionEventArgs(e));
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
        /// Invoked when the timer is starting.
        /// </summary>
        /// <param name="args"></param>
        protected void OnStarting(TimerEventArgs args)
        {
            Starting?.Invoke(this, args);
        }

        /// <summary>
        /// Raised when the timer is starting.
        /// </summary>
        public event TimerEventHandler Starting;

        /// <summary>
        /// Invoked when the timer elapses.
        /// </summary>
        /// <param name="args"></param>
        protected void OnElapsed(TimerElapsedEventArgs args)
        {
            Elapsed?.Invoke(this, args);
        }

        /// <summary>
        /// Raised when the timer has elapsed.
        /// </summary>
        public event TimerElapsedEventHandler Elapsed;

        /// <summary>
        /// Invoked when the timer is stopped.
        /// </summary>
        /// <param name="args"></param>
        protected void OnStopped(TimerEventArgs args)
        {
            Contract.Requires<ArgumentNullException>(args != null);

            Stopped?.Invoke(this, args);
        }

        /// <summary>
        /// Raised when the timer is stopped.
        /// </summary>
        public event TimerEventHandler Stopped;

        /// <summary>
        /// Invoked when an <see cref="Exception"/> is thrown by the timer.
        /// </summary>
        /// <param name="args"></param>
        protected void OnException(TimerExceptionEventArgs args)
        {
            Contract.Requires<ArgumentNullException>(args != null);

            Exception?.Invoke(this, args);
        }

        /// <summary>
        /// Raised when an <see cref="Exception"/> is thrown by the timer.
        /// </summary>
        public event TimerExceptionEventHandler Exception;

        /// <summary>
        /// Invoke from with the timer method to cause the timer to repeat on the repeat interval.
        /// </summary>
        public void Repeat()
        {
            repeat = true;
        }

        /// <summary>
        /// Invoke from with the timer method to cause the timer to repeat on the retry interval.
        /// </summary>
        public void Retry()
        {
            retry = true;
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
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

                disposed = true;
            }
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes the instance.
        /// </summary>
        ~Timer()
        {
            Dispose(false);
        }

    }

}
