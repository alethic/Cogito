using System;
using System.Diagnostics.Contracts;
using Cogito.Composition;
using Cogito.Composition.Hosting;
using Cogito.Composition.Web;
using Cogito.Nancy.Responses;

using Nancy;
using Nancy.Bootstrapper;

using mef = System.ComponentModel.Composition.Hosting;

namespace Cogito.Nancy
{

    /// <summary>
    /// Base <see cref="NancyBootstrapper/> implementation which configures a composition container.
    /// </summary>
    public class NancyBootstrapper :
        NancyBootstrapper<mef.CompositionContainer>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NancyBootstrapper()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NancyBootstrapper(mef.CompositionContainer parent)
            : base(parent)
        {
            Contract.Requires<ArgumentNullException>(parent != null);
        }

    }

    /// <summary>
    /// Base <see cref="NancyBootstrapper/> implementation which configures a composition container.
    /// </summary>
    public class NancyBootstrapper<TContainer> :
        global::Nancy.Bootstrappers.Mef.NancyBootstrapper<TContainer>
        where TContainer : mef.CompositionContainer
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NancyBootstrapper()
            : base(true)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NancyBootstrapper(TContainer parent)
            : base(parent)
        {
            Contract.Requires<ArgumentNullException>(parent != null);
        }

        protected override void RequestStartup(
            mef.CompositionContainer container,
            IPipelines pipelines,
            NancyContext context)
        {
            // capture exceptions and wrap with ErrorResponse
            pipelines.OnError.AddItemToEndOfPipeline((c, e) => ErrorResponse.FromException(e));

            base.RequestStartup(container, pipelines, context);
        }

        protected override TContainer CreateDefaultContainer()
        {
            return (TContainer)ContainerManager.GetDefaultContainer();
        }

        protected override mef.CompositionContainer CreateRequestContainer()
        {
            return ApplicationContainer
                .AsContext()
                .GetOrBeginScope<IWebRequestScope>()
                .AsContainer();
        }

    }

}
