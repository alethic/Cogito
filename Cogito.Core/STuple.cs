using System;
using System.Collections;
using System.Collections.Generic;

namespace Cogito
{

    public static class STuple
    {

        /// <summary>
        /// Creates a new 1-tuple.
        /// </summary>
        public static STuple<T1> Create<T1>(T1 item1)
        {
            return new STuple<T1>(item1);
        }

        /// <summary>
        /// Creates a new 2-tuple.
        /// </summary>
        public static STuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {
            return new STuple<T1, T2>(item1, item2);
        }

        /// <summary>
        /// Creates a new 3-tuple.
        /// </summary>
        public static STuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            return new STuple<T1, T2, T3>(item1, item2, item3);
        }

        /// <summary>
        /// Creates a new 4-tuple.
        /// </summary>
        public static STuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            return new STuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        }

        /// <summary>
        /// Creates a new 5-tuple.
        /// </summary>
        public static STuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            return new STuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        }

        /// <summary>
        /// Creates a new 6-tuple.
        /// </summary>
        public static STuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            return new STuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        }

        /// <summary>
        /// Creates a new 7-tuple.
        /// </summary>
        public static STuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            return new STuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        }

        /// <summary>
        /// Creates a new 8-tuple.
        /// </summary>
        public static STuple<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
        {
            return new STuple<T1, T2, T3, T4, T5, T6, T7, T8>(item1, item2, item3, item4, item5, item6, item7, item8);
        }

        internal static int CombineHashCodes(int h1, int h2)
        {
            return (((h1 << 5) + h1) ^ h2);
        }
 
        internal static int CombineHashCodes(int h1, int h2, int h3)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2), h3);
        }
 
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2), CombineHashCodes(h3, h4));
        }
 
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), h5);
        }
 
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6));
        }
 
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7));
        }
 
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7, h8));
        }

    }

    [Serializable]
    public struct STuple<T1> :
        IStructuralEquatable, IStructuralComparable, IComparable
    {

        readonly T1 item1;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="item1"></param>
        public STuple(T1 item1)
        {
            this.item1 = item1;
        }

        public T1 Item1
        {
            get { return item1; }
        }

        /// <summary>
        /// Gets the size of the tuple.
        /// </summary>
        public int Size
        {
            get { return 1; }
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return false;

            var t = (STuple<T1>)other;
            return comparer.Equals(item1, t.item1);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return comparer.GetHashCode(item1);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return 1;
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException("comparer");

            var t = (STuple<T1>)other;
            int c = 0;

            if ((c = comparer.Compare(item1, t.item1)) != 0)
                return c;

            return 0;
        }

        public override string ToString()
        {
            return $"({item1})";
        }

    }

    [Serializable]
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

        /// <summary>
        /// Gets the size of the tuple.
        /// </summary>
        public int Size
        {
            get { return 2; }
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return false;

            var t = (STuple<T1, T2>)other;
            return comparer.Equals(item1, t.item1) && comparer.Equals(item2, t.item2);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return STuple.CombineHashCodes(comparer.GetHashCode(item1), comparer.GetHashCode(item2));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return 1;
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException("comparer");

            var t = (STuple<T1, T2>)other;
            int c = 0;

            if ((c = comparer.Compare(item1, t.item1)) != 0)
                return c;

            if ((c = comparer.Compare(item2, t.item2)) != 0)
                return c;

            return 0;
        }

        public override string ToString()
        {
            return $"({item1}, {item2})";
        }

    }

    [Serializable]
    public struct STuple<T1, T2, T3> :
        IStructuralEquatable, IStructuralComparable, IComparable
    {

        readonly T1 item1;
        readonly T2 item2;
        readonly T3 item3;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public STuple(T1 item1, T2 item2, T3 item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public T1 Item1
        {
            get { return item1; }
        }
        public T2 Item2
        {
            get { return item2; }
        }
        public T3 Item3
        {
            get { return item3; }
        }

        /// <summary>
        /// Gets the size of the tuple.
        /// </summary>
        public int Size
        {
            get { return 3; }
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return false;

            var t = (STuple<T1, T2, T3>)other;
            return comparer.Equals(item1, t.item1) && comparer.Equals(item2, t.item2) && comparer.Equals(item3, t.item3);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return STuple.CombineHashCodes(comparer.GetHashCode(item1), comparer.GetHashCode(item2), comparer.GetHashCode(item3));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return 1;
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException("comparer");

            var t = (STuple<T1, T2, T3>)other;
            int c = 0;

            if ((c = comparer.Compare(item1, t.item1)) != 0)
                return c;

            if ((c = comparer.Compare(item2, t.item2)) != 0)
                return c;

            if ((c = comparer.Compare(item3, t.item3)) != 0)
                return c;

            return 0;
        }

        public override string ToString()
        {
            return $"({item1}, {item2}, {item3})";
        }

    }

    [Serializable]
    public struct STuple<T1, T2, T3, T4> :
        IStructuralEquatable, IStructuralComparable, IComparable
    {

        readonly T1 item1;
        readonly T2 item2;
        readonly T3 item3;
        readonly T4 item4;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public STuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
        }

        public T1 Item1
        {
            get { return item1; }
        }
        public T2 Item2
        {
            get { return item2; }
        }
        public T3 Item3
        {
            get { return item3; }
        }
        public T4 Item4
        {
            get { return item4; }
        }

        /// <summary>
        /// Gets the size of the tuple.
        /// </summary>
        public int Size
        {
            get { return 4; }
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return false;

            var t = (STuple<T1, T2, T3, T4>)other;
            return comparer.Equals(item1, t.item1) && comparer.Equals(item2, t.item2) && comparer.Equals(item3, t.item3) && comparer.Equals(item4, t.item4);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return STuple.CombineHashCodes(comparer.GetHashCode(item1), comparer.GetHashCode(item2), comparer.GetHashCode(item3), comparer.GetHashCode(item4));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return 1;
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException("comparer");

            var t = (STuple<T1, T2, T3, T4>)other;
            int c = 0;

            if ((c = comparer.Compare(item1, t.item1)) != 0)
                return c;

            if ((c = comparer.Compare(item2, t.item2)) != 0)
                return c;

            if ((c = comparer.Compare(item3, t.item3)) != 0)
                return c;

            if ((c = comparer.Compare(item4, t.item4)) != 0)
                return c;

            return 0;
        }

        public override string ToString()
        {
            return $"({item1}, {item2}, {item3}, {item4})";
        }

    }

    [Serializable]
    public struct STuple<T1, T2, T3, T4, T5> :
        IStructuralEquatable, IStructuralComparable, IComparable
    {

        readonly T1 item1;
        readonly T2 item2;
        readonly T3 item3;
        readonly T4 item4;
        readonly T5 item5;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        public STuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;
        }

        public T1 Item1
        {
            get { return item1; }
        }
        public T2 Item2
        {
            get { return item2; }
        }
        public T3 Item3
        {
            get { return item3; }
        }
        public T4 Item4
        {
            get { return item4; }
        }
        public T5 Item5
        {
            get { return item5; }
        }

        /// <summary>
        /// Gets the size of the tuple.
        /// </summary>
        public int Size
        {
            get { return 5; }
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return false;

            var t = (STuple<T1, T2, T3, T4, T5>)other;
            return comparer.Equals(item1, t.item1) && comparer.Equals(item2, t.item2) && comparer.Equals(item3, t.item3) && comparer.Equals(item4, t.item4) && comparer.Equals(item5, t.item5);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return STuple.CombineHashCodes(comparer.GetHashCode(item1), comparer.GetHashCode(item2), comparer.GetHashCode(item3), comparer.GetHashCode(item4), comparer.GetHashCode(item5));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return 1;
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException("comparer");

            var t = (STuple<T1, T2, T3, T4, T5>)other;
            int c = 0;

            if ((c = comparer.Compare(item1, t.item1)) != 0)
                return c;

            if ((c = comparer.Compare(item2, t.item2)) != 0)
                return c;

            if ((c = comparer.Compare(item3, t.item3)) != 0)
                return c;

            if ((c = comparer.Compare(item4, t.item4)) != 0)
                return c;

            if ((c = comparer.Compare(item5, t.item5)) != 0)
                return c;

            return 0;
        }

        public override string ToString()
        {
            return $"({item1}, {item2}, {item3}, {item4}, {item5})";
        }

    }

    [Serializable]
    public struct STuple<T1, T2, T3, T4, T5, T6> :
        IStructuralEquatable, IStructuralComparable, IComparable
    {

        readonly T1 item1;
        readonly T2 item2;
        readonly T3 item3;
        readonly T4 item4;
        readonly T5 item5;
        readonly T6 item6;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        /// <param name="item6"></param>
        public STuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;
            this.item6 = item6;
        }

        public T1 Item1
        {
            get { return item1; }
        }
        public T2 Item2
        {
            get { return item2; }
        }
        public T3 Item3
        {
            get { return item3; }
        }
        public T4 Item4
        {
            get { return item4; }
        }
        public T5 Item5
        {
            get { return item5; }
        }
        public T6 Item6
        {
            get { return item6; }
        }

        /// <summary>
        /// Gets the size of the tuple.
        /// </summary>
        public int Size
        {
            get { return 6; }
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return false;

            var t = (STuple<T1, T2, T3, T4, T5, T6>)other;
            return comparer.Equals(item1, t.item1) && comparer.Equals(item2, t.item2) && comparer.Equals(item3, t.item3) && comparer.Equals(item4, t.item4) && comparer.Equals(item5, t.item5) && comparer.Equals(item6, t.item6);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return STuple.CombineHashCodes(comparer.GetHashCode(item1), comparer.GetHashCode(item2), comparer.GetHashCode(item3), comparer.GetHashCode(item4), comparer.GetHashCode(item5), comparer.GetHashCode(item6));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return 1;
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException("comparer");

            var t = (STuple<T1, T2, T3, T4, T5, T6>)other;
            int c = 0;

            if ((c = comparer.Compare(item1, t.item1)) != 0)
                return c;

            if ((c = comparer.Compare(item2, t.item2)) != 0)
                return c;

            if ((c = comparer.Compare(item3, t.item3)) != 0)
                return c;

            if ((c = comparer.Compare(item4, t.item4)) != 0)
                return c;

            if ((c = comparer.Compare(item5, t.item5)) != 0)
                return c;

            if ((c = comparer.Compare(item6, t.item6)) != 0)
                return c;

            return 0;
        }

        public override string ToString()
        {
            return $"({item1}, {item2}, {item3}, {item4}, {item5}, {item6})";
        }

    }

    [Serializable]
    public struct STuple<T1, T2, T3, T4, T5, T6, T7> :
        IStructuralEquatable, IStructuralComparable, IComparable
    {

        readonly T1 item1;
        readonly T2 item2;
        readonly T3 item3;
        readonly T4 item4;
        readonly T5 item5;
        readonly T6 item6;
        readonly T7 item7;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        /// <param name="item6"></param>
        /// <param name="item7"></param>
        public STuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;
            this.item6 = item6;
            this.item7 = item7;
        }

        public T1 Item1
        {
            get { return item1; }
        }
        public T2 Item2
        {
            get { return item2; }
        }
        public T3 Item3
        {
            get { return item3; }
        }
        public T4 Item4
        {
            get { return item4; }
        }
        public T5 Item5
        {
            get { return item5; }
        }
        public T6 Item6
        {
            get { return item6; }
        }
        public T7 Item7
        {
            get { return item7; }
        }

        /// <summary>
        /// Gets the size of the tuple.
        /// </summary>
        public int Size
        {
            get { return 7; }
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return false;

            var t = (STuple<T1, T2, T3, T4, T5, T6, T7>)other;
            return comparer.Equals(item1, t.item1) && comparer.Equals(item2, t.item2) && comparer.Equals(item3, t.item3) && comparer.Equals(item4, t.item4) && comparer.Equals(item5, t.item5) && comparer.Equals(item6, t.item6) && comparer.Equals(item7, t.item7);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return STuple.CombineHashCodes(comparer.GetHashCode(item1), comparer.GetHashCode(item2), comparer.GetHashCode(item3), comparer.GetHashCode(item4), comparer.GetHashCode(item5), comparer.GetHashCode(item6), comparer.GetHashCode(item7));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return 1;
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException("comparer");

            var t = (STuple<T1, T2, T3, T4, T5, T6, T7>)other;
            int c = 0;

            if ((c = comparer.Compare(item1, t.item1)) != 0)
                return c;

            if ((c = comparer.Compare(item2, t.item2)) != 0)
                return c;

            if ((c = comparer.Compare(item3, t.item3)) != 0)
                return c;

            if ((c = comparer.Compare(item4, t.item4)) != 0)
                return c;

            if ((c = comparer.Compare(item5, t.item5)) != 0)
                return c;

            if ((c = comparer.Compare(item6, t.item6)) != 0)
                return c;

            if ((c = comparer.Compare(item7, t.item7)) != 0)
                return c;

            return 0;
        }

        public override string ToString()
        {
            return $"({item1}, {item2}, {item3}, {item4}, {item5}, {item6}, {item7})";
        }

    }

    [Serializable]
    public struct STuple<T1, T2, T3, T4, T5, T6, T7, T8> :
        IStructuralEquatable, IStructuralComparable, IComparable
    {

        readonly T1 item1;
        readonly T2 item2;
        readonly T3 item3;
        readonly T4 item4;
        readonly T5 item5;
        readonly T6 item6;
        readonly T7 item7;
        readonly T8 item8;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        /// <param name="item6"></param>
        /// <param name="item7"></param>
        /// <param name="item8"></param>
        public STuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;
            this.item6 = item6;
            this.item7 = item7;
            this.item8 = item8;
        }

        public T1 Item1
        {
            get { return item1; }
        }
        public T2 Item2
        {
            get { return item2; }
        }
        public T3 Item3
        {
            get { return item3; }
        }
        public T4 Item4
        {
            get { return item4; }
        }
        public T5 Item5
        {
            get { return item5; }
        }
        public T6 Item6
        {
            get { return item6; }
        }
        public T7 Item7
        {
            get { return item7; }
        }
        public T8 Item8
        {
            get { return item8; }
        }

        /// <summary>
        /// Gets the size of the tuple.
        /// </summary>
        public int Size
        {
            get { return 8; }
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<Object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return false;

            var t = (STuple<T1, T2, T3, T4, T5, T6, T7, T8>)other;
            return comparer.Equals(item1, t.item1) && comparer.Equals(item2, t.item2) && comparer.Equals(item3, t.item3) && comparer.Equals(item4, t.item4) && comparer.Equals(item5, t.item5) && comparer.Equals(item6, t.item6) && comparer.Equals(item7, t.item7) && comparer.Equals(item8, t.item8);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<Object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return STuple.CombineHashCodes(comparer.GetHashCode(item1), comparer.GetHashCode(item2), comparer.GetHashCode(item3), comparer.GetHashCode(item4), comparer.GetHashCode(item5), comparer.GetHashCode(item6), comparer.GetHashCode(item7), comparer.GetHashCode(item8));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<Object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (ReferenceEquals(other, null))
                return 1;
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException("comparer");

            var t = (STuple<T1, T2, T3, T4, T5, T6, T7, T8>)other;
            int c = 0;

            if ((c = comparer.Compare(item1, t.item1)) != 0)
                return c;

            if ((c = comparer.Compare(item2, t.item2)) != 0)
                return c;

            if ((c = comparer.Compare(item3, t.item3)) != 0)
                return c;

            if ((c = comparer.Compare(item4, t.item4)) != 0)
                return c;

            if ((c = comparer.Compare(item5, t.item5)) != 0)
                return c;

            if ((c = comparer.Compare(item6, t.item6)) != 0)
                return c;

            if ((c = comparer.Compare(item7, t.item7)) != 0)
                return c;

            if ((c = comparer.Compare(item8, t.item8)) != 0)
                return c;

            return 0;
        }

        public override string ToString()
        {
            return $"({item1}, {item2}, {item3}, {item4}, {item5}, {item6}, {item7}, {item8})";
        }

    }


}

