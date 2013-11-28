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

        protected override void RequestStartup(System.ComponentModel.Composition.Hosting.CompositionContainer container, IPipelines pipelines, NancyContext context)
        {
            // capture exceptions and wrap with ErrorResponse
            pipelines.OnError.AddItemToEndOfPipeline((c, e) => ErrorResponse.FromException(e));

            base.RequestStartup(container, pipelines, context);
        }

        protected override System.ComponentModel.Composition.Hosting.CompositionContainer CreateRequestContainer()
        {
            return ApplicationContainer
                .AsContext()
                .GetOrBeginScope<IWebRequestScope>()
                .AsContainer();
        }

    }

}
