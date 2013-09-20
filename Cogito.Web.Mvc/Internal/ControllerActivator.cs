using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using System.Web.Routing;

using Cogito.Composition;

namespace Cogito.Web.Mvc.Internal
{

    [Export(typeof(IControllerActivator))]
    public class ControllerActivator : IControllerActivator
    {

        ICompositionContext composition;

        [ImportingConstructor]
        public ControllerActivator(
            ICompositionContext composition)
        {
            this.composition = composition;
        }

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            return composition.GetExportedValueOrDefault(controllerType) as IController;
        }

    }

}
