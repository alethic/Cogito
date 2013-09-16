using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cogito.Web.Mvc.Internal
{

    [Export(typeof(IControllerFactory))]
    public class ControllerFactory : DefaultControllerFactory
    {

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            return base.GetControllerType(requestContext, controllerName);
        }

    }

}
