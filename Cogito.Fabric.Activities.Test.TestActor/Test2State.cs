using System.Runtime.Serialization;

namespace Cogito.Fabric.Activities.Test.TestActor
{

    [DataContract]
    public class Test2State
    {

        [DataMember]
        public int Value { get; set; }

    }

}
