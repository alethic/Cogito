using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Razor;
using System.Web.Razor.Parser.SyntaxTree;

namespace Cogito.Web.Razor
{

    /// <summary>
    /// Describes a set of errors that occurred during parsing of a Razor template.
    /// </summary>
    public class ParserErrorException : RazorException
    {

        GeneratorResults results;
        TextReader code;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="results"></param>
        internal ParserErrorException(GeneratorResults results, TextReader code)
            : base(results.ParserErrors[0].Message)
        {
            if (results == null)
                throw new ArgumentNullException(nameof(results));
            if (code == null)
                throw new ArgumentNullException(nameof(code));
            if (results.ParserErrors.Count == 0)
                throw new ArgumentOutOfRangeException(nameof(results));

            this.results = results;
            this.code = code;
        }

        /// <summary>
        /// Gets the results of the parse attempt.
        /// </summary>
        public GeneratorResults Results
        {
            get { return results; }
        }

        /// <summary>
        /// Gets the errors that occurred during compilation.
        /// </summary>
        public IEnumerable<RazorError> Errors
        {
            get { return results.ParserErrors; }
        }

        /// <summary>
        /// Gets the source code that was being compiled.
        /// </summary>
        public string Code
        {
            get { return code.ReadToEnd(); }
        }

    }

}
