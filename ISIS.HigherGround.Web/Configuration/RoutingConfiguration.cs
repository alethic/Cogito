using System.ComponentModel.Composition;
using System.Web.Mvc;

using Cogito.Application.Lifecycle;
using Cogito.Composition;

namespace Cogito.Web.Mvc.Configuration
{

    [OnStart(typeof(IMvcApplication))]
    public class RoutingConfiguration : MvcLifecycleComponent
    {

        ICompositionContext composition;
        IMvcApplication app;

        [ImportingConstructor]
        public RoutingConfiguration(
            ICompositionContext composition,
            IMvcApplication app)
            : base(app)
        {
            this.composition = composition;
            this.app = app;
        }

        public override void OnStart()
        {
            app.Routes.MapMvcAttributeRoutes();
        }

    }

}
