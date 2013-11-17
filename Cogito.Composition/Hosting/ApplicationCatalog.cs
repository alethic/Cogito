using System.Reflection;

using Cogito.Composition.Reflection;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Discovers attributed parts in the dynamic link library (DLL) and EXE files in an application's directory and path.
    /// </summary>
    public class ApplicationCatalog : 
        System.ComponentModel.Composition.Hosting.ApplicationCatalog
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ApplicationCatalog()
            : base(new ScopeMetadataReflectionContext())
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reflectionContext"></param>
        public ApplicationCatalog(ReflectionContext reflectionContext)
            : base(new ScopeMetadataReflectionContext(reflectionContext))
        {

        }

    }

}
