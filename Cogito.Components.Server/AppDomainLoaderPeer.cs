using System;
using System.Diagnostics;
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

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AppDomainLoaderPeer()
        {

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
        /// Uses reflection to obtain an instance of the <see cref="ITypeResolver"/>. The usage of reflection and
        /// dynamic types prevents this assembly from declaring a hard binding tp the Cogito.Composition assembly.
        /// </summary>
        /// <returns></returns>
        dynamic GetTypeResolver()
        {
            return Assembly.Load("Cogito.Composition")
                .GetType("Cogito.Composition.Hosting.ContainerManager")
                .GetMethod("GetDefaultTypeResolver", BindingFlags.Public | BindingFlags.Static)
                .Invoke(null, new object[0]);
        }

        /// <summary>
        /// Loads all the loaders.
        /// </summary>
        public bool Load()
        {
            Debug.WriteLine("{0}: Load", typeof(AppDomainLoaderPeer).Name);

            lock (sync)
            {
                var c = (IComponentManager)GetTypeResolver().Resolve<IComponentManager>();
                c.Start();
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
                var c = (IComponentManager)GetTypeResolver().Resolve<IComponentManager>();
                c.Stop();
                return true;
            }
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

    }

}
