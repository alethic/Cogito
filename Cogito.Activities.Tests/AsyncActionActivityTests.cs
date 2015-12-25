using System;
using System.Activities;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Activities.Tests
{

    [TestClass]
    public class AsyncActionActivityTests
    {

        [TestMethod]
        public void TestAsyncActionActivity()
        {
            var c = false;
            var a = new AsyncActionActivity(ctx => Task.Run(() => c = true));
            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(true, c);
        }

    }

}
