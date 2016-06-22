using System;
using System.Activities;
using System.Activities.Expressions;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Activities.Tests
{

    /// <summary>
    /// Just ensures that various generic method resolutions function.
    /// </summary>
    [TestClass]
    public class InvokeResolveTests
    {

        [TestMethod]
        public void Test_resolve_async_func_activity()
        {
            var i = Expressions.Invoke(() => Task.FromResult(true));
            Assert.IsTrue(i is AsyncFuncActivity<bool>);
        }

        [TestMethod]
        public void Test_resolve_async_func_activity_with_arg1()
        {
            var i = Expressions.Invoke(j => Task.FromResult(true), new Literal<int>());
            Assert.IsTrue(i is AsyncFuncActivity<int, bool>);
        }

        [TestMethod]
        public void Test_resolve_async_func_activity_with_delegate_arg1()
        {
            var i = Expressions.Invoke(j => Task.FromResult(true), new DelegateInArgument<int>());
            Assert.IsTrue(i is AsyncFuncActivity<int, bool>);
        }

        [TestMethod]
        public void Test_resolve_async_action_activity()
        {
            var i = Expressions.Invoke(() => Task.Run(() => { }));
            Assert.IsTrue(i is AsyncActionActivity);
        }

        [TestMethod]
        public void Test_resolve_async_action_activity_with_arg1()
        {
            var i = Expressions.Invoke(j => Task.Run(() => { }), new Literal<int>());
            Assert.IsTrue(i is AsyncActionActivity<int>);
        }

        [TestMethod]
        public void Test_resolve_async_action_activity_with_delegate_arg1()
        {
            var i = Expressions.Invoke(j => Task.Run(() => { }), new DelegateInArgument<int>());
            Assert.IsTrue(i is AsyncActionActivity<int>);
        }

    }

}
