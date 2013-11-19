using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Cogito.Composition.Reflection;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Discovers attributed parts from a collection of <see cref="Type"/>s.
    /// </summary>
    public class TypeCatalog :
        System.ComponentModel.Composition.Hosting.TypeCatalog
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public TypeCatalog(IEnumerable<Type> types)
            : base(types, new DefaultReflectionContext())
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reflectionContext"></param>
        public TypeCatalog(IEnumerable<Type> types, ReflectionContext reflectionContext)
            : base(types, new DefaultReflectionContext(reflectionContext))
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public TypeCatalog(params Type[] types)
            : this(types.AsEnumerable())
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reflectionContext"></param>
        public TypeCatalog(ReflectionContext reflectionContext, params Type[] types)
            : this(types.AsEnumerable(), reflectionContext)
        {

        }

    }

}
