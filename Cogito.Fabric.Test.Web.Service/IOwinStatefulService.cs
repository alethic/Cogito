using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Cogito.Fabric.Test.Web.Service
{

    public interface IOwinStatefulService :
        IService
    {

        Task<int> Ping();

    }

}
