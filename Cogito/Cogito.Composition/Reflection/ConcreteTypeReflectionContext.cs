using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Registration;

namespace Cogito.Composition.Reflection
{

    /// <summary>
    /// Provides export attributes for concrete types.
    /// </summary>
    public class ConcreteTypeReflectionContext : RegistrationBuilder
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ConcreteTypeReflectionContext()
        {
            ForTypesMatching(i => i.IsClass && !i.IsAbstract)
                .AddMetadata("ConcreteTypeIdentity", i => AttributedModelServices.GetTypeIdentity(i))
                .Export();
        }

    }

}
