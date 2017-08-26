using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cogito.Reflection
{

    /// <summary>
    /// Various extension methods for <see cref="MethodInfo"/> instances.
    /// </summary>
    public static class MethodInfoExtensions
    {

        /// <summary>
        /// Invokes the <see cref="MethodInfo"/> with the specified named parameters.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="obj"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object InvokeWithNamedParameters(this MethodBase self, object obj, IDictionary<string, object> parameters)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            return self.Invoke(obj, MapParameters(self, parameters));
        }

        /// <summary>
        /// Maps the named parameters to a proper invocation array.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        static object[] MapParameters(MethodBase method, IDictionary<string, object> parameters)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            var argp = method.GetParameters();
            var argn = argp.Select(i => i.Name).ToArray();
            var argv = new object[argp.Length];

            // set all parameters to default
            for (int i = 0; i < argv.Length; ++i)
                argv[i] = argp[i].ParameterType.IsValueType ? Activator.CreateInstance(argp[i].ParameterType) : null;

            // update parameters from dictionary
            foreach (var item in parameters)
            {
                var name = item.Key;
                var indx = Array.IndexOf(argn, name);
                if (indx > -1)
                    argv[indx] = item.Value;
            }

            return argv;
        }

    }

}
