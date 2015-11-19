using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Cogito.Composition.Hosting;

namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Local-scope manager available to every scope.
    /// </summary>
    [PartMetadata(CompositionConstants.ScopeMetadataKey, typeof(IEveryScope))]
    [Export(typeof(ScopeManager))]
    [ExportMetadata(CompositionConstants.VisibilityMetadataKey, Visibility.Local)]
    public class ScopeManager
    {



    }

}
