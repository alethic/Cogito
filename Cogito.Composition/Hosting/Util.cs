using System.Diagnostics;

namespace Cogito.Composition.Hosting
{

    static class Util
    {

        public static readonly TraceSource Trace = new TraceSource(typeof(Util).Namespace);

    }

}
