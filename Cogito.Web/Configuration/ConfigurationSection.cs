using System.Configuration;

namespace Cogito.Web.Configuration
{

    public class ConfigurationSection :
        System.Configuration.ConfigurationSection
    {

        /// <summary>
        /// Gets the standard "cogito.web" configuration section.
        /// </summary>
        /// <returns></returns>
        public static ConfigurationSection GetDefaultSection()
        {
            return (ConfigurationSection)System.Configuration.ConfigurationManager.GetSection("cogito.web") ??
                new ConfigurationSection();
        }

        /// <summary>
        /// Configuration related to composition.
        /// </summary>
        [ConfigurationProperty("composition")]
        public CompositionElement Composition
        {
            get { return (CompositionElement)this["composition"] ?? new CompositionElement(); }
            set { this["composition"] = value; }
        }

    }
}
