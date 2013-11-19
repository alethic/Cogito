using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Reflection.Context;

namespace Cogito.Composition.Reflection
{

    /// <summary>
    /// Provides a wrapper that includes all of the default <see cref="ReflectionContext"/> implementations.
    /// </summary>
    public class DefaultReflectionContext :
        CustomReflectionContext
    {

        /// <summary>
        /// Creates the default <see cref="ReflectionContext"/> stack.
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        static ReflectionContext Get()
        {
            return
                new ScopeMetadataReflectionContext(
                    new InheritedPartCreationPolicyReflectionContext());
        }

        /// <summary>
        /// Creates the default <see cref="ReflectionContext"/> stack.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        static ReflectionContext Get(ReflectionContext source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return
                new ScopeMetadataReflectionContext(
                    new InheritedPartCreationPolicyReflectionContext(
                        source));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public DefaultReflectionContext()
            : base(Get())
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        public DefaultReflectionContext(ReflectionContext source)
            : base(Get(source))
        {
            Contract.Requires<ArgumentNullException>(source != null);
        }

    }

}
