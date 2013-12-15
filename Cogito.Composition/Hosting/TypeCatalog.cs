using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
            Contract.Requires<ArgumentNullException>(types != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reflectionContext"></param>
        public TypeCatalog(IEnumerable<Type> types, ReflectionContext reflectionContext)
            : base(types, new DefaultReflectionContext(reflectionContext))
        {
            Contract.Requires<ArgumentNullException>(types != null);
            Contract.Requires<ArgumentNullException>(reflectionContext != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public TypeCatalog(params Type[] types)
            : this(types.AsEnumerable())
        {
            Contract.Requires<ArgumentNullException>(types != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reflectionContext"></param>
        public TypeCatalog(ReflectionContext reflectionContext, params Type[] types)
            : this(types.AsEnumerable(), reflectionContext)
        {
            Contract.Requires<ArgumentNullException>(reflectionContext != null);
            Contract.Requires<ArgumentNullException>(types != null);
        }

    }

}
