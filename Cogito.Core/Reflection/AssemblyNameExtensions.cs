using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Cogito.Reflection
{

    public static class AssemblyNameExtensions
    {

        /// <summary>
        /// Loads an <see cref="Assembly"/> into the reflection-only context, given it's display name.
        /// </summary>
        /// <param name="assemblyString"></param>
        /// <param name="throwOnFileNotFound"></param>
        /// <returns></returns>
        public static Assembly ReflectionOnlyLoad(string assemblyString, bool throwOnFileNotFound = true)
        {
            if (throwOnFileNotFound)
                return Assembly.ReflectionOnlyLoad(assemblyString);

            try
            {
                return Assembly.ReflectionOnlyLoad(assemblyString);
            }
            catch (FileNotFoundException)
            {
                // ignore
            }
            catch (FileLoadException)
            {
                // ignore
            }

            return null;
        }

        /// <summary>
        /// Attempts to load the assembly of the specified name. If the assembly exists in the current <see
        /// cref="AppDomain"/>, that is returned instead.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Assembly ReflectionOnlyLoad(this AssemblyName name)
        {
            Contract.Requires<ArgumentNullException>(name != null);

            var assembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(i => i.GetName() == name);
            if (assembly != null)
                return assembly;

            assembly = ReflectionOnlyLoad(name.FullName, throwOnFileNotFound: false);
            if (assembly != null)
                return assembly;

            return null;
        }

    }

}
