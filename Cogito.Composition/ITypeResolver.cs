using System;
using System.Collections.Generic;

namespace Cogito.Composition
{

    public interface ITypeResolver
    {

        T Resolve<T>();

        Lazy<T, IDictionary<string, object>> ResolveLazy<T>();

        IEnumerable<T> ResolveMany<T>();

        IEnumerable<Lazy<T,IDictionary<string,object>>> ResolveManyLazy<T>();

        object Resolve(Type type);

        Lazy<object, IDictionary<string, object>> ResolveLazy(Type type);

        IEnumerable<object> ResolveMany(Type type);

        IEnumerable<Lazy<object, IDictionary<string, object>>> ResolveManyLazy(Type type);

    }

}
