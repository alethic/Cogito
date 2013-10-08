﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Reflection.Context;

using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;

namespace Cogito.Composition.Reflection
{

    /// <summary>
    /// Provides part metadata based on <see cref="ScopeAttribute"/> decorations.
    /// </summary>
    public class ScopeMetadataReflectionContext : CustomReflectionContext
    {

        ConcurrentDictionary<Type, IEnumerable<object>> metadata =
            new ConcurrentDictionary<Type, IEnumerable<object>>();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ScopeMetadataReflectionContext()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        public ScopeMetadataReflectionContext(ReflectionContext source)
            : base(source)
        {

        }

        protected override IEnumerable<object> GetCustomAttributes(MemberInfo member, IEnumerable<object> declaredAttributes)
        {
            var attrs = base.GetCustomAttributes(member, declaredAttributes);

            // types handled
            var type = member as Type;
            if (type != null)
                attrs = attrs.Concat(metadata.GetOrAdd(type, _ => GetMetadataAttributes(_).ToList()));

            return attrs;
        }

        /// <summary>
        /// Returns additional <see cref="PartMetadataAttribute"/>s for the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="declaredAttributes"></param>
        /// <returns></returns>
        IEnumerable<object> GetMetadataAttributes(Type type)
        {
            var name = type.Name;

            // obtain all boundary attributes and generate part metadata
            return type.GetCustomAttributes(true)
                .OfType<ScopeAttribute>()
                .Select(i => i.Scope)
                .Select(i => new PartMetadataAttribute(CompositionConstants.RequiredScopeMetadataName, AttributedModelServices.GetTypeIdentity(i)));
        }

    }

}
