using System.Globalization;
using System.Web.Razor.Text;

using Cogito.Web.Razor.Parser;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Implements an extended <see cref="CSharpCodeParser"/> that adds functionality for Nancy Razor views.
    /// </summary>
    public class NancyCSharpRazorCodeParser : CSharpCodeParser
    {

        bool modelStatementFound;
        bool inheritsStatementFound;

        /// <summary>
        /// Initializes a new instance of the <see cref="NancyCSharpRazorCodeParser"/> class.
        /// </summary>
        public NancyCSharpRazorCodeParser()
            : base()
        {
            MapDirectives(ModelDirective, "model");
        }

        protected override void InheritsDirective()
        {
            inheritsStatementFound = true;
            CheckForInheritsAndModelStatements(CurrentLocation);
            base.InheritsDirective();
        }

        protected virtual void ModelDirective()
        {
            // duplicate statement
            if (modelStatementFound)
                Context.OnError(CurrentLocation,
                    string.Format(CultureInfo.CurrentCulture, "Cannot have more than one @model statement."));

            modelStatementFound = true;
            CheckForInheritsAndModelStatements(CurrentLocation);

            AssertDirective("model");
            AcceptAndMoveNext();

            BaseTypeDirective("The 'model' keyword must be followed by a type name on the same line.", s =>
                new NancyRazorCSharpModelCodeGenerator(s));
        }

        void CheckForInheritsAndModelStatements(SourceLocation location)
        {
            if (modelStatementFound && inheritsStatementFound)
                Context.OnError(location,
                    string.Format(CultureInfo.CurrentCulture,
                        "Cannot have both an @inherits statement and an @model statement."));
        }

    }

}