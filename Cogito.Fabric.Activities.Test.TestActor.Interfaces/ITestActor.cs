using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities.Test.TestActor.Interfaces
{

    public interface ITestActor : 
        IActor
    {

        Task Run();

    }

}
