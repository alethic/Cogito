using System.ComponentModel.Composition;
using System.Diagnostics;

using ISIS.Web.Mvc;

namespace ISIS.HigherGround.Web.Site.App_Start
{

    [Export(typeof(IApplicationPostStart))]
    public class PostStartSample : IApplicationPostStart
    {

        public PostStartSample()
        {

        }


        public void OnPostStart()
        {
            Trace.WriteLine("Hi!");
        }

    }

}