using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
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
        readonly DirectoryInfo basePath;
        readonly DirectoryInfo tempPath;
        AppDomain domain;
        AppDomainLoaderPeer peer;
        FileSystemWatcher watcher;
        IDisposable watcherRx;
        volatile Timer timer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="tempPath"></param>
        public AppDomainLoader(string basePath = null, string tempPath = null)
        {
            this.basePath = new DirectoryInfo(basePath ?? AppDomain.CurrentDomain.BaseDirectory);
            this.tempPath = new DirectoryInfo(tempPath ?? Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N")));

            // directory must exist
            if (!this.basePath.Exists)
                throw new DirectoryNotFoundException(basePath);

            // create temp path
            if (!this.tempPath.Exists)
                this.tempPath.Create();
        }

        /// <summary>
        /// Yields the possible configuration file paths.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetConfigurationFiles()
        {
            yield return Path.Combine(basePath.FullName, "Components.config");
            yield return Path.Combine(basePath.FullName, "Service.config");
            yield return AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
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
            timer = new Timer();
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
            Debug.WriteLine("{0}: OnLoad", new[] { typeof(AppDomainLoader).Name });

            lock (sync)
            {
                // configure new AppDomain
                var cfg = new AppDomainSetup();
                cfg.ApplicationBase = basePath.FullName;
                cfg.ShadowCopyFiles = "true";
                cfg.ConfigurationFile = GetConfigurationFiles().Where(i => File.Exists(i)).FirstOrDefault();

                // create new AppDomain
                domain = AppDomain.CreateDomain("Cogito.Components.Server", new Evidence(AppDomain.CurrentDomain.Evidence), cfg);
                Trace.TraceInformation("ApplicationBase: {0}", domain.SetupInformation.ApplicationBase);
                Trace.TraceInformation("ConfigurationFile: {0}", domain.SetupInformation.ConfigurationFile);

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
                    // cancel existing timer
                    if (timer != null)
                    {
                        timer.Stop();
                        timer.Dispose();
                        timer = null;
                    }

                    // schedule next attempt
                    timer = new Timer();
                    timer.AutoReset = false;
                    timer.Interval = TimeSpan.FromSeconds(rnd.Next(30, 60)).TotalMilliseconds;
                    timer.Elapsed += timer_Elapsed;
                    timer.Start();
                }

                // configure FileSystemWatcher if it does not exist
                if (watcher == null)
                {
                    // generate new watcher (w is local to prevent closures from grabbing new instance)
                    var w = watcher = new FileSystemWatcher(basePath.FullName);
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
                timer = new Timer();
                timer.AutoReset = false;
                timer.Interval = TimeSpan.FromSeconds(rnd.Next(30, 60)).TotalMilliseconds;
                timer.Elapsed += timer_Elapsed;
                timer.Start();

                Trace.TraceInformation("{0}: reload in {1}...", typeof(AppDomainLoader).Name, TimeSpan.FromMilliseconds(timer.Interval));
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
                    timer = new Timer();
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
            Debug.WriteLine("{0}: Unload", new[] { typeof(AppDomainLoader).Name });

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
                        Trace.TraceInformation("{0}: Unload attempt #{1}", typeof(AppDomainLoader).Name, i + 1);

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

                    Trace.TraceInformation("{0}: Unload successful", typeof(AppDomainLoader).Name);

                    // clear domain variable
                    domain = null;
                }
            }

            return true;
        }

    }

}
