using System;
using System.Web.Razor;
using System.Web.Razor.Parser;

namespace Cogito.Nancy.Razor
 {

     /// <summary>
     /// A custom razor engine host responsible for decorating the existing code generators with nancy versions.
     /// </summary>
     public class NancyRazorEngineHost : 
         RazorEngineHost
     {

         /// <summary>
         /// Initializes a new instance of the <see cref="NancyRazorEngineHost"/> class.
         /// </summary>
         /// <param name="language">The language.</param>
         public NancyRazorEngineHost(
             RazorCodeLanguage language)
             : base(language)
         {

         }

         /// <summary>
         /// Decorates the code parser.
         /// </summary>
         /// <param name="incomingCodeParser">The incoming code parser.</param>
         /// <returns></returns>
         public override ParserBase DecorateCodeParser(ParserBase incomingCodeParser)
         {
             if (incomingCodeParser is CSharpCodeParser)
                 return new NancyCSharpRazorCodeParser();

             if (incomingCodeParser is VBCodeParser)
                 throw new NotSupportedException();

             return base.DecorateCodeParser(incomingCodeParser);
         }

     }

 }
