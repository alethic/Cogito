using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Cogito.Fabric.Activities.Test.TestActor.Interfaces;
using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities.Test.TestWebService.Controllers
{

    [RoutePrefix("activity-actor")]
    public class ActivityActorController :
        ApiController
    {

        [Route("test")]
        [HttpGet]
        public async Task<IHttpActionResult> Test()
        {
            var a = ActorProxy.Create<ITestActor>(new ActorId(Guid.NewGuid()));
            await a.Run();
            return Content(HttpStatusCode.OK, a.GetActorId());
        }

        [Route("test/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> Test(Guid id)
        {
            var a = ActorProxy.Create<ITestActor>(new ActorId(id));
            await a.Run();
            return Content(HttpStatusCode.OK, a.GetActorId());
        }

    }

}
