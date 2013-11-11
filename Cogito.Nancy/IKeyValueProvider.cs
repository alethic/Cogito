using System.Collections.Generic;
using System.ComponentModel.Composition;

using Nancy;

namespace Cogito.Nancy
{

    /// <summary>
    /// Provides KeyValuePairs to be applied to a model.
    /// </summary>
    [InheritedExport]
    public interface IKeyValueProvider
    {

        /// <summary>
        /// Gets a sequence of key-value pairs provided for binding.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, object>> GetKeyValuePairs(NancyContext context);

    }

}
