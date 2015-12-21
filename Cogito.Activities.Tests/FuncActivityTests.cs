using System.Activities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Activities.Tests
{

    [TestClass]
    public class FuncActivityTests
    {

        [TestMethod]
        public void TestFuncActivity()
        {
            var a = new FuncActivity<bool>(ctx => true);
            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(true, b);
        }

    }

}
