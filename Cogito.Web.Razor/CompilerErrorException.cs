using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace Cogito.Web.Razor
{

    /// <summary>
    /// Describes a set of compiler errors.
    /// </summary>
    public class CompilerErrorException : RazorException
    {

        readonly IEnumerable<CompilerError> errors;
        readonly string code;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="errors"></param>
        internal CompilerErrorException(CompilerErrorCollection errors, string code)
            : base(errors[0].ErrorText)
        {
            if (errors == null)
                throw new ArgumentNullException(nameof(errors));
            if (code == null)
                throw new ArgumentNullException(nameof(code));

            this.errors = errors.Cast<CompilerError>();
            this.code = code;
        }

        /// <summary>
        /// Gets the errors that occurred during compilation.
        /// </summary>
        public IEnumerable<CompilerError> Errors
        {
            get { return errors; }
        }

        public string Code
        {
            get { return code; }
        }

    }

}
