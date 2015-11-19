using System;

namespace Cogito.Negotiation
{

    public abstract class TypeContract
    {

        readonly Type type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="type"></param>
        protected TypeContract(Type type)
        {
            this.type = type;
        }

        /// <summary>
        /// Gets the required <see cref="Type"/>.
        /// </summary>
        public Type Type
        {
            get { return type; }
        }

    }

}
