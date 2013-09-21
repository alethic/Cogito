using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Cogito.Build.Tasks
{

    public static class XDocumentExtensions
    {

        /// <summary>
        /// Serializes this <see cref="XDocument"/> to a file, but only if the contents have changed.
        /// </summary>
        /// <param name="document"></param>
        /// <param name="fileName"></param>
        public static void Update(this XDocument document, string fileName)
        {
            Contract.Requires<ArgumentNullException>(document != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(fileName));

            // save new XML to string
            var str = new StringBuilder();
            using (var wrt = new StringWriter(str))
                document.Save(wrt, SaveOptions.DisableFormatting | SaveOptions.OmitDuplicateNamespaces);

            // save if the old data has changed
            var old = File.Exists(fileName) ? File.ReadAllText(fileName) : "";
            if (old != str.ToString())
                File.WriteAllText(fileName, str.ToString(), Encoding.Unicode);
        }

    }

}
