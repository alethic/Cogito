using System;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Cogito.Serialization
{

    public static class SerializationInfoExtensions
    {

        public static T GetValue<T>(this SerializationInfo info, string name)
        {
            Contract.Requires<ArgumentNullException>(info != null);
            Contract.Requires<ArgumentNullException>(name != null);

            return (T)info.GetValue(name, typeof(T));
        }

    }

}
