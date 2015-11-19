using System.Configuration;

namespace Cogito.Components
{

    public class ComponentConfigurationSection :
        System.Configuration.ConfigurationSection
    {

        /// <summary>
        /// Returns the configuration.
        /// </summary>
        /// <returns></returns>
        public static ComponentConfigurationSection GetDefaultSection()
        {
            return (ComponentConfigurationSection)ConfigurationManager.GetSection("cogito.components") ?? new ComponentConfigurationSection();
        }

        /// <summary>
        /// Set of component types to start.
        /// </summary>
        [ConfigurationProperty("start")]
        public ComponentTypeConfigurationElementCollection Start
        {
            get { return (ComponentTypeConfigurationElementCollection)this["start"] ?? new ComponentTypeConfigurationElementCollection(); }
            set { this["start"] = value; }
        }

    }

}
