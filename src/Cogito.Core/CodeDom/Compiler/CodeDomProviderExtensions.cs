using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace Cogito.CodeDom.Compiler
{

    /// <summary>
    /// Various extension methods for working with <see cref="CodeDomProvider"/>.
    /// </summary>
    public static class CodeDomProviderExtensions
    {

        /// <summary>
        /// Generates code for the specified Code Document Object Model (CodeDOM) compilation unit and returns it to
        /// the caller.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="compileUnit"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string GenerateCodeFromCompileUnit(
            this CodeDomProvider self,
            CodeCompileUnit compileUnit,
            CodeGeneratorOptions options)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            var w = new StringWriter();
            self.GenerateCodeFromCompileUnit(compileUnit, w, options);
            return w.ToString();
        }

    }

}
