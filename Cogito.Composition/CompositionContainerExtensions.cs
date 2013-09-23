using System;
using System.Diagnostics.Contracts;
using Cogito.Composition.Hosting;
using Cogito.Composition.Internal;

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
        /// Returns a <see cref="ICompositionContext"/> implementation for the given MEF <see cref="CompositionContainer"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static ICompositionContext AsContext(this mef.CompositionContainer self)
        {
            return self as ICompositionContext ?? new CompositionContextShim(self);
        }

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
