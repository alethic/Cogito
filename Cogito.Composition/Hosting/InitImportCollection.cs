using System.Collections.Generic;
using System.ComponentModel.Composition;

using Cogito.Composition.Services;

namespace Cogito.Composition
{

    /// <summary>
    /// Provides a collection of exports with various notifications to signal recomposition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Export(typeof(InitImportCollection))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InitImportCollection :
        DynamicImportCollection<IOnInitInvoke, IDictionary<string, object>>
    {

        [ImportingConstructor]
        public InitImportCollection()
            : base()
        {

        }

    }

}
