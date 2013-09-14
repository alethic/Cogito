using System;
using System.Diagnostics.Contracts;
using Cogito.Composition.Hosting;

using mef = System.ComponentModel.Composition.Hosting;

namespace Cogito.Composition
{

    /// <summary>
    /// Various extension methods avaible for use against the Cogito specific <see cref="CompositionContainer"/>
    /// implementation.
    /// </summary>
    public static class CompositionContainerExtensions
    {

        /// <summary>
        /// Initializes the <see cref="ContainerInitInvoker"/> to invoke initialization handlers.
        /// </summary>
        /// <param name="self"></param>
        public static void BeginInit(this mef.CompositionContainer self)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            self.GetExportedValue<ContainerInitInvoker>();
        }

    }

}
