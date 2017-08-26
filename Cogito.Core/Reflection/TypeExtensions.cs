using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Cogito.Linq;

namespace Cogito.Reflection
{

    /// <summary>
    /// Various extension methods for working with <see cref="Type"/> instances.
    /// </summary>
    public static class TypeExtensions
    {

        /// <summary>
        /// Returns an enumeration of all <see cref="Type"/>s which the specified type can be assigned.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetAssignableTypes(this Type self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

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
            if (self == null)
                throw new ArgumentNullException(nameof(self));

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
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

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
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

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

        /// <summary>
        /// Returns the <see cref="Type"/> which implements <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="sequenceType"></param>
        /// <returns></returns>
        static Type FindIEnumerable(Type sequenceType)
        {
            if (sequenceType == null || sequenceType == typeof(string))
                return null;

            // type if an array direcetly
            if (sequenceType.IsArray)
                return typeof(IEnumerable<>).MakeGenericType(sequenceType.GetElementType());

            // type is generic
            if (sequenceType.IsGenericType)
            {
                // check whether IEnumerable{T} for one of the generic arguments is supported, such as List{T} supporting IEnumerable{T}
                foreach (var arg in sequenceType.GetGenericArguments())
                {
                    var ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if (ienum.IsAssignableFrom(sequenceType))
                        return ienum;
                }
            }

            // run through each interface and see if we can find it there
            var ifaces = sequenceType.GetInterfaces();
            if (ifaces != null && ifaces.Length > 0)
            {
                foreach (var iface in ifaces)
                {
                    var ienum = FindIEnumerable(iface);
                    if (ienum != null)
                        return ienum;
                }
            }

            // repeat for the base type
            if (sequenceType.BaseType != null &&
                sequenceType.BaseType != typeof(object))
                return FindIEnumerable(sequenceType.BaseType);

            return null;
        }

    }

}
