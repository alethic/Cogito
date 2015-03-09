using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

using Cogito.Components.Server.Loading;

namespace Cogito.Components.Server
{

    /// <summary>
    /// First class started in the <see cref="AppDomain"/>.
    /// </summary>
    public class AppDomainLoaderPeer :
        MarshalByRefObject
    {

        readonly List<ILoader> loaders;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AppDomainLoaderPeer()
        {
            // discover all loaders
            loaders = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Select(i => LoadAssembly(i))
                .Where(i => i != null)
                .SelectMany(i => i.GetTypes())
                .Where(i => i.IsClass && !i.IsAbstract && i.IsPublic)
                .Where(i => typeof(ILoader).IsAssignableFrom(i))
                .Where(i => i.GetConstructor(Type.EmptyTypes) != null)
                .Select(i => (ILoader)Activator.CreateInstance(i))
                .ToList();
        }

        /// <summary>
        ///  Attempts to load the given <see cref="Assembly"/>.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Assembly LoadAssembly(string path)
        {
            try
            {
                return Assembly.LoadFrom(path);
            }
            catch (FileLoadException)
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Loads all the loaders.
        /// </summary>
        public bool Load()
        {
            Debug.WriteLine("AppDomainPeer: Load");

            lock (loaders)
            {
                var e = loaders.Select(i => TryLoad(i)).Where(i => i != null).ToArray();
                if (e.Any())
                {
                    Trace.TraceError("{0:HH:mm:ss.fff} {1}", DateTime.Now, new AggregateException(e).Flatten());
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Unloads all the loaders.
        /// </summary>
        public bool Unload()
        {
            Debug.WriteLine("AppDomainPeer: Unload");

            lock (loaders)
            {
                var e = loaders.Select(i => TryUnload(i)).Where(i => i != null).ToArray();
                if (e.Any())
                {
                    Trace.TraceError("{0:HH:mm:ss.fff} {1}", DateTime.Now, new AggregateException(e).Flatten());
                    return false;
                }

                return true;
            }
        }

        Exception TryLoad(ILoader loader)
        {
            try
            {
                loader.Load();
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        Exception TryUnload(ILoader loader)
        {
            try
            {
                loader.Unload();
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

    }

}
