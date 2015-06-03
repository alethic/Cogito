using System.Configuration;

namespace Cogito.Components
{

    public class ComponentTypeConfigurationElementCollection :
        ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new ComponentTypeConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ComponentTypeConfigurationElement)element).Type;
        }

    }

}
