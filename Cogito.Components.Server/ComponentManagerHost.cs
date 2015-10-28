using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Cogito.Components.Server
{

    class ComponentManagerHost
    {

        readonly object sync = new object();
        readonly Lazy<dynamic> manager;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ComponentManagerHost()
        {
            this.manager = new Lazy<dynamic>(GetComponentManager);
        }

        /// <summary>
        /// Uses reflection to obtain an instance of the <see cref="ITypeResolver"/>. The usage of reflection and
        /// dynamic types prevents this assembly from declaring a hard binding tp the Cogito.Composition assembly.
        /// </summary>
        /// <returns></returns>
        dynamic GetComponentManager()
        {
            var assembly = TryLoadAssembly("Cogito.Composition");
            if (assembly == null)
            {
                Trace.TraceError("Unable to load assembly 'Cogito.Composition' from '{0}'.", AppDomain.CurrentDomain.BaseDirectory);
                return null;
            }

            var type = assembly.GetType("Cogito.Composition.Hosting.ContainerManager");
            if (type == null)
            {
                Trace.TraceError("Unable to load type 'Cogito.Composition.Hosting.ContainerManager' from '{0}'.", AppDomain.CurrentDomain.BaseDirectory);
                return null;
            }

            var method = type.GetMethod("GetDefaultTypeResolver", BindingFlags.Public | BindingFlags.Static);
            if (method == null)
            {
                Trace.TraceError("Unable to find 'GetDefaultTypeResolver' method.");
                return null;
            }

            var resolver = (dynamic)method.Invoke(null, new object[0]);
            if (resolver == null)
            {
                Trace.TraceError("Unable to find default type resolver.");
                return null;
            }

            var manager = resolver.Resolve<IComponentManager>();
            if (manager == null)
            {
                Trace.TraceError("Unable to resolve 'Cogito.Components.IComponentManager'.");
                return null;
            }

            return manager;
        }

        /// <summary>
        ///  Attempts to load the given <see cref="Assembly"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Assembly TryLoadAssembly(string name)
        {
            try
            {
                return Assembly.Load(name);
            }
            catch (FileLoadException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Loads all the loaders.
        /// </summary>
        public bool Load()
        {
            Debug.WriteLine("{0}: Load", new[] { typeof(ComponentManagerHost).Name });

            lock (sync)
            {
                try
                {
                    if (manager.Value != null)
                        manager.Value.Start();
                    else
                        return false;
                }
                catch (Exception e)
                {
                    e.Trace();
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
            Debug.WriteLine("{0}: Unload", new[] { typeof(ComponentManagerHost).Name });

            lock (sync)
            {
                try
                {
                    if (manager.Value != null)
                        manager.Value.Stop();
                    else
                        return false;
                }
                catch (Exception e)
                {
                    e.Trace();
                    return false;
                }

                return true;
            }
        }

    }

}
