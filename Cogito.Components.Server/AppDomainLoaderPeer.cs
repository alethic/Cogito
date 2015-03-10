using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection;

namespace Cogito.Components.Server
{

    /// <summary>
    /// First class started in the <see cref="AppDomain"/>.
    /// </summary>
    public class AppDomainLoaderPeer :
        MarshalByRefObject
    {

        readonly object sync = new object();
        readonly dynamic manager;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AppDomainLoaderPeer()
        {
            manager = GetComponentManager();
        }

        /// <summary>
        /// Uses reflection to obtain an instance of the <see cref="ITypeResolver"/>. The usage of reflection and
        /// dynamic types prevents this assembly from declaring a hard binding tp the Cogito.Composition assembly.
        /// </summary>
        /// <returns></returns>
        dynamic GetComponentManager()
        {
            Contract.Ensures(Contract.Result<object>() != null);

            var assembly = TryLoadAssembly("Cogito.Composition");
            if (assembly == null)
                throw new TypeLoadException("Unable to load assembly 'Cogito.Composition'.");

            var type = assembly.GetType("Cogito.Composition.Hosting.ContainerManager");
            if (type == null)
                throw new TypeLoadException("Unable to load type 'Cogito.Composition.Hosting.ContainerManager'.");

            var method = type.GetMethod("GetDefaultTypeResolver", BindingFlags.Public | BindingFlags.Static);
            if (method == null)
                    throw new TypeLoadException("Unable to find 'GetDefaultTypeResolver' method.");

            var resolver = (dynamic)method.Invoke(null, new object[0]);
            if (resolver == null)
                throw new TypeLoadException("Unable to find default type resolver.");

            var manager = resolver.Resolve<IComponentManager>();
            if (manager == null)
                throw new NullReferenceException("Unable to resolve 'Cogito.Components.IComponentManager'.");

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
            Debug.WriteLine("{0}: Load", typeof(AppDomainLoaderPeer).Name);

            lock (sync)
            {
                try
                {
                    manager.Start();
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
            Debug.WriteLine("{0}: Unload", typeof(AppDomainLoaderPeer).Name);

            lock (sync)
            {
                try
                {
                    manager.Stop();
                }
                catch (Exception e)
                {
                    e.Trace();
                    return false;
                }

                return true;
            }
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

    }

}
