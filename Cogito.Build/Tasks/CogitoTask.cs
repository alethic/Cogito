using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

using Microsoft.Build.Utilities;

namespace Cogito.Build.Tasks
{

    /// <summary>
    /// Base task for Cogito.Build.
    /// </summary>
    public abstract class CogitoTask : Task
    {

        const int FILE_ATTRIBUTE_DIRECTORY = 0x10;
        const int FILE_ATTRIBUTE_NORMAL = 0x80;

        /// <summary>
        /// Finds the relative path from one absolute path to another.
        /// </summary>
        /// <param name="pszPath"></param>
        /// <param name="pszFrom"></param>
        /// <param name="dwAttrFrom"></param>
        /// <param name="pszTo"></param>
        /// <param name="dwAttrTo"></param>
        /// <returns></returns>
        [DllImport("shlwapi.dll", SetLastError = true)]
        static extern int PathRelativePathTo(StringBuilder pszPath, string pszFrom, int dwAttrFrom, string pszTo, int dwAttrTo);

        /// <summary>
        /// MSBuild namespace.
        /// </summary>
        protected static readonly XNamespace MSBuild = (XNamespace)@"http://schemas.microsoft.com/developer/msbuild/2003";

        /// <summary>
        /// Gets the FILE_ATTRIBUTE value for the given path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static int GetPathAttribute(string path)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(path));

            var di = new DirectoryInfo(path);
            if (di.Exists)
                return FILE_ATTRIBUTE_DIRECTORY;

            var fi = new FileInfo(path);
            if (fi.Exists)
                return FILE_ATTRIBUTE_NORMAL;

            throw new FileNotFoundException();
        }

        /// <summary>
        /// Finds the relative path from one absolute path to another.
        /// </summary>
        /// <param name="fromPath"></param>
        /// <param name="toPath"></param>
        /// <returns></returns>
        protected static string GetRelativePath(string fromPath, string toPath)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(fromPath));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(toPath));

            var fromAttr = GetPathAttribute(fromPath);
            var toAttr = GetPathAttribute(toPath);

            var path = new StringBuilder(260); // MAX_PATH
            if (PathRelativePathTo(path, fromPath, fromAttr, toPath, toAttr) == 0)
                throw new ArgumentException("Paths must have a common prefix");

            return path.ToString();
        }

        /// <summary>
        /// Sets the value of the given attribute, checking for an actual change.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected static void SetElementValue(XElement element, string value)
        {
            Contract.Requires<ArgumentNullException>(element != null);

            if (element.Value != value)
                element.Value = value;
        }

        /// <summary>
        /// Sets the value of the given attribute, checking for an actual change.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        protected static void SetAttributeValue(XAttribute attribute, string value)
        {
            Contract.Requires<ArgumentNullException>(attribute != null);

            if (attribute.Value != value)
                attribute.Value = value;
        }

    }

}
