using System;
using System.Activities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Activities.Tests
{

    [TestClass]
    public class ForTests
    {

        [TestMethod]
        public void Test_For()
        {
            var c = 0;
            var a = new For<int>()
            {
                Initial = 0,
                Increment = Activities.Delegate<int, int>(arg => Activities.Invoke(arg, i => i + 1)),
                Condition = Activities.Delegate<int, bool>(arg => Activities.Invoke(i => i < 10, arg)),
                Action = Activities.Delegate<int>(arg => Activities.Invoke(i => { Console.WriteLine(i); c++; }, arg)),
            };

            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(10, c);
        }

        [TestMethod]
        public void Test_For_Start()
        {
            var c = 0;
            var a = new For<int>()
            {
                Initial = 5,
                Increment = Activities.Delegate<int, int>(arg => Activities.Invoke(i => i + 1, arg)),
                Condition = Activities.Delegate<int, bool>(arg => Activities.Invoke(i => i < 15, arg)),
                Action = Activities.Delegate<int>(arg => Activities.Invoke(i => { Console.WriteLine(i); c++; }, arg)),
            };

            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(10, c);
        }

        [TestMethod]
        public void Test_Range()
        {
            var t = 0;
            var c = 0;
            var a = Activities.Range(0, 10, i => { t = i; c++; });
            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(10, c);
            Assert.AreEqual(9, t);
        }

        [TestMethod]
        public void Test_Range_Offset()
        {
            var t = 0;
            var c = 0;
            var a = Activities.Range(5, 10, i => { t = i; c++; });
            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(10, c);
            Assert.AreEqual(14, t);
        }

    }

}
