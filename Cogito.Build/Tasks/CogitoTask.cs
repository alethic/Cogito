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

        /// <summary>
        /// Namespace of elements in MSBuild file.
        /// </summary>
        public static readonly XNamespace MSBuild = (XNamespace)"http://schemas.microsoft.com/developer/msbuild/2003";

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
