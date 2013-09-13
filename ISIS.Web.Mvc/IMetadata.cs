using System.Collections.Generic;
using System.Linq;

namespace ISIS.Web.Mvc
{

    /// <summary>
    /// Interface for a dynamic set of metadata.
    /// </summary>
    public interface IMetadata : IQueryable<IMetadataItem>, IDictionary<string, object>
    {



    }

}
