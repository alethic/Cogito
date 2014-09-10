using System.Configuration;

namespace Cogito.ServiceBus.Configuration
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
            return (ConfigurationSection)System.Configuration.ConfigurationManager.GetSection("cogito.serviceBus");
        }

        /// <summary>
        /// Gets or sets the transport identifier. This identifies the implementation of the service bus to use.
        /// </summary>
        [ConfigurationProperty("transport")]
        public string Transport
        {
            get { return (string)this["transport"]; }
            set { this["transport"] = value; }
        }

        /// <summary>
        /// Gets or sets the transport URI.
        /// </summary>
        [ConfigurationProperty("uri")]
        public string Uri
        {
            get { return (string)this["uri"]; }
            set { this["uri"] = value; }
        }

    }
}
