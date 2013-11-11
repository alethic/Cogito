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

    }

}
