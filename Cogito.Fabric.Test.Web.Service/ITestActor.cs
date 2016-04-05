using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Test.Web.Service
{

    public interface ITestActor :
        IActor
    {

        Task IncrementThing();

    }

}
