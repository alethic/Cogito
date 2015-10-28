using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Timers;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Keeps an <see cref="AppDomain"/> loaded from the configured base path. Recycles the <see cref="AppDomain"/>
    /// when the base path changes.
    /// </summary>
    public class AppDomainLoader
    {

        readonly static Random rnd = new Random();

        readonly object sync = new object();
        readonly ApplicationInfo info;

        AppDomain domain;
        AppDomainLoaderPeer peer;
        volatile FileSystemWatcher watcher;
        volatile IDisposable watcherRx;
        volatile System.Timers.Timer timer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="info"></param>
        public AppDomainLoader(ApplicationInfo info)
        {
            Contract.Requires<ArgumentNullException>(info != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(info.Path));

            this.info = info;
        }

        /// <summary>
        /// Starts the <see cref="AppDomainLoader"/>.
        /// </summary>
        public bool Load()
        {
            Debug.WriteLine("{0}: Load", new[] { typeof(AppDomainLoader).Name });

            if (timer != null)
                throw new InvalidOperationException("AppDomainLoader is already started");

            // schedule reload
            timer = new System.Timers.Timer();
            timer.AutoReset = false;
            timer.Interval = TimeSpan.FromSeconds(1).TotalMilliseconds;
            timer.Elapsed += timer_Elapsed;
            timer.Start();

            return true;
        }

        /// <summary>
        /// Attempts to load the child <see cref="AppDomain"/>.
        /// </summary>
        void OnLoad()
        {
            Contract.Requires(domain == null);
            Contract.Requires(peer == null);
            Debug.WriteLine("{0}: {1}: OnLoad", info.Name, typeof(AppDomainLoader).Name);

            lock (sync)
            {
                var path = Path.GetFullPath(info.Path);
                var configPath = Path.GetFullPath(info.ConfigurationFilePath);

                // try again later if no directory
                if (!Directory.Exists(path))
                {
                    Trace.TraceError("{0}: {1}: Application directory not found: {2}", info.Name, typeof(AppDomainLoader).Name, path);
                    ScheduleTimer(TimeSpan.FromMinutes(rnd.Next(5, 10)));
                    return;
                }

                // try again later if no configuration file
                if (!File.Exists(configPath))
                {
                    Trace.TraceError("{0}: {1}: Configuration file not found: {2}", info.Name, typeof(AppDomainLoader).Name, configPath);
                    ScheduleTimer(TimeSpan.FromMinutes(rnd.Next(5, 10)));
                    return;
                }

                // configure new AppDomain
                var cfg = new AppDomainSetup();
                cfg.ApplicationBase = path;
                cfg.ConfigurationFile = configPath;
                cfg.ShadowCopyFiles = "true";

                // create new AppDomain
                domain = AppDomain.CreateDomain(info.Name, new Evidence(AppDomain.CurrentDomain.Evidence), cfg);
                Debug.WriteLine("{0}: ApplicationBase: {1}", info.Name, domain.SetupInformation.ApplicationBase);
                Debug.WriteLine("{0}: ConfigurationFile: {1}", info.Name, domain.SetupInformation.ConfigurationFile);

                // provides assistance in assembly resolution to the remote domain
                domain.CreateInstanceFromAndUnwrap(
                    Assembly.GetExecutingAssembly().Location,
                    typeof(AppDomainAssemblyResolver).FullName,
                    false,
                    BindingFlags.Default,
                    null,
                    new[] { AppDomain.CurrentDomain.BaseDirectory },
                    null,
                    null);

                // relays diagnostic messages from the remote domain
                AppDomainTraceReceiver.ListenTo(domain);

                // configure and start new AppDomainPeer
                peer = (AppDomainLoaderPeer)domain.CreateInstanceFromAndUnwrap(
                    Assembly.GetExecutingAssembly().Location,
                    typeof(AppDomainLoaderPeer).FullName,
                    false,
                    BindingFlags.Default,
                    null,
                    null,
                    null,
                    null);

                // attempt to load peer
                if (!peer.Load())
                {
                    ScheduleTimer(TimeSpan.FromSeconds(rnd.Next(30, 60)));
                    return;
                }

                // configure FileSystemWatcher if it does not exist
                if (watcher == null && info.Watch)
                {
                    // generate new watcher (w is local to prevent closures from grabbing new instance)
                    var w = watcher = new FileSystemWatcher(info.Path);
                    w.EnableRaisingEvents = true;

                    // merge event sequences and throttle output
                    watcherRx = Observable.Merge<EventPattern<FileSystemEventArgs>>(
                        Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                            h => w.Created += h,
                            h => w.Created -= h),
                        Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                            h => w.Deleted += h,
                            h => w.Deleted -= h),
                        Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                            h => w.Changed += h,
                            h => w.Changed -= h),
                        Observable.FromEventPattern<RenamedEventHandler, FileSystemEventArgs>(
                            h => w.Renamed += h,
                            h => w.Renamed -= h))
                        .Throttle(TimeSpan.FromSeconds(5))
                        .Subscribe(i => OnFileSystemChanged(w));
                }
            }
        }

        /// <summary>
        /// Reschedules the timer.
        /// </summary>
        /// <param name="time"></param>
        void ScheduleTimer(TimeSpan time)
        {
            lock (sync)
            {
                // cancel existing timer
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }

                // schedule next attempt
                timer = new System.Timers.Timer();
                timer.AutoReset = false;
                timer.Interval = time.TotalMilliseconds;
                timer.Elapsed += timer_Elapsed;
                timer.Start();
            }
        }

        /// <summary>
        /// Invoked when a change to the BinPath is made.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnFileSystemChanged(FileSystemWatcher sender)
        {
            Contract.Requires<ArgumentNullException>(sender != null);

            lock (sync)
            {
                // event for old watcher
                if (sender != watcher)
                    return;

                // cancel existing timer
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }

                // schedule reload
                timer = new System.Timers.Timer();
                timer.AutoReset = false;
                timer.Interval = TimeSpan.FromSeconds(rnd.Next(30, 60)).TotalMilliseconds;
                timer.Elapsed += timer_Elapsed;
                timer.Start();

                Trace.TraceInformation("{0}: {1}: reload in {2}...", info.Name, typeof(AppDomainLoader).Name, TimeSpan.FromMilliseconds(timer.Interval));
            }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs args)
        {
            Contract.Requires<ArgumentNullException>(args != null);

            lock (sync)
            {
                // only proceed if timer has not been altered
                if (sender != timer)
                    return;

                try
                {
                    Unload();
                    OnLoad();
                }
                catch (Exception e)
                {
                    e.Trace();

                    // cancel existing timer
                    if (timer != null)
                    {
                        timer.Stop();
                        timer.Dispose();
                        timer = null;
                    }

                    // restart timer to attempt loading again
                    timer = new System.Timers.Timer();
                    timer.AutoReset = false;
                    timer.Interval = TimeSpan.FromSeconds(rnd.Next(30, 60)).TotalMilliseconds;
                    timer.Elapsed += timer_Elapsed;
                    timer.Start();
                }
            }
        }

        /// <summary>
        /// Stops the running <see cref="AppDomain"/>.
        /// </summary>
        public bool Unload()
        {
            Debug.WriteLine("{0}: {1}: Unload", info.Name, typeof(AppDomainLoader).Name);

            lock (sync)
            {
                if (watcherRx != null)
                {
                    watcherRx.Dispose();
                    watcherRx = null;
                }

                if (watcher != null)
                {
                    watcher.Dispose();
                    watcher = null;
                }

                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }

                if (peer != null)
                {
                    peer.Unload();
                    peer = null;
                }

                if (domain != null)
                {
                    // attempt unload three more times
                    for (var i = 0; i < 3; i++)
                    {
                        Trace.TraceInformation("{0}: {1}: Unload attempt #{2}", info.Name, typeof(AppDomainLoader).Name, i + 1);

                        try
                        {
                            AppDomain.Unload(domain);
                            break;
                        }
                        catch (Exception e2)
                        {
                            e2.Trace();

                            // wait for 5 seconds before trying again
                            System.Threading.Monitor.Wait(sync, 5000);

                            continue;
                        }
                    }

                    Trace.TraceInformation("{0}: {1}: Unload successful", info.Name, typeof(AppDomainLoader).Name);

                    // clear domain variable
                    domain = null;
                }
            }

            return true;
        }

    }

}
