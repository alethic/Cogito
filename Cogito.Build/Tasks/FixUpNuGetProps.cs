using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Cogito.Build.Tasks
{

    /// <summary>
    /// Ensures NuGet.props is available and included properly in the project file.
    /// </summary>
    public class FixUpNuGetProps : Task
    {

        /// <summary>
        /// MSBuild namespace.
        /// </summary>
        static readonly XNamespace msb = (XNamespace)@"http://schemas.microsoft.com/developer/msbuild/2003";

        /// <summary>
        /// Injected path to project file.
        /// </summary>
        [Required]
        public ITaskItem ProjectFile { get; set; }

        /// <summary>
        /// Injected path to the solution directory.
        /// </summary>
        [Required]
        public ITaskItem SolutionDir { get; set; }

        /// <summary>
        /// Gets the target project files to be fixexd.
        /// </summary>
        /// <returns></returns>
        string GetProjectFile()
        {
            return ProjectFile.ItemSpec;
        }

        /// <summary>
        /// Gets the path to the solution directory.
        /// </summary>
        /// <returns></returns>
        string GetSolutionDir()
        {
            return SolutionDir.ItemSpec;
        }

        /// <summary>
        /// Gets the path to the source directory.
        /// </summary>
        /// <returns></returns>
        string GetSourceDir()
        {
            return new FileInfo(BuildEngine2.ProjectFileOfTaskNode).Directory.FullName;
        }

        /// <summary>
        /// Executes the task.
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            if (!EnsureNuGetPropsFile())
                return false;

            if (!Execute(GetProjectFile()))
                return false;

            return true;
        }

        /// <summary>
        /// Ensures the .nuget\NuGet.props file is created.
        /// </summary>
        /// <returns></returns>
        bool EnsureNuGetPropsFile()
        {
            var src = Path.Combine(GetSourceDir(), "NuGet.props");
            var dst = Path.Combine(GetSolutionDir(), @".nuget\NuGet.props");
            File.Copy(src, dst, true);

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

            // ensure nuget.props file is included at the proper position
            FixUp(file, xml);

            // save if any changes
            if (any)
                xml.Save(file, SaveOptions.None);

            return true;
        }

        /// <summary>
        /// Ensures the nuget.props file is properly referenced.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        void FixUp(string file, XDocument xml)
        {
            var projectValue = @"$(SolutionDir)\.nuget\NuGet.props";
            var conditionValue = @"Exists('$(SolutionDir)\.nuget\NuGet.props')";

            // potentially matching elements
            var imports = xml.Root
                .Elements(msb + "Import")
                .Where(i => ((string)i.Attribute("Project"))
                    .EndsWith(@"\NuGet.props"));

            // first potential import
            var import = imports.FirstOrDefault();
            if (import == null)
                import = new XElement(msb + "Import");

            // remove all but first element
            var remove = imports.Where(i => i != import);
            if (remove.Any())
                remove.ToList().Remove();

            // set proper values
            import.SetAttributeValue("Project", projectValue);
            import.SetAttributeValue("Condition", conditionValue);

            // move to first position if not already there
            if (xml.Root.FirstNode != import)
            {
                if (import.Parent != null)
                    import.Remove();
                xml.Root.AddFirst(import);
            }
        }

    }

}
