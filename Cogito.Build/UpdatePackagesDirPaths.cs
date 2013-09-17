using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Cogito.Build
{

    public class UpdatePackagesDirPaths : Task
    {

        const int FILE_ATTRIBUTE_DIRECTORY = 0x10;
        const int FILE_ATTRIBUTE_NORMAL = 0x80;

        [DllImport("shlwapi.dll", SetLastError = true)]
        private static extern int PathRelativePathTo(StringBuilder pszPath,
            string pszFrom, int dwAttrFrom, string pszTo, int dwAttrTo);

        static readonly XNamespace msb = (XNamespace)@"http://schemas.microsoft.com/developer/msbuild/2003";

        static string GetRelativePath(string fromPath, string toPath)
        {
            int fromAttr = GetPathAttribute(fromPath);
            int toAttr = GetPathAttribute(toPath);

            var path = new StringBuilder(260); // MAX_PATH
            if (PathRelativePathTo(path, fromPath, fromAttr, toPath, toAttr) == 0)
                throw new ArgumentException("Paths must have a common prefix");

            return path.ToString();
        }

        static int GetPathAttribute(string path)
        {
            var di = new DirectoryInfo(path);
            if (di.Exists)
                return FILE_ATTRIBUTE_DIRECTORY;

            var fi = new FileInfo(path);
            if (fi.Exists)
                return FILE_ATTRIBUTE_NORMAL;

            throw new FileNotFoundException();
        }

        /// <summary>
        /// Gets the path to the target file itself.
        /// </summary>
        /// <returns></returns>
        string GetTargetFile()
        {
            return BuildEngine2.ProjectFileOfTaskNode;
        }

        /// <summary>
        /// Gets the path to the props file itself.
        /// </summary>
        /// <returns></returns>
        string GetPropsFile()
        {
            return Path.ChangeExtension(GetTargetFile(), ".props");
        }

        [Required]
        public ITaskItem[] MSBuildProjectFile { get; set; }

        public override bool Execute()
        {
            foreach (var i in MSBuildProjectFile)
                if (!Execute(i))
                    return false;

            return true;
        }

        bool Execute(ITaskItem file)
        {
            return Execute(file.ItemSpec);
        }

        bool Execute(string file)
        {
            if (!File.Exists(file))
                return true;

            file = Path.GetFullPath(file);

            var any = false;
            var xml = XDocument.Load(file, LoadOptions.PreserveWhitespace);
            foreach (var element in xml.Descendants())
                any |= FixUp(element);

            any |= FixUpBuildImportProps(file, xml);
            any |= FixUpBuildImportTargets(file, xml);

            if (any)
                xml.Save(file, SaveOptions.None);

            return true;
        }

        bool FixUp(XElement element)
        {
            var any = false;
            if (!element.HasElements)
            {
                var val = FixPath(element.Value);
                if (any |= element.Value != val)
                    element.Value = val;
            }

            foreach (var attribute in element.Attributes())
                any |= FixUp(attribute);

            return any;
        }

        bool FixUp(XAttribute attribute)
        {
            var any = false;

            var val = FixPath(attribute.Value);
            if (any |= attribute.Value != val)
                attribute.Value = val;

            return any;
        }

        bool FixUpBuildImportProps(string file, XDocument xml)
        {
            var any = false;

            // generate desired path
            var path = FixPath(GetRelativePath(file, Path.GetFullPath(GetPropsFile())));

            // all relevant import elements
            var imports = xml.Descendants(msb + "Import")
                .Select(i => new
                {
                    Element = i,
                    Project = (string)i.Attribute("Project"),
                    Condition = (string)i.Attribute("Condition"),
                })
                .Where(i => i.Project != null)
                .Where(i => i.Project.EndsWith(@"\Cogito.Build.props"))
                .ToList();

            // import element that is actually correct
            var correct = imports
                .Where(i => i.Project == path)
                .Where(i => i.Condition == @"Exists('" + path + @"')")
                .Take(1)
                .ToList();

            // should only have one item, if we have some other number, delete them all
            var invalid = imports.Select(i => i.Element).Except(correct.Select(i => i.Element)).ToList();
            if (invalid.Count > 0)
            {
                invalid.Remove();
                any = true;
            }

            // no correct elements exist, add ourselves
            if (correct.Count == 0)
            {
                xml.Element(msb + "Project").Elements(msb + "PropertyGroup").First().AddBeforeSelf(new XElement(msb + "Import",
                    new XAttribute("Project", path),
                    new XAttribute("Condition", "Exists('" + path + @"')")));
                any = true;
            }

            return any;
        }

        bool FixUpBuildImportTargets(string file, XDocument xml)
        {
            var any = false;

            // generate desired path
            var path = FixPath(GetRelativePath(file, Path.GetFullPath(GetTargetFile())));

            // all relevant import elements
            var imports = xml.Descendants(msb + "Import")
                .Select(i => new
                {
                    Element = i,
                    Project = (string)i.Attribute("Project"),
                    Condition = (string)i.Attribute("Condition"),
                })
                .Where(i => i.Project != null)
                .Where(i => i.Project.EndsWith(@"\Cogito.Build.targets"))
                .ToList();

            // import element that is actually correct
            var correct = imports
                .Where(i => i.Project == path)
                .Where(i => i.Condition == @"Exists('" + path + @"')")
                .Take(1)
                .ToList();

            // should only have one item, if we have some other number, delete them all
            var invalid = imports.Select(i => i.Element).Except(correct.Select(i => i.Element)).ToList();
            if (invalid.Count > 0)
            {
                invalid.Remove();
                any = true;
            }

            // no correct elements exist, add ourselves
            if (correct.Count == 0)
            {
                xml.Element(msb + "Project").LastNode.AddAfterSelf(new XElement(msb + "Import",
                    new XAttribute("Project", path),
                    new XAttribute("Condition", "Exists('" + path + @"')")));
                any = true;
            }

            return any;
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
