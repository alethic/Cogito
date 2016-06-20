using System.Runtime.Serialization;

namespace Cogito.ServiceFabric.Activities.Test.TestActor
{

    [DataContract]
    public class Test2State
    {

        [DataMember]
        public int Value { get; set; }

    }

}
