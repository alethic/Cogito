using Cogito.Composition.Hosting;
using Cogito.Composition;
using Nancy.ModelBinding;

namespace Cogito.Nancy.Web.UI.Tests.Site
{

    public class NancyBootstrapper :
        Cogito.Nancy.NancyBootstrapper
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public NancyBootstrapper()
            : base((CompositionContainer)ContainerManager.GetDefaultContainer())
        {

        }

        protected override void ConfigureInternalContainer(System.ComponentModel.Composition.Hosting.CompositionContainer parent)
        {
            var c = parent;
            c.AsContext().AddExportedValue<IFieldNameConverter>(new DefaultFieldNameConverter());
            c.AsContext().AddExportedValue<BindingDefaults>(new BindingDefaults());
        }

    }

}