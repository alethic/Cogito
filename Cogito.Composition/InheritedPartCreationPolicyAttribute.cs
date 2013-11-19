using System;
using System.ComponentModel.Composition;

namespace Cogito.Composition
{

    /// <summary>
    /// Specifies the <see cref="CreationPolicy"/> for a part.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class InheritedPartCreationPolicyAttribute :
        Attribute
    {

        readonly CreationPolicy creationPolicy;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="creationPolicy"></param>
        public InheritedPartCreationPolicyAttribute(CreationPolicy creationPolicy)
        {
            this.creationPolicy = creationPolicy;
        }

        /// <summary>
        /// Gets or sets a value that indicates the creation policy of the attributed part.
        /// </summary>
        public CreationPolicy CreationPolicy
        {
            get { return creationPolicy; }
        }

    }

}
