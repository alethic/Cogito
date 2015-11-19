using System;
using System.Collections.Generic;
using System.Configuration;

namespace Cogito.Components.Server
{

    public class ApplicationConfigurationElementCollection :
        ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new ApplicationConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ApplicationConfigurationElement)element).Name;
        }

    }

}
