using System;
using System.Diagnostics.Contracts;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Marks a part as requiring a container supporting the specified scope.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class ScopeAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="scope"></param>
        public ScopeAttribute(Type scope)
        {
            Contract.Requires<ArgumentException>(typeof(IScope).IsAssignableFrom(scope));

            Scope = scope;
        }

        /// <summary>
        /// Part must be instanted within scope that is assigned this boundary type.
        /// </summary>
        public Type Scope { get; private set; }

    }

}
