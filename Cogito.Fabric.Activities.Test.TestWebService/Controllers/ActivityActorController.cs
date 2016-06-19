using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

using Cogito.Fabric.Activities.Test.TestActor.Interfaces;

using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

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
            var a = ActorProxy.Create<ITest>(new ActorId(Guid.NewGuid()));
            return Content(HttpStatusCode.OK, a.GetActorId());
        }

        [Route("test/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> Test(Guid id)
        {
            var a = ActorProxy.Create<ITest>(new ActorId(id));
            return Content(HttpStatusCode.OK, a.GetActorId());
        }

        [Route("test2")]
        [HttpGet]
        public async Task<IHttpActionResult> Test2()
        {
            var a = ActorProxy.Create<ITest2>(new ActorId(Guid.NewGuid()));
            await a.Run();
            return Content(HttpStatusCode.OK, a.GetActorId());
        }

        [Route("test2/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> Test2(Guid id, [FromUri] int? number = null)
        {
            var a = ActorProxy.Create<ITest2>(new ActorId(id));
            if (number != null)
                await a.SetNumber((int)number);
            else
                await a.GetNumber();
            return Content(HttpStatusCode.OK, a.GetActorId());
        }

    }

}
