using System.Configuration;

namespace Cogito.Composition.Configuration
{

    [ConfigurationCollection(typeof(ContainerElement))]
    public class ContainersCollection : 
        System.Configuration.ConfigurationElementCollection
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

        /// <summary>
        /// Gets or sets the name of the default container.
        /// </summary>
        [ConfigurationProperty("default", IsRequired = false, DefaultValue = "Default")]
        public string Default
        {
            get { return (string)base["default"]; }
            set { base["default"] = value; }
        }

    }

}
