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

        readonly object sync = new object();
        readonly TimeSpan interval;
        System.Timers.Timer timer;
        CancellationTokenSource cts;
        bool disposed;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bus"></param>
        /// <param name="data"></param>
        public SingleNodeTimer(
            SingleNodeTimerManager<TComponent> manager,
            TimeSpan interval)
            : base(manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null);
            Contract.Requires<ArgumentOutOfRangeException>(interval.TotalMilliseconds > 0);

            this.interval = interval;
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
                timer.Interval = interval.TotalMilliseconds;
                timer.AutoReset = true;
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
                    Trace.TraceInformation("{0}: OnTimer (error)", GetType().Name, e);
                    OnException(e);
                }
            }
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
        /// <param name="e"></param>
        protected virtual void OnException(Exception e)
        {
            Contract.Requires<ArgumentNullException>(e != null);

            e.Trace();
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
