using System.Activities;
using System.Activities.Expressions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Cogito.Activities.Expressions;

namespace Cogito.Activities.Tests
{

    [TestClass]
    public class ActionActivityTests
    {

        [TestMethod]
        public void Test_action_activity()
        {
            var c = false;
            var b = WorkflowInvoker.Invoke(new ActionActivity(() => c = true));
            Assert.AreEqual(true, c);
        }

        [TestMethod]
        public void Test_action_activity_invoke()
        {
            var c = false;
            var b = WorkflowInvoker.Invoke(Invoke(() => c = true));
            Assert.AreEqual(true, c);
        }

        [TestMethod]
        public void Test_action_activity_arg()
        {
            var a = new Literal<bool>(true);
            var c = false;
            var b = WorkflowInvoker.Invoke(new ActionActivity<bool>(i => c = i, a));
            Assert.AreEqual(true, c);
        }

        [TestMethod]
        public void Test_action_activity_arg_invoke()
        {
            var a = new Literal<bool>(true);
            var c = false;
            var b = WorkflowInvoker.Invoke(Invoke(i => c = i, a));
            Assert.AreEqual(true, c);
        }

    }

}
