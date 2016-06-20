using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Cogito.Collections
{

    /// <summary>
    /// Provides an implementation of <see cref="IEqualityComparer{T}"/> which refers to delegates for it's operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateEqualityComparer<T> :
        EqualityComparer<T>
    {

        readonly Func<T, T, bool> equals;
        readonly Func<T, int> getHashCode;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="equals"></param>
        public DelegateEqualityComparer(Func<T, T, bool> equals)
        {
            Contract.Requires<ArgumentNullException>(equals != null);

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
            Contract.Requires<ArgumentNullException>(equals != null);
            Contract.Requires<ArgumentNullException>(getHashCode != null);

            this.equals = equals;
            this.getHashCode = getHashCode;
        }

        /// <summary>
        /// Returns <c>true</c> if both items are equal.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override bool Equals(T x, T y)
        {
            return equals(x, y);
        }

        /// <summary>
        /// Gets the hashcode for the given item.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int GetHashCode(T obj)
        {
            return getHashCode(obj);
        }

    }

}
