using System.ComponentModel.Composition;

namespace Cogito.Web
{

    [Export(typeof(IWebConfiguration))]
    public class WebConfiguration : IWebConfiguration
    {

        public bool Available { get; set; }

    }

}
