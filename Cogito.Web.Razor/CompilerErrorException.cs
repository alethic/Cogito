﻿using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace Cogito.Web.Razor
{

    /// <summary>
    /// Describes a set of compiler errors.
    /// </summary>
    public class CompilerErrorException : RazorException
    {

        IEnumerable<CompilerError> errors;
        string code;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="errors"></param>
        internal CompilerErrorException(CompilerErrorCollection errors, string code)
            : base(errors[0].ErrorText)
        {
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
