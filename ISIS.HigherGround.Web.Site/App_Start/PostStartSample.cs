using System.ComponentModel.Composition;
using System.Diagnostics;

using Cogito.Application;

namespace ISIS.HigherGround.Web.Site.App_Start
{

    [Export(typeof(IApplicationAfterStart))]
    public class PostStartSample : IApplicationAfterStart
    {

        public PostStartSample()
        {

        }


        public void OnAfterStart()
        {
            Trace.WriteLine("Hi!");
        }

    }

}