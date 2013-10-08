using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Reactive.Linq;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Subscribes to the discovery of parts that implement <see cref="IContainerInit"/> and invokes their OnInit
    /// method.
    /// </summary>
    [Export(typeof(ContainerInitInvoker))]
    public class ContainerInitInvoker
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="initialize"></param>
        [ImportingConstructor]
        public ContainerInitInvoker(
            [ImportMany] IEnumerable<IContainerInit> initialize)
        {
            Contract.Requires<ArgumentNullException>(initialize != null);

            // invoke initialization as parts are discovered
            foreach (var i in initialize)
                i.OnInit();
        }

    }

}
