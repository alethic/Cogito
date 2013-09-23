using System.Configuration;

namespace Cogito.Composition.Hosting.Configuration
{

    [ConfigurationCollection(typeof(ContainerElement))]
    public class ContainersCollection : System.Configuration.ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new ContainerElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ContainerElement)element).Name;
        }

        public new ContainerElement this[string name]
        {
            get { return (ContainerElement)base.BaseGet(name); }
        }

    }

}
