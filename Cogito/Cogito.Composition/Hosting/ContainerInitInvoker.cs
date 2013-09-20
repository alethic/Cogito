using System;
using System.ComponentModel.Composition;
using System.Reactive.Linq;

namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Subscribes to the discovery of parts that implement <see cref="IContainerInit"/> and invokes their OnInit
    /// method.
    /// </summary>
    [Export(typeof(ContainerInitInvoker))]
    public class ContainerInitInvoker : IDisposable
    {

        IImportCollection<IContainerInit> initialize;
        IDisposable subscription;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="initialize"></param>
        [ImportingConstructor]
        public ContainerInitInvoker(
            IImportCollection<IContainerInit> initialize)
        {
            this.initialize = initialize;

            // invoke initialization as parts are discovered
            subscription = this.initialize
                .AsObservable<IContainerInit>()
                .Subscribe(i => i.OnInit());
        }
        
        public void Dispose()
        {
            subscription.Dispose();
            initialize.Dispose();
        }

    }

}
