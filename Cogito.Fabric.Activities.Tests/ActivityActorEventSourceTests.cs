using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Fabric.Activities.Tests
{

    [TestClass]
    public class ActivityActorEventSourceTests
    {

        [TestMethod]
        public void Test_ActivityActorEventSourceWithAnalyzer()
        {
            EventSourceAnalyzer.InspectAll(ActivityActorEventSource.Current);
        }

    }

}
