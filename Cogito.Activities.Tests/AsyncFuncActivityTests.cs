using System.Activities;
using System.Activities.Expressions;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Cogito.Activities.Expressions;

namespace Cogito.Activities.Tests
{

    [TestClass]
    public class AsyncFuncActivityTests
    {

        [TestMethod]
        public void Test_async_func_activity()
        {
            var a = new AsyncFuncActivity<int, int>(i => Task.FromResult(i), new Literal<int>(1));
            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(1, b);
        }

        [TestMethod]
        public void Test_async_func_activity_invoke()
        {
            var a = InvokeAsync(async i => await Task.FromResult(i), new Literal<int>(1));
            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(1, b);
        }

    }

}
