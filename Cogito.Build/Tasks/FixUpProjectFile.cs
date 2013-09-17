using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Cogito.Build.Tasks
{

    /// <summary>
    /// Applies fixes to the project file. These include cleaning up Imports and References to be based on SolutionDir.
    /// </summary>
    public class FixUpProjectFile : Task
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
        static readonly XNamespace msb = (XNamespace)@"http://schemas.microsoft.com/developer/msbuild/2003";

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
        static string GetRelativePath(string fromPath, string toPath)
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
        static void SetElementValue(XElement element, string value)
        {
            if (element.Value != value)
                element.Value = value;
        }

        /// <summary>
        /// Sets the value of the given attribute, checking for an actual change.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        static void SetAttributeValue(XAttribute attribute, string value)
        {
            if (attribute.Value != value)
                attribute.Value = value;
        }

        /// <summary>
        /// Injected path to the solution directory.
        /// </summary>
        [Required]
        public ITaskItem SolutionDir { get; set; }

        /// <summary>
        /// Injected path to the packages directory.
        /// </summary>
        [Required]
        public ITaskItem PackagesDir { get; set; }

        /// <summary>
        /// Injected path to project file.
        /// </summary>
        [Required]
        public ITaskItem ProjectFile { get; set; }

        /// <summary>
        /// Gets the path to the solution directory.
        /// </summary>
        /// <returns></returns>
        string GetSolutionDir()
        {
            return SolutionDir.ItemSpec;
        }

        /// <summary>
        /// Gets the path to the solution directory.
        /// </summary>
        /// <returns></returns>
        string GetPackagesDir()
        {
            return PackagesDir.ItemSpec;
        }

        /// <summary>
        /// Gets the path to the project file.
        /// </summary>
        /// <returns></returns>
        string GetProjectFile()
        {
            return ProjectFile.ItemSpec;
        }

        /// <summary>
        /// Gets the path to the target file which has included this task. This is the Cogito.Build.targets file.
        /// </summary>
        /// <returns></returns>
        string GetTargetFile()
        {
            return BuildEngine2.ProjectFileOfTaskNode;
        }

        /// <summary>
        /// Gets the path tot he Cogito.Build.props file.
        /// </summary>
        /// <returns></returns>
        string GetPropsFile()
        {
            return Path.ChangeExtension(GetTargetFile(), ".props");
        }

        /// <summary>
        /// Executes the task.
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            if (!Execute(GetProjectFile()))
                return false;

            return true;
        }

        /// <summary>
        /// Executes the task for the specified project file.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        bool Execute(string file)
        {
            if (!File.Exists(file))
                return true;

            file = Path.GetFullPath(file);

            // load project file
            var any = false;
            var xml = XDocument.Load(file, LoadOptions.PreserveWhitespace);
            xml.Changed += (s, a) => any = true;

            // generic fixups for elements
            foreach (var element in xml.Descendants())
                FixUp(element);

            // fixup import of Cogito.Build.props file
            FixUpBuildImportProps(file, xml);

            // fixup import of Cogito.Build.targets file
            FixUpBuildImportTargets(file, xml);

            // save if any changes
            if (any)
                xml.Save(file, SaveOptions.None);

            return true;
        }

        /// <summary>
        /// Applies generic fixups to the specified element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        void FixUp(XElement element)
        {
            // element does not contain children, treat as value
            if (!element.HasElements)
                SetElementValue(element, FixPath(element.Value));

            // fix up each attribute
            foreach (var attribute in element.Attributes())
                FixUp(attribute);
        }

        /// <summary>
        /// Applies generic fixups to the specific attribute.
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        void FixUp(XAttribute attribute)
        {
            SetAttributeValue(attribute, FixPath(attribute.Value));
        }

        /// <summary>
        /// Fixes up the include for Cogito.Build.props.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        void FixUpBuildImportProps(string file, XDocument xml)
        {
            // path to props file from SolutionDir
            var path = GetRelativePath(GetPackagesDir(), Path.GetFullPath(GetPropsFile()));
            path = Path.Combine(@"$(PackagesDir)", path);
            path = path.Replace(@"\.\", @"\");

            // expected values of the element
            var projectValue = path;
            var conditionValue = @"Exists('" + path + @"')";

            // potentially matching elements
            var imports = xml.Root
                .Elements(msb + "Import")
                .Where(i => ((string)i.Attribute("Project"))
                    .EndsWith(@"\Cogito.Build.props"));

            // first potential import
            var import = imports.FirstOrDefault();
            if (import == null)
                import = new XElement(msb + "Import",
                    new XAttribute("Project", projectValue), 
                    new XAttribute("Condition", conditionValue));

            // remove all but first element
            var remove = imports.Where(i => i != import);
            if (remove.Any())
                remove.ToList().Remove();

            // set proper values
            SetAttributeValue(import.Attribute("Project"), projectValue);
            SetAttributeValue(import.Attribute("Condition"), conditionValue);

            // Import elements at the top of the file
            var props = xml.Root.Elements()
                .SkipWhile(i => i.Name != msb + "Import")
                .TakeWhile(i => i.Name == msb + "Import");

            // insert after last import, if any; else at beginning
            if (!props.Contains(import))
            {
                var last = props.LastOrDefault();
                if (last != null)
                    last.AddAfterSelf(import);
                else
                    xml.Root.AddFirst(import);
            }
        }

        void FixUpBuildImportTargets(string file, XDocument xml)
        {
            // path to props file from SolutionDir
            var path = GetRelativePath(GetPackagesDir(), Path.GetFullPath(GetTargetFile()));
            path = Path.Combine(@"$(PackagesDir)", path);
            path = path.Replace(@"\.\", @"\");

            // expected values of the element
            var projectValue = path;
            var conditionValue = @"Exists('" + path + @"')";

            // potentially matching elements
            var imports = xml.Root
                .Elements(msb + "Import")
                .Where(i => ((string)i.Attribute("Project"))
                    .EndsWith(@"\Cogito.Build.targets"));

            // first potential import
            var import = imports.FirstOrDefault();
            if (import == null)
                import = new XElement(msb + "Import",
                    new XAttribute("Project", projectValue),
                    new XAttribute("Condition", conditionValue));

            // remove all but first element
            var remove = imports.Where(i => i != import);
            if (remove.Any())
                remove.ToList().Remove();

            // set proper values
            SetAttributeValue(import.Attribute("Project"), projectValue);
            SetAttributeValue(import.Attribute("Condition"), conditionValue);

            // Skip until first non Import element, then take rest of Imports following
            var props = xml.Root.Elements()
                .SkipWhile(i => i.Name == msb + "Import")
                .Where(i => i.Name == msb + "Import");

            // insert after last import, if any; else at beginning
            if (!props.Contains(import))
                xml.Root.Add(import);
        }

        string FixPath(string path)
        {
            return path
                .Replace(@"..\..\..\..\packages\", @"$(PackagesDir)\")
                .Replace(@"..\..\..\packages\", @"$(PackagesDir)\")
                .Replace(@"..\..\packages\", @"$(PackagesDir)\")
                .Replace(@"..\packages\", @"$(PackagesDir)\");
        }

    }

}
