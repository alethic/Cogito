using System;
using System.Activities;
using System.Activities.Statements;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Activities.Tests
{

    [TestClass]
    public class AsyncTaskExecutorScopeTests
    {

        class TestAsyncTaskExecutor :
            AsyncTaskExecutor
        {

            public override async Task ExecuteAsync(Func<Task> action)
            {
                CallContext.LogicalSetData("InTestExecutor", true);
                await base.ExecuteAsync(action);
            }

            public override async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> func)
            {
                CallContext.LogicalSetData("InTestExecutor", true);
                return await base.ExecuteAsync(func);
            }

        }

        [TestMethod]
        public void Test_handle()
        {
            var a = new HandleScope<AsyncTaskExecutorHandle>();
            WorkflowInvoker.Invoke(a);
        }

        [TestMethod]
        public void Test_default_scope()
        {
            var b = new AsyncFuncActivity<bool>(() => Task.FromResult(true));
            var a = new AsyncTaskExecutorScope<bool>(null, b);
            var o = WorkflowInvoker.Invoke(a);
            Assert.IsTrue(o);
        }

        [TestMethod]
        public void Test_custom_scope()
        {
            var b = new AsyncFuncActivity<bool>(() => Task.FromResult((bool)CallContext.LogicalGetData("InTestExecutor") == true));
            var a = new AsyncTaskExecutorScope<bool>(new TestAsyncTaskExecutor(), b);
            var o = WorkflowInvoker.Invoke(a);
            Assert.IsTrue(o);
        }

    }

}
