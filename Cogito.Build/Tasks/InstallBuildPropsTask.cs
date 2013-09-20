using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Build.Framework;

namespace Cogito.Build.Tasks
{

    /// <summary>
    /// Applies fixes to the project file. These include cleaning up Imports and References to be based on SolutionDir.
    /// </summary>
    public class InstallBuildPropsTask : CogitoTask
    {

        /// <summary>
        /// Injected path to the solution directory.
        /// </summary>
        [Required]
        public string SolutionDir { get; set; }

        /// <summary>
        /// Injected path to the packages directory.
        /// </summary>
        [Required]
        public string PackagesDir { get; set; }

        /// <summary>
        /// Injected path to project file.
        /// </summary>
        [Required]
        public string ProjectFile { get; set; }

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
            if (!Execute(ProjectFile))
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
            var xml = XDocument.Load(file, LoadOptions.PreserveWhitespace);

            // fixup import of Cogito.Build.props file
            FixUpBuildImportProps(file, xml);

            // fixup import of Cogito.Build.targets file
            FixUpBuildImportTargets(file, xml);

            // save if any changes
            xml.Update(file);

            return true;
        }

        /// <summary>
        /// Fixes up the include for Cogito.Build.props.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        void FixUpBuildImportProps(string file, XDocument xml)
        {
            Contract.Requires<ArgumentNullException>(xml != null);

            // path to props file from SolutionDir
            var path = Cogito.Build.Common.Path.MakeRelativePath(PackagesDir, Path.GetFullPath(GetPropsFile()));
            path = Path.Combine(@"$(PackagesDir)", path);
            path = path.Replace(@"\.\", @"\");

            // expected values of the element
            var projectValue = path;
            var conditionValue = @"Exists('" + path + @"')";

            // potentially matching elements
            var imports = xml.Root
                .Elements(MSBuild + "Import")
                .Where(i => ((string)i.Attribute("Project"))
                    .EndsWith(@"\Cogito.Build.props"));

            // first potential import
            var import = imports.FirstOrDefault();
            if (import == null)
                import = new XElement(MSBuild + "Import",
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
                .SkipWhile(i => i.Name != MSBuild + "Import")
                .TakeWhile(i => i.Name == MSBuild + "Import");

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
            Contract.Requires<ArgumentNullException>(xml != null);

            // path to props file from SolutionDir
            var path = Cogito.Build.Common.Path.MakeRelativePath(PackagesDir, Path.GetFullPath(GetTargetFile()));
            path = Path.Combine(@"$(PackagesDir)", path);
            path = path.Replace(@"\.\", @"\");

            // expected values of the element
            var projectValue = path;
            var conditionValue = @"Exists('" + path + @"')";

            // potentially matching elements
            var imports = xml.Root
                .Elements(MSBuild + "Import")
                .Where(i => ((string)i.Attribute("Project"))
                    .EndsWith(@"\Cogito.Build.targets"));

            // first potential import
            var import = imports.FirstOrDefault();
            if (import == null)
                import = new XElement(MSBuild + "Import",
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
                .SkipWhile(i => i.Name == MSBuild + "Import")
                .Where(i => i.Name == MSBuild + "Import");

            // insert after last import, if any; else at beginning
            if (!props.Contains(import))
                xml.Root.Add(import);
        }

    }

}
