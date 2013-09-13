using System.Collections.Generic;
using System.Linq;

namespace Cogito.Composition.Metadata
{

    /// <summary>
    /// Interface for a dynamic queryable metadata.
    /// </summary>
    public interface IMetadata : IQueryable<IMetadataItem>, IDictionary<string, object>
    {



    }

}
