using System.Activities;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Activities.Tests
{

    [TestClass]
    public class WaitTests
    {

        [TestMethod]
        public async Task Test_wait()
        {
            var wf = new WorkflowApplication(new Wait("Bookmark"));
            await wf.RunAsync();
            await Task.Delay(1000);
            Assert.AreEqual(BookmarkResumptionResult.Success, await wf.ResumeBookmarkAsync("Bookmark", null));
            await wf.WaitForCompletionAsync();
        }

        [TestMethod]
        public async Task Test_wait_result()
        {
            var wf = new WorkflowApplication(new Wait<string>("Bookmark"));
            await wf.RunAsync();
            await Task.Delay(1000);
            Assert.AreEqual(BookmarkResumptionResult.Success, await wf.ResumeBookmarkAsync("Bookmark", "Done"));
            Assert.AreEqual("Done", (string)(await wf.WaitForCompletionAsync())["Result"]);
        }

    }

}
