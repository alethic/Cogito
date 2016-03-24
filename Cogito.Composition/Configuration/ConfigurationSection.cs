using System.Configuration;

namespace Cogito.Composition.Configuration
{

    public class ConfigurationSection : 
        System.Configuration.ConfigurationSection
    {

        /// <summary>
        /// Gets the standard "cogito.composition" configuration section.
        /// </summary>
        /// <returns></returns>
        public static ConfigurationSection GetDefaultSection()
        {
            return (ConfigurationSection)ConfigurationManager.GetSection("cogito.composition");
        }

        /// <summary>
        /// Represents a named set of configured containers accessible by multiple components.
        /// </summary>
        [ConfigurationProperty("containers")]
        public ContainersCollection Containers
        {
            get { return (ContainersCollection)this["containers"]; }
            set { this["containers"] = value; }
        }

    }

}
