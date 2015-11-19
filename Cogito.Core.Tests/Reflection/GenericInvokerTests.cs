using System;
using Cogito.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests.Reflection
{

    [TestClass]
    public class GenericInvokerTests
    {

        static T1 TestMethod<T1>(T1 t1)
        {
            return t1;
        }

        //[TestMethod]
        //public void Invoke_with_1_arg()
        //{
        //    var r = GenericInvoker.Invoke(typeof(int), () => TestMethod<object>(new object()));
        //    Assert.AreEqual(typeof(object), r.GetType());
        //}

    }

}
