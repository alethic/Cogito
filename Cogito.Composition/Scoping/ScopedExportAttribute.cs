using System;
using System.Diagnostics.Contracts;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Marks a part as requiring a container supporting the specified scope.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class ScopedExportAttribute :
        System.ComponentModel.Composition.ExportAttribute
    {

        readonly Type scopeType;
        readonly Visibility visibility;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="contractName"></param>
        /// <param name="contractType"></param>
        /// <param name="scopeType"></param>
        /// <param name="boundary"></param>
        public ScopedExportAttribute(string contractName, Type contractType, Type scopeType, Visibility boundary)
            : base(contractName, contractType)
        {
            Contract.Requires<ArgumentException>(contractName != null || contractType != null);
            Contract.Requires<ArgumentNullException>(scopeType != null);
            Contract.Requires<ArgumentException>(typeof(IScope).IsAssignableFrom(scopeType));

            this.scopeType = scopeType;
            this.visibility = boundary;
        }

        /// <summary>
        /// Initializes a new instnace.
        /// </summary>
        /// <param name="contractType"></param>
        public ScopedExportAttribute(Type contractType, Type scopeType, Visibility visibility)
            : this(null, contractType, scopeType, visibility)
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            Contract.Requires<ArgumentNullException>(scopeType != null);
        }

        /// <summary>
        /// Initializes a new instnace.
        /// </summary>
        /// <param name="scopeType"></param>
        public ScopedExportAttribute(Type contractType, Type scopeType)
            : this(contractType, scopeType, Visibility.Inherit)
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
            Contract.Requires<ArgumentNullException>(scopeType != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="visibility"></param>
        public ScopedExportAttribute(Type contractType, Visibility visibility)
            : this(contractType, typeof(IRootScope), visibility)
        {
            Contract.Requires<ArgumentNullException>(contractType != null);
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
