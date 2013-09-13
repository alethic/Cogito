using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ISIS.Web.Mvc
{

    /// <summary>
    /// 
    /// </summary>
    [Export(typeof(IControllerFactory))]
    public class ControllerFactory : DefaultControllerFactory
    {

        CompositionContainer container;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="container"></param>
        public ControllerFactory(CompositionContainer container)
        {
            this.container = container;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            throw new NotImplementedException();
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            throw new NotImplementedException();
        }

        public void ReleaseController(IController controller)
        {
            throw new NotImplementedException();
        }

    }

}
