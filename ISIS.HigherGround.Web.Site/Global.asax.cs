using System.Web;
using Cogito.Application;
using Cogito.Composition;
using Cogito.Web;
using Cogito.Web.Mvc;

namespace ISIS.HigherGround.Web.Site
{

    public class Global : HttpApplication
    {

        public static readonly ICompositionContext CompositionContext = new ApplicationCompositionContext();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Global()
            : base()
        {
            // configure MVC with container
            this.WithComposition(CompositionContext);
            this.WithMvcComposition(CompositionContext);
        }

        public void Application_Start()
        {
            CompositionContext.GetExportedValue<IApplicationLifecycleManager>()
                .Start();
        }

    }

}