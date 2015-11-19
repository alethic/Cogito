using System.Configuration;

namespace Cogito.Web.Configuration
{

    /// <summary>
    /// Describes the configuration of the composition framework with regards to a web application.
    /// </summary>
    public class CompositionElement : 
        System.Configuration.ConfigurationElement
    {

        /// <summary>
        /// Gets or sets the name of the container to use.
        /// </summary>
        [ConfigurationProperty("containerName")]
        [DefaultSettingValue("Default")]
        public string ContainerName
        {
            get { return (string)this["containerName"]; }
            set { this["containerName"] = value; }
        }

    }

}
