﻿using System.ComponentModel.Composition.Hosting;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// <see cref="CompositionContainer"/> implementation which imports all assemblies available to the application by
    /// default. Serves as a suitable base container for most implementations.
    /// </summary>
    public class DefaultCompositionContainer : CompositionContainer
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public DefaultCompositionContainer()
            : base(
                catalog: new ApplicationCatalog())
        {

        }

    }

}
