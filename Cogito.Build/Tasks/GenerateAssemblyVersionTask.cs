using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.CSharp;

namespace Cogito.Build.Tasks
{

    /// <summary>
    /// Generates an assembly version C# file.
    /// </summary>
    public class GenerateAssemblyVersionTask : Task
    {

        /// <summary>
        /// Injected path to output the generated AssemblyVersion file.
        /// </summary>
        [Required]
        public string OutputFile { get; set; }

        /// <summary>
        /// Executes the task.
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            // version number based on date and time
            var version = string.Format(@"{0}.{1}.{2}.{3}",
                DateTime.UtcNow.Year,
                DateTime.UtcNow.Month,
                DateTime.UtcNow.Day,
                DateTime.UtcNow.Hour * 100 + DateTime.UtcNow.Minute);

            var cu = new CodeCompileUnit();
            
            var a1 = new CodeAttributeDeclaration(new CodeTypeReference(typeof(AssemblyVersionAttribute)));
            a1.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(version)));
            cu.AssemblyCustomAttributes.Add(a1);

            var a2 = new CodeAttributeDeclaration(new CodeTypeReference(typeof(AssemblyFileVersionAttribute)));
            a2.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(version)));
            cu.AssemblyCustomAttributes.Add(a2);

            var a3 = new CodeAttributeDeclaration(new CodeTypeReference(typeof(AssemblyInformationalVersionAttribute)));
            a3.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(version)));
            cu.AssemblyCustomAttributes.Add(a3);

            // write to output file
            using (var writer = File.CreateText(OutputFile))
                new CSharpCodeProvider().GenerateCodeFromCompileUnit(cu, writer, new CodeGeneratorOptions());

            return true;
        }

    }

}
