using System.ComponentModel.Composition;
using System.Web.Routing;

namespace Cogito.Web.Mvc
{

    [Export(typeof(IMvcConfiguration))]
    public class MvcConfiguration : IMvcConfiguration
    {

        public bool Available { get; set; }
        
        [Export]
        public RouteCollection Routes { get; set; }

    }

}
