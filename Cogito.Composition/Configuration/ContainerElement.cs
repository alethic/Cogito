using System.Configuration;
using System.Xml;
using System.Xml.Linq;

namespace Cogito.Composition.Configuration
{

    /// <summary>
    /// Describes a named <see cref="CompositionContainer"/>. The body of this element should be a XAML instance of a 
    /// <see cref="CompositionContainer"/>.
    /// </summary>
    public class ContainerElement : 
        ConfigurationElement
    {

        XElement xaml;

        /// <summary>
        /// Gets or sets the name of the container.
        /// </summary>
        [ConfigurationProperty("name", IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// XAML body of configuration element.
        /// </summary>
        public XElement Xaml
        {
            get { return xaml; }
            set { xaml = value; }
        }

        protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
        {
            // parse element into XML for later instantiation
            xaml = XElement.Load(reader.ReadSubtree(), LoadOptions.None);
            return true;
        }

    }

}
