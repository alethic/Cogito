using System;
using System.Collections.Generic;

namespace Cogito.Collections
{

    /// <summary>
    /// Provides an implementation of <see cref="IEqualityComparer"/> which refers to delegates for it's operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateEqualityComparer<T> : EqualityComparer<T>
    {

        Func<T, T, bool> equals;
        Func<T, int> getHashCode;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="equals"></param>
        /// <param name="getHashCode"></param>
        public DelegateEqualityComparer(Func<T, T, bool> equals)
        {
            this.equals = equals;
            this.getHashCode = x => x.GetHashCode();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="equals"></param>
        /// <param name="getHashCode"></param>
        public DelegateEqualityComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
        {
            this.equals = equals;
            this.getHashCode = getHashCode;
        }

        public override bool Equals(T x, T y)
        {
            return equals(x, y);
        }

        public override int GetHashCode(T obj)
        {
            return getHashCode(obj);
        }

    }

}
