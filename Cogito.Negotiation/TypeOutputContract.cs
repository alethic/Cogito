using System;
using System.Linq;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Describes a type output by a component.
    /// </summary>
    public class TypeOutputContract :
        TypeContract,
        IOutputContract
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="Type"></param>
        public TypeOutputContract(Type Type)
            : base(Type)
        {

        }

        public NegotiationResult Negotiate(ISourceNegotiator negotiator)
        {
            return negotiator.Contracts
                .OfType<TypeSourceContract>()
                .Where(i => i.Type.IsAssignableFrom(Type))
                .Select(i => new NegotiationResult(0d))
                .FirstOrDefault();
        }

    }

}
