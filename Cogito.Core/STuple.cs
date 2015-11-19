using System;
using System.Collections;

namespace Cogito
{

    public static class STuple
    {

        //
        // Summary:
        //     Creates a new 2-tuple, or pair.
        //
        // Parameters:
        //   item1:
        //     The value of the first component of the tuple.
        //
        //   item2:
        //     The value of the second component of the tuple.
        //
        // Type parameters:
        //   T1:
        //     The type of the first component of the tuple.
        //
        //   T2:
        //     The type of the second component of the tuple.
        //
        // Returns:
        //     A 2-tuple whose value is (item1, item2).
        public static STuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {
            return new STuple<T1, T2>(item1, item2);
        }

    }

    public struct STuple<T1, T2> :
        IStructuralEquatable, IStructuralComparable, IComparable
    {

        readonly T1 item1;
        readonly T2 item2;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public STuple(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public T1 Item1
        {
            get { return item1; }
        }

        public T2 Item2
        {
            get { return item2; }
        }

        public override bool Equals(object obj)
        {
            var t = (STuple<T1, T2>)obj;

            return
                object.Equals(item1, t.item1) &&
                object.Equals(item2, t.item2);
        }

        public override int GetHashCode()
        {
            return
                item1.GetHashCode() ^
                item2.GetHashCode();
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            var t = (STuple<T1, T2>)other;

            return 
                comparer.Equals(item1, t.item1) &&
                comparer.Equals(item2, t.item2);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return
                comparer.GetHashCode(item1) ^
                comparer.GetHashCode(item2);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            return -1;
        }

        int IComparable.CompareTo(object obj)
        {
            return -1;
        }

    }

}
