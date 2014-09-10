using System.Configuration;

namespace Cogito.Application.Configuration
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
            return (ConfigurationSection)System.Configuration.ConfigurationManager.GetSection("cogito.application");
        }

        /// <summary>
        /// Gets or sets the application ID. This is a unique .Net compatible identifier that can be used for various identification purposes.
        /// </summary>
        [ConfigurationProperty("id")]
        public string ApplicationId
        {
            get { return (string)this["id"]; }
            set { this["id"] = value;}
        }

    }
}
