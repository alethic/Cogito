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
        public OwinStatelessService()
            : base("OwinStatelessService")
        {

        }

        protected override Task RunRequest(IOwinContext context)
        {
            return base.RunRequest(context);
        }

    }

}
