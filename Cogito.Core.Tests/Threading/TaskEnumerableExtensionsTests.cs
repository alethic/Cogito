using System.Collections.Generic;
using System.Threading.Tasks;
using Cogito.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Tests.Threading
{

    [TestClass]
    public class TaskEnumerableExtensionsTests
    {

        [TestMethod]
        public void Test_ToArrayAsync()
        {
            var l = new List<Task<bool>>();
            for (int i = 99; i >= 0; i--)
            {
                var a = i;
                l.Add(Task.Run(async () => { await Task.Delay(a); return true; }));
            }

            l.ToArrayAsync().Wait();
        }

        [TestMethod]
        public void Test_ToSequentialArrayAsync()
        {
            var l = new List<Task<bool>>();
            for (int i = 0; i < 100; i++)
            {
                var a = i;
                l.Add(Task.Run(async () => { await Task.Delay(a); return true; }));
            }

            l.ToSequentialArrayAsync().Wait();
        }

    }

}
