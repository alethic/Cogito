﻿using System;
using System.Activities;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Activities.Tests
{

    [TestClass]
    public class ForTests
    {

        [TestMethod]
        public void Test_for()
        {
            var c = 0;
            var a = new For<int>()
            {
                Initial = 0,
                Increment = Expressions.Delegate<int, int>(arg => Expressions.Invoke(async i => i + 1, arg)),
                Condition = Expressions.Delegate<int, bool>(arg => Expressions.Invoke(async i => i < 10, arg)),
                Action = Expressions.Delegate<int>(arg => Expressions.Invoke(async i => { Console.WriteLine(i); c++; }, arg)),
            };

            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(10, c);
        }

        [TestMethod]
        public void Test_for_with_offset()
        {
            var c = 0;
            var a = new For<int>()
            {
                Initial = 5,
                Increment = Expressions.Delegate<int, int>(arg => Expressions.Invoke(async i => i + 1, arg)),
                Condition = Expressions.Delegate<int, bool>(arg => Expressions.Invoke(async i => i < 15, arg)),
                Action = Expressions.Delegate<int>(arg => Expressions.Invoke(async i => { Console.WriteLine(i); c++; }, arg)),
            };

            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(10, c);
        }

        [TestMethod]
        public void Test_range()
        {
            var t = 0;
            var c = 0;
            var a = Expressions.Range(0, 10, async i => { t = i; c++; });
            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(10, c);
            Assert.AreEqual(9, t);
        }

        [TestMethod]
        public void Test_range_with_offset()
        {
            var t = 0;
            var c = 0;
            var a = Expressions.Range(5, 10, async i => { t = i; c++; });
            var b = WorkflowInvoker.Invoke(a);
            Assert.AreEqual(10, c);
            Assert.AreEqual(14, t);
        }

    }

}
