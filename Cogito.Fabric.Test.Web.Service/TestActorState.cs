using System.Runtime.Serialization;

namespace Cogito.Fabric.Test.Web.Service
{

    [DataContract]
    class TestActorState
    {

        [DataMember]
        public int Thing { get; set; }

    }

}
