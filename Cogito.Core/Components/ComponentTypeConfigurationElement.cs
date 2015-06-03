using System;
using System.Configuration;

namespace Cogito.Components
{

    public class ComponentTypeConfigurationElement :
        ConfigurationElement
    {

        [ConfigurationProperty("type", IsKey = true, IsRequired = true)]
        public string Type
        {
            get { return (string)base["type"]; }
            set { base["type"] = value; }
        }

    }

}
