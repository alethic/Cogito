using System.Activities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Activities.Tests
{

    [TestClass]
    public class ActionActivityTests
    {

        [TestMethod]
        public void TestActionActivity()
        {
            var c = false;
            var a = new ActionActivity(() => c = true);
            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(true, c);
        }

    }

}
