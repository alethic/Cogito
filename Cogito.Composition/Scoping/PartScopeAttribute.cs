using System;
using System.Diagnostics.Contracts;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Marks a part as requiring a container supporting the specified scope.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class PartScopeAttribute : 
        Attribute
    {

        readonly Type scopeType;
        readonly Visibility visibility;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="scopeType"></param>
        /// <param name="boundary"></param>
        public PartScopeAttribute(Type scopeType, Visibility boundary)
        {
            Contract.Requires<ArgumentException>(scopeType == null || typeof(IScope).IsAssignableFrom(scopeType));

            this.scopeType = scopeType;
            this.visibility = boundary;
        }

        /// <summary>
        /// Initializes a new instnace.
        /// </summary>
        /// <param name="scopeType"></param>
        public PartScopeAttribute(Type scopeType)
            : this(scopeType, Visibility.Inherit)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="visibility"></param>
        public PartScopeAttribute(Visibility visibility)
            : this(null, visibility)
        {

        }

        /// <summary>
        /// Part must be instanted within scope that is assigned this boundary type.
        /// </summary>
        public Type ScopeType
        {
            get { return scopeType; }
        }

        /// <summary>
        /// Gets the visibility of the part.
        /// </summary>
        public Visibility Visibility
        {
            get { return visibility; }
        }

    }

}
