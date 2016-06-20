using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.ServiceFabric.Activities.Test.TestActor.Interfaces
{

    public interface ITest2 : 
        IActor
    {

        Task Run();

        Task<int> GetNumber();

        Task SetNumber(int value);

    }

}
