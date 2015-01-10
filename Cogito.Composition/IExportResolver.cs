using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;

namespace Cogito.Composition
{

    public interface IExportResolver
    {

        Export Resolve(Type type);

        IEnumerable<Export> ResolveMany(Type type);

    }

}
