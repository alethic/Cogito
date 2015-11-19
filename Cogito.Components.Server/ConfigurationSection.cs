using System.Configuration;

namespace Cogito.Components.Server
{

    public class ConfigurationSection : 
        System.Configuration.ConfigurationSection
    {

        /// <summary>
        /// Returns the configuration.
        /// </summary>
        /// <returns></returns>
        public static ConfigurationSection GetDefaultSection()
        {
            return (ConfigurationSection)ConfigurationManager.GetSection("cogito.components.server") ?? new ConfigurationSection();
        }

        /// <summary>
        /// Describes the applications to be started.
        /// </summary>
        [ConfigurationProperty("applications")]
        public ApplicationConfigurationElementCollection Applications
        {
            get { return (ApplicationConfigurationElementCollection)this["applications"]; }
            set { this["applications"] = value; }
        }

        public override bool IsReadOnly()
        {
            return false;
        }

    }

}