using System.Configuration;

namespace Cogito.ServiceBus.MassTransit
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
            return (ConfigurationSection)ConfigurationManager.GetSection("cogito.serviceBus.massTransit") ?? new ConfigurationSection();
        }

        [ConfigurationProperty("host")]
        public string Host
        {
            get { return (string)this["host"]; }
            set { this["host"] = value; }
        }

        [ConfigurationProperty("vhost")]
        public string VHost
        {
            get { return (string)this["vhost"]; }
            set { this["vhost"] = value; }
        }

        [ConfigurationProperty("username")]
        public string Username
        {
            get { return (string)this["username"]; }
            set { this["username"] = value; }
        }

        [ConfigurationProperty("password")]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }

    }

}