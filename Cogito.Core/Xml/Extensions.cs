using System.Xml;
using System.Xml.Linq;

namespace Cogito.Xml
{

    public static class Extensions
    {

        /// <summary>
        /// Returns an XLinq node from the given <see cref="XmlNode"/>.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static XNode ToXNode(this XmlNode node)
        {
            var rdr = new XmlNodeReader(node);
            rdr.MoveToContent();
            return XNode.ReadFrom(rdr);
        }

        /// <summary>
        /// Returns an XLinq node from the given <see cref="XmlNode"/>.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XElement ToXNode(this XmlElement element)
        {
            return (XElement)((XmlNode)element).ToXNode();
        }

        /// <summary>
        /// Returns a <see cref="XmlElement"/> from the given <see cref="XElement"/>.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XmlElement ToXmlNode(this XElement element)
        {
            var xml = new XmlDocument();
            xml.Load(new XDocument(element).CreateReader());
            return xml.DocumentElement;
        }

        /// <summary>
        /// Returns an XLinq node from the given <see cref="XmlNode"/>.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static XDocument ToXNode(this XmlDocument document)
        {
            return (XDocument)((XmlNode)document).ToXNode();
        }

    }

}
