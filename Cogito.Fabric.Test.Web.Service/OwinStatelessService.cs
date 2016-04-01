using System.Fabric;
using System.Threading.Tasks;

using Microsoft.Owin;

namespace Cogito.Fabric.Test.Web.Service
{

    internal sealed class OwinStatelessService :
        Http.OwinStatelessService
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        public OwinStatelessService(StatelessServiceContext context)
            : base(context, "OwinStatelessService")
        {

        }

        protected override Task RunRequest(IOwinContext context)
        {
            return base.RunRequest(context);
        }

    }

}
