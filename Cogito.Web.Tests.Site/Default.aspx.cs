using System;
using System.Web.UI;

using Cogito.Composition;
using Cogito.Composition.Hosting;
using Cogito.Composition.Scoping;

namespace Cogito.Web.Tests.Site
{

    public partial class Default : 
        Page
    {

        protected void Page_Load(object sender, EventArgs args)
        {
            var scope = ContainerManager.GetDefaultTypeResolver().Resolve<IScopeTypeResolver>().Resolve<ITypeResolver, IWebRequestScope>();
        }

    }

}