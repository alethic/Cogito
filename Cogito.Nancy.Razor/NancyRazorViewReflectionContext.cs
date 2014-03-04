using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Registration;
using System.Reflection;

using Cogito.Composition.Hosting;
using Cogito.Linq;
using Cogito.Web;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Maps types that implement INancyRazorView<> as exports.
    /// </summary>
    public class NancyRazorViewReflectionContext :
        ReflectionContext
    {

        /// <summary>
        /// Gets the implemented model type for the given concrete type. Searches for INancyRazorView<> implementations
        /// and returns the associated model type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        static Type GetModelType(Type type)
        {
            foreach (var t in type.GetInterfaces().Prepend(type))
            {
                if (t.IsGenericType &&
                    t.GetGenericTypeDefinition() == typeof(INancyRazorView<>))
                {
                    var a = t.GetGenericArguments();
                    if (a.Length == 1)
                        return a[0];
                }
            }

            return null;
        }

        readonly RegistrationBuilder registrationBuilder;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NancyRazorViewReflectionContext()
        {
            this.registrationBuilder = new RegistrationBuilder();

            // export INancyRazorView<> interfaces
            this.registrationBuilder.ForTypesMatching(i => GetModelType(i) != null)
                .AddMetadata(
                    CompositionConstants.RequiredScopeMetadataName,
                    AttributedModelServices.GetTypeIdentity(typeof(IWebRequestScope)))
                .SetCreationPolicy(CreationPolicy.NonShared)
                .ExportInterfaces(
                i =>
                    typeof(INancyRazorView).IsAssignableFrom(i),
                (t, b) =>
                    b.AsContractType(t));
        }

        public override Assembly MapAssembly(Assembly assembly)
        {
            return registrationBuilder.MapAssembly(assembly);
        }

        public override TypeInfo MapType(TypeInfo type)
        {
            return registrationBuilder.MapType(type);
        }

    }

}
