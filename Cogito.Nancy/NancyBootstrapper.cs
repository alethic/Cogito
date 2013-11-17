using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

using Cogito.Composition;
using Cogito.Composition.Hosting;
using Cogito.Composition.Web;
using Cogito.Nancy.Responses;

using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Mef.Composition.Hosting;

namespace Cogito.Nancy
{

    /// <summary>
    /// Base <see cref="NancyBootstrapper/> implementation which configures a Cogito composition container.
    /// </summary>
    public abstract class NancyBootstrapper : 
        global::Nancy.Bootstrappers.Mef.NancyBootstrapper<Cogito.Composition.Hosting.CompositionContainerCore>
    {

        protected override void RequestStartup(CompositionContainerCore container, IPipelines pipelines, NancyContext context)
        {
            // capture exceptions and wrap with ErrorResponse
            pipelines.OnError.AddItemToEndOfPipeline((c, e) => ErrorResponse.FromException(e));

            base.RequestStartup(container, pipelines, context);
        }

        protected override Cogito.Composition.Hosting.CompositionContainerCore GetApplicationContainer()
        {
            return (Cogito.Composition.Hosting.CompositionContainerCore)ContainerManager.GetDefaultContainer();
        }

        protected override Cogito.Composition.Hosting.CompositionContainerCore CreateRequestContainer()
        {
            return (Cogito.Composition.Hosting.CompositionContainerCore)
                ApplicationContainer.AsContext().GetOrBeginScope<IWebRequestScope>().AsContainer();
        }

        protected override void AddCatalog(Cogito.Composition.Hosting.CompositionContainerCore container, ComposablePartCatalog catalog)
        {
            // find nancy export provider
            var provider = container.Providers
                .OfType<NancyExportProvider>()
                .First();

            // add new catalog
            provider.Providers.Add(new CatalogExportProvider(catalog)
            {
                SourceProvider = container,
            });
        }

    }

}
