using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cogito.Reflection
{

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
            Contract.Requires<ArgumentNullException>(method != null);
            Contract.Requires<ArgumentNullException>(parameters != null);

            var argn = method.GetParameters().Select(p => p.Name).ToArray();
            var args = new object[argn.Length];

            // set all parameters to missing
            for (int i = 0; i < args.Length; ++i)
                args[i] = Type.Missing;

            foreach (var item in parameters)
            {
                var name = item.Key;
                var indx = Array.IndexOf(argn, name);
                if (indx > -1)
                    args[indx] = item.Value;
            }

            return args;
        }

    }

}
