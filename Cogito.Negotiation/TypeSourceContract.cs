using System;
using System.Linq;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Requires a certain type.
    /// </summary>
    public class TypeSourceContract :
        TypeContract,
        ISourceContract
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="type"></param>
        public TypeSourceContract(Type type)
            : base(type)
        {

        }

        public NegotiationResult Negotiate(IOutputNegotiator negotiator)
        {
            return negotiator.Contracts
                .OfType<TypeOutputContract>()
                .Where(i => Type.IsAssignableFrom(i.Type))
                .Select(i => new NegotiationResult(0d))
                .FirstOrDefault();
        }

    }

}
