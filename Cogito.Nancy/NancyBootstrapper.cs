using System;
using System.Diagnostics.Contracts;
using Cogito.Composition;
using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;
using Cogito.Nancy.Responses;
using Cogito.Web;
using Nancy;
using Nancy.Bootstrapper;
using mef = System.ComponentModel.Composition.Hosting;

namespace Cogito.Nancy
{

    /// <summary>
    /// Base <see cref="NancyBootstrapper"/> implementation which configures a Cogito composition container.
    /// </summary>
    public abstract class NancyBootstrapper :
        global::Nancy.Bootstrappers.Mef.NancyBootstrapper<ITypeResolver, ITypeResolver>
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
        public NancyBootstrapper(bool createDefaultContainer = true)
            : base(true)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="typeResolver"></param>
        public NancyBootstrapper(ITypeResolver typeResolver)
            : base(typeResolver)
        {
            Contract.Requires<ArgumentNullException>(typeResolver != null);
        }

        /// <summary>
        /// Initializes the request.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="pipelines"></param>
        /// <param name="context"></param>
        protected override void RequestStartup(mef.CompositionContainer container, IPipelines pipelines, NancyContext context)
        {
            // capture exceptions and wrap with ErrorResponse
            pipelines.OnError.AddItemToEndOfPipeline((c, e) => ErrorResponse.FromException(e));

            base.RequestStartup(container, pipelines, context);
        }

        /// <summary>
        /// Creates the default container.
        /// </summary>
        /// <returns></returns>
        protected override CompositionContainer CreateDefaultContainer()
        {
            return (CompositionContainer)ContainerManager.GetDefaultContainer();
        }

        /// <summary>
        /// Creates a new request container.
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        protected override ITypeResolver CreateRequestContainer(ITypeResolver parent)
        {
            return parent.Resolve<IScopeTypeResolver>().Resolve<ITypeResolver, IWebRequestScope>();
        }

        protected override void AddCatalog(mef.CompositionContainer container, System.ComponentModel.Composition.Primitives.ComposablePartCatalog catalog)
        {
            base.AddCatalog(container, catalog);
        }

    }

}
