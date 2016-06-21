using System;
using System.Activities;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Activities.Tests
{

    [TestClass]
    public class InvokeResolveTests
    {

        [TestMethod]
        public void Test_resolve_func_activity()
        {
            var i = Activities.Invoke(() => true);
            Assert.IsTrue(i is FuncActivity<bool>);
        }

        [TestMethod]
        public void Test_resolve_func_activity_with_arg1()
        {
            var i = Activities.Invoke(j => true, new InArgument<int>());
            Assert.IsTrue(i is FuncActivity<int, bool>);
        }

        [TestMethod]
        public void Test_resolve_action_activity()
        {
            var i = Activities.Invoke(() => Console.WriteLine());
            Assert.IsTrue(i is ActionActivity);
        }

        [TestMethod]
        public void Test_resolve_action_activity_with_arg1()
        {
            var i = Activities.Invoke(j => Console.WriteLine(), new InArgument<int>());
            Assert.IsTrue(i is ActionActivity<int>);
        }

        [TestMethod]
        public void Test_resolve_async_func_activity()
        {
            var i = Activities.Invoke(() => Task.FromResult(true));
            Assert.IsTrue(i is AsyncFuncActivity<bool>);
        }

        [TestMethod]
        public void Test_resolve_async_func_activity_with_arg1()
        {
            var i = Activities.Invoke(j => Task.FromResult(true), new InArgument<int>());
            Assert.IsTrue(i is AsyncFuncActivity<int, bool>);
        }

        [TestMethod]
        public void Test_resolve_async_action_activity()
        {
            var i = Activities.Invoke(() => Task.Run(() => { }));
            Assert.IsTrue(i is AsyncActionActivity);
        }

        [TestMethod]
        public void Test_resolve_async_action_activity_with_arg1()
        {
            var i = Activities.Invoke(j => Task.Run(() => { }), new InArgument<int>());
            Assert.IsTrue(i is AsyncActionActivity<int>);
        }

    }

}
