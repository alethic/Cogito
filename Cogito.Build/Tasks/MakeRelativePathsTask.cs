using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Build.Framework;

namespace Cogito.Build.Tasks
{

    /// <summary>
    /// Makes paths in the specified MSBuild file relative to the provided path variables.
    /// </summary>
    public class MakeRelativePathsTask : CogitoTask
    {

        /// <summary>
        /// Variable name and destination path.
        /// </summary>
        class Variable
        {

            public string Name { get; set; }

            public string Path { get; set; }

        }

        /// <summary>
        /// The path variables sorted by priority.
        /// </summary>
        List<Variable> variables;

        /// <summary>
        /// Variables and the paths they refer to.
        /// </summary>
        [Required]
        public ITaskItem[] Variables { get; set; }

        /// <summary>
        /// MSBuild project file to update.
        /// </summary>
        [Required]
        public string ProjectFile { get; set; }

        /// <summary>
        /// Executes the task.
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            if (!File.Exists(ProjectFile))
                return true;

            // sort targets by length: longest takes priority
            variables = Variables
                .Select(i => new Variable()
                {
                    Name = i.ItemSpec,
                    Path  = i.GetMetadata("Path"),
                })
                .OrderByDescending(i => i.Path.Length)
                .ToList();

            // load project file
            var xml = XDocument.Load(ProjectFile, LoadOptions.PreserveWhitespace);

            // work from root element down
            Process(xml.Root);

            // saves the MSBuild file if it's actually changed
            xml.Update(ProjectFile);

            return true;
        }

        /// <summary>
        /// Applies fixes to the element and all it's subelements.
        /// </summary>
        /// <param name="element"></param>
        void Process(XElement element)
        {
            Contract.Requires<ArgumentNullException>(element != null);

            // process attributes
            foreach (var attribute in element.Attributes())
                Process(attribute);

            // element does not contain children, treat as value
            if (element.HasElements)
                foreach (var i in element.Elements())
                    Process(i);
            else
                // apply fixes to contents
                Process(element.Value, i => element.Value = i);
        }

        /// <summary>
        /// Apply fixes to the attribute.
        /// </summary>
        /// <param name="attribute"></param>
        void Process(XAttribute attribute)
        {
            Process(attribute.Value, i => attribute.Value = i);
        }

        /// <summary>
        /// Applies fixes to the specified value, and then sets it using the given setter.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="set"></param>
        void Process(string value, Action<string> set)
        {
            // replace known variables
            var path = value;
            foreach (var variable in variables)
                path = path.Replace(string.Format(@"$({0})", variable.Name), variable.Path);

            // value does not refer to a file system item
            if (!File.Exists(value) &&
                !Directory.Exists(value))
                return;

            // evaluate each target in order
            foreach (var variable in variables)
            {
                var name = variable.Name;
                var dest = variable.Path;

                // relative variable doesnt refer to a file system item
                if (!File.Exists(dest) &&
                    !Directory.Exists(dest))
                    continue;

                // make absolute
                path = Path.GetFullPath(path);
                dest = Path.GetFullPath(dest);

                // input path must be a sub-item of the target
                if (!path.StartsWith(dest))
                    continue;

                // make path relative to destination
                var rela = GetRelativePath(dest, path);
                if (rela != path)
                    // final check for whether file exists
                    if (File.Exists(Path.Combine(dest, path)) ||
                        Directory.Exists(Path.Combine(dest, path)))
                    {
                        // update value to point to path, and finish
                        set(rela = Path.Combine(string.Format(@"$({0})", name), rela.Trim(Path.DirectorySeparatorChar, '.')));
                        break;
                    }
            }
        }

    }

}
