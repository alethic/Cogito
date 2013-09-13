using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Web;
using System.Web.Http;

using Cogito.Application;
using Cogito.Composition;
using Cogito.Web.Http.Composition;

namespace ISIS.HigherGround.Web.Site
{

    public class Global : HttpApplication
    {

        /// <summary>
        /// Site-specific composition context.
        /// </summary>
        class CompositionContext : HttpCompositionContext
        {

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            public CompositionContext(HttpConfiguration configuration)
                : base(configuration)
            {

            }

            protected override ComposablePartCatalog CreateCatalog()
            {
                return new AggregateCatalog(new ApplicationCatalog());
            }

        }

        /// <summary>
        /// Gets a reference to the composition context, or creates it.
        /// </summary>
        /// <returns></returns>
        public static ICompositionContext GetCompositionContext()
        {
            return GlobalConfiguration.Configuration
                .RequireComposition<CompositionContext>(
                    _ => new CompositionContext(_));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Global()
            : base()
        {

        }

        public void Application_Start()
        {
            GetCompositionContext()
                .GetExportedValue<IApplicationLifecycleManager>()
                .Start();
        }

    }

}