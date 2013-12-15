using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Reflection.Context;

namespace Cogito.Composition.Reflection
{

    /// <summary>
    /// Provides <see cref="PartCreationPolicyAttribute"/> based on <see cref="InheritedPartCreationPolicyAttribute"/>s.
    /// </summary>
    public class InheritedPartCreationPolicyReflectionContext :
        CustomReflectionContext
    {

        readonly ConcurrentDictionary<Type, IEnumerable<object>> metadata =
            new ConcurrentDictionary<Type, IEnumerable<object>>();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public InheritedPartCreationPolicyReflectionContext()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        public InheritedPartCreationPolicyReflectionContext(ReflectionContext source)
            : base(source)
        {

        }

        /// <summary>
        /// Provides a list of custom attributes for the specified member.
        /// </summary>
        /// <param name="member"></param>
        /// <param name="declaredAttributes"></param>
        /// <returns></returns>
        protected override IEnumerable<object> GetCustomAttributes(MemberInfo member, IEnumerable<object> declaredAttributes)
        {
            var attrs = base.GetCustomAttributes(member, declaredAttributes);
            var name = member.Name;
            // types handled
            var type = member as Type;
            if (type != null)
                attrs = attrs.Concat(metadata.GetOrAdd(type, _ => GetAttributes(_).ToList()));

            return attrs;
        }

        /// <summary>
        /// Returns additional <see cref="PartCreationPolicyAttribute"/>s for the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<object> GetAttributes(Type type)
        {
            var name = type.Name;

            // obtain all boundary attributes and generate part metadata
            return type.UnderlyingSystemType
                .GetCustomAttributes<InheritedPartCreationPolicyAttribute>(true)
                .Select(i => new PartCreationPolicyAttribute(i.CreationPolicy));
        }

    }

}
