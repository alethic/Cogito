using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

using Cogito.Linq;

namespace Cogito.Reflection
{

    public static class TypeExtensions
    {

        /// <summary>
        /// Returns an enumeration of all <see cref="Type"/>s which the specified type can be assigned.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetAssignableTypes(this Type self)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            // chain of base types and all implemented interfaces
            return self
                .Recurse(i => i.BaseType)
                .SelectMany(i => i.GetInterfaces().Prepend(i));
        }

        /// <summary>
        /// Returns an enumeration of the specified <see cref="Type"/> and all base <see cref="Type"/>s.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypeAndBaseTypes(this Type self)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            return self.Recurse(i => i.BaseType);
        }

        /// <summary>
        /// Gets the property of field of <paramref name="self"/> named <paramref name="name"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MemberInfo GetPropertyOrField(this Type self, string name)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(name));

            return GetPropertyOrField(self, name, StringComparison.Ordinal);
        }

        /// <summary>
        /// Gets the property of field of <paramref name="self"/> named <paramref name="name"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        /// <param name="comparisontype"></param>
        /// <returns></returns>
        public static MemberInfo GetPropertyOrField(this Type self, string name, StringComparison comparisontype)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(name));

            return self
                .GetMembers(BindingFlags.Public | BindingFlags.Instance)
                .Where(i => i.MemberType == MemberTypes.Property || i.MemberType == MemberTypes.Field)
                .FirstOrDefault(i => i.Name.Equals(name, comparisontype));
        }

        /// <summary>
        /// Returns the <see cref="Type"/> of the elements in a given sequence type.
        /// </summary>
        /// <param name="seqType"></param>
        /// <returns></returns>
        public static Type GetElementType(this Type seqType)
        {
            var ienum = FindIEnumerable(seqType);
            if (ienum == null)
                return seqType;

            return ienum.GetGenericArguments()[0];
        }

        static Type FindIEnumerable(Type sequenceType)
        {
            if (sequenceType == null || sequenceType == typeof(string))
                return null;

            if (sequenceType.IsArray)
                return typeof(IEnumerable<>).MakeGenericType(sequenceType.GetElementType());

            if (sequenceType.IsGenericType)
            {
                foreach (Type arg in sequenceType.GetGenericArguments())
                {
                    var ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if (ienum.IsAssignableFrom(sequenceType))
                        return ienum;
                }
            }

            var ifaces = sequenceType.GetInterfaces();
            if (ifaces != null && ifaces.Length > 0)
            {
                foreach (Type iface in ifaces)
                {
                    var ienum = FindIEnumerable(iface);
                    if (ienum != null) 
                        return ienum;
                }
            }

            if (sequenceType.BaseType != null && sequenceType.BaseType != typeof(object))
                return FindIEnumerable(sequenceType.BaseType);

            return null;
        }

    }

}
