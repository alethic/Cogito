using System.Fabric;
using System.Threading.Tasks;

using Microsoft.Owin;

namespace Cogito.Fabric.Test.Web.Service
{

    internal sealed class OwinStatefulService :
        Http.OwinStatefulService
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        public OwinStatefulService(StatefulServiceContext context)
            : base(context, "OwinStatefulService")
        {

        }

        protected override Task RunRequest(IOwinContext context)
        {
            return base.RunRequest(context);
        }

    }

}
