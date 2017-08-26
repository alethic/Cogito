using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Cogito.Collections
{

    /// <summary>
    /// An interval tree that supports duplicate entries.
    /// </summary>
    /// <typeparam name="TInterval">The interval type</typeparam>
    /// <typeparam name="TPoint">The interval's start and end type</typeparam>
    /// <remarks>
    /// This interval tree is implemented as a balanced augmented AVL tree. Modifications are O(log n) typical case. Searches are O(log n) typical case.
    /// </remarks>
    [Serializable]
    public class IntervalTree<TInterval, TPoint> :
        ICollection<TInterval>,
        ICollection,
        ISerializable,
        IXmlSerializable
        where TInterval : IInterval<TPoint>
        where TPoint : IComparable<TPoint>
    {

        readonly object syncRoot;
        IntervalNode root;
        ulong modifications;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public IntervalTree()
        {
            syncRoot = new object();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="intervals"></param>
        public IntervalTree(IEnumerable<TInterval> intervals)
            : this()
        {
            if (intervals == null)
                throw new ArgumentNullException(nameof(intervals));

            AddRange(intervals);
        }

        /// <summary>
        /// Returns the maximum end point in the entire collection.
        /// </summary>
        public TPoint MaxEndPoint
        {
            get
            {
                if (root == null)
                    throw new InvalidOperationException("Cannot determine max end point for emtpy interval tree");

                return root.MaxEndPoint;
            }
        }

        #region ISerializable

        public IntervalTree(SerializationInfo info, StreamingContext context)
            : this()
        {
            var intervals = (TInterval[])info.GetValue("intervals", typeof(TInterval[]));
            AddRange(intervals);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            var intervals = new TInterval[Count];
            CopyTo(intervals, 0);
            info.AddValue("intervals", intervals, typeof(TInterval[]));
        }

        #endregion

        #region IXmlSerializable

        /// <summary>
        /// Serializes the instance to XML.
        /// </summary>
        /// <param name="writer"></param>
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Intervals");
            writer.WriteAttributeString("Count", Count.ToString(CultureInfo.InvariantCulture));
            var itemSerializer = new XmlSerializer(typeof(TInterval));
            foreach (var item in this)
            {
                itemSerializer.Serialize(writer, item);
            }
            writer.WriteEndElement();
        }

        /// <summary>
        /// Deserializes the instance fromXML.
        /// </summary>
        /// <param name="reader"></param>
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            reader.ReadStartElement();

            reader.MoveToAttribute("Count");
            int count = int.Parse(reader.Value);
            reader.MoveToElement();

            if (count > 0 && reader.IsEmptyElement)
                throw new FormatException("Missing tree items");
            if (count == 0 && !reader.IsEmptyElement)
                throw new FormatException("Unexpected content in tree item Xml (expected empty content)");

            reader.ReadStartElement("Intervals");

            var items = new TInterval[count];

            if (count > 0)
            {
                var itemSerializer = new XmlSerializer(typeof(TInterval));

                for (int i = 0; i < count; i++)
                    items[i] = (TInterval)itemSerializer.Deserialize(reader);

                reader.ReadEndElement(); // </intervals>
            }

            AddRange(items);
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        #endregion

        #region IEnumerable, IEnumerable<T>

        /// <summary>
        /// Gets an enumerable for this collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TInterval> GetEnumerator()
        {
            return new IntervalTreeEnumerator(this);
        }

        /// <summary>
        /// Gets an enumerable for this collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new IntervalTreeEnumerator(this);
        }

        #endregion

        #region ICollection

        public bool IsSynchronized { get { return false; } }

        public object SyncRoot { get { return syncRoot; } }

        /// <summary>
        /// Copies the items in this tree to the given array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(Array array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex");

            PerformCopy(arrayIndex, array.Length, (i, v) => array.SetValue(v, i));
        }

        #endregion

        #region ICollection<T>

        /// <summary>
        /// Gets or sets the count of the collection.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Returns <c>true</c> if the collection is read-only.
        /// </summary>
        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Copies the items in the tree to the given array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(TInterval[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("item");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex");

            PerformCopy(arrayIndex, array.Length, (i, v) => array[i] = v);
        }

        /// <summary>
        /// Returns <c>true</c> if the given <paramref name="item"/> is within the tree.
        /// </summary>
        /// <param name="item">The item to check</param>
        public bool Contains(TInterval item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException("item");

            return FindMatchingNodes(item).Any();
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public void Clear()
        {
            SetRoot(null);
            Count = 0;
            modifications++;
        }

        /// <summary>
        /// Adds the given item to the collection.
        /// </summary>
        /// <param name="item"></param>
        public void Add(TInterval item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException("item");

            var newNode = new IntervalNode(item);

            if (root == null)
            {
                SetRoot(newNode);
                Count = 1;
                modifications++;
                return;
            }

            IntervalNode node = root;
            while (true)
            {
                var startCmp = newNode.Start.CompareTo(node.Start);
                if (startCmp <= 0)
                {
                    if (startCmp == 0 && ReferenceEquals(node.Interval, newNode.Interval))
                        throw new InvalidOperationException("Cannot add the same item twice (object reference already exists in db)");

                    if (node.Left == null)
                    {
                        node.Left = newNode;
                        break;
                    }
                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = newNode;
                        break;
                    }
                    node = node.Right;
                }
            }

            modifications++;
            Count++;

            // Restructure tree to be balanced
            node = newNode;
            while (node != null)
            {
                node.UpdateHeight();
                node.UpdateMaxEndPoint();
                Rebalance(node);
                node = node.Parent;
            }
        }

        /// <summary>
        /// Removes an item from the collection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(TInterval item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException("item");

            if (root == null)
                return false;

            var candidates = FindMatchingNodes(item).ToList();
            if (candidates.Count == 0)
                return false;

            // node to be removed
            var toBeRemoved = candidates.Count == 1 ? candidates[0] : candidates.SingleOrDefault(x => ReferenceEquals(x.Interval, item)) ?? candidates[0];

            var parent = toBeRemoved.Parent;
            var isLeftChild = toBeRemoved.IsLeftChild;

            if (toBeRemoved.Left == null && toBeRemoved.Right == null)
            {
                if (parent != null)
                {
                    if (isLeftChild)
                        parent.Left = null;
                    else
                        parent.Right = null;

                    Rebalance(parent);
                }
                else
                {
                    SetRoot(null);
                }
            }
            else if (toBeRemoved.Right == null)
            {
                if (parent != null)
                {
                    if (isLeftChild)
                        parent.Left = toBeRemoved.Left;
                    else
                        parent.Right = toBeRemoved.Left;

                    Rebalance(parent);
                }
                else
                {
                    SetRoot(toBeRemoved.Left);
                }
            }
            else if (toBeRemoved.Left == null)
            {
                if (parent != null)
                {
                    if (isLeftChild)
                        parent.Left = toBeRemoved.Right;
                    else
                        parent.Right = toBeRemoved.Right;

                    Rebalance(parent);
                }
                else
                {
                    SetRoot(toBeRemoved.Right);
                }
            }
            else
            {
                IntervalNode replacement, replacementParent, temp;

                if (toBeRemoved.Balance > 0)
                {
                    if (toBeRemoved.Left.Right == null)
                    {
                        replacement = toBeRemoved.Left;
                        replacement.Right = toBeRemoved.Right;
                        temp = replacement;
                    }
                    else
                    {
                        replacement = toBeRemoved.Left.Right;
                        while (replacement.Right != null)
                        {
                            replacement = replacement.Right;
                        }
                        replacementParent = replacement.Parent;
                        replacementParent.Right = replacement.Left;

                        temp = replacementParent;

                        replacement.Left = toBeRemoved.Left;
                        replacement.Right = toBeRemoved.Right;
                    }
                }
                else
                {
                    if (toBeRemoved.Right.Left == null)
                    {
                        replacement = toBeRemoved.Right;
                        replacement.Left = toBeRemoved.Left;
                        temp = replacement;
                    }
                    else
                    {
                        replacement = toBeRemoved.Right.Left;
                        while (replacement.Left != null)
                        {
                            replacement = replacement.Left;
                        }
                        replacementParent = replacement.Parent;
                        replacementParent.Left = replacement.Right;

                        temp = replacementParent;

                        replacement.Left = toBeRemoved.Left;
                        replacement.Right = toBeRemoved.Right;
                    }
                }

                if (parent != null)
                {
                    if (isLeftChild)
                        parent.Left = replacement;
                    else
                        parent.Right = replacement;
                }
                else
                {
                    SetRoot(replacement);
                }

                Rebalance(temp);
            }

            toBeRemoved.Parent = null;
            Count--;
            modifications++;
            return true;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds each of the specified items to the tree.
        /// </summary>
        /// <param name="intervals"></param>
        public void AddRange(IEnumerable<TInterval> intervals)
        {
            if (intervals == null)
                throw new ArgumentNullException("intervals");

            foreach (var interval in intervals)
                Add(interval);

        }

        /// <summary>
        /// Gets the set of intervals at the given <see cref="TPoint"/>.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public TInterval[] this[TPoint point]
        {
            get { return FindAt(point); }
        }

        /// <summary>
        /// Gets the set of intervals at the given <see cref="TPoint"/>.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public TInterval[] FindAt(TPoint point)
        {
            if (ReferenceEquals(point, null))
                throw new ArgumentNullException("point");

            var found = new List<IntervalNode>();
            PerformStabbingQuery(root, point, found);
            return found.Select(node => node.Interval).ToArray();
        }

        /// <summary>
        /// Returns <c>true</c> if an interval exists at the specified point.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool ContainsPoint(TPoint point)
        {
            return FindAt(point).Any();
        }

        /// <summary>
        /// Returns <c>true</c> if intervals exist between the given interval.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool ContainsOverlappingInterval(IInterval<TPoint> item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException("item");

            return PerformStabbingQuery(root, item).Count > 0;
        }

        /// <summary>
        /// Returns the set of intervals that overlap with the given interval.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public TInterval[] FindOverlapping(IInterval<TPoint> item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException("item");

            return PerformStabbingQuery(root, item).Select(node => node.Interval).ToArray();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Performs a copy action using the specified delegate to set the value.
        /// </summary>
        /// <param name="arrayIndex"></param>
        /// <param name="arrayLength"></param>
        /// <param name="setAtIndexDelegate"></param>
        void PerformCopy(int arrayIndex, int arrayLength, Action<int, TInterval> setAtIndexDelegate)
        {
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex");

            int i = arrayIndex;
            var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (i >= arrayLength)
                    throw new ArgumentOutOfRangeException("arrayIndex", "Not enough elements in array to copy content into");

                setAtIndexDelegate(i, enumerator.Current);
                i++;
            }
        }

        /// <summary>
        /// Finds matching <see cref="IntervalNode"/>s.
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        IEnumerable<IntervalNode> FindMatchingNodes(IInterval<TPoint> interval)
        {
            return PerformStabbingQuery(root, interval).Where(node => node.Interval.Equals(interval));
        }

        /// <summary>
        /// Sets the root of the interval tree.
        /// </summary>
        /// <param name="node"></param>
        void SetRoot(IntervalNode node)
        {
            root = node;
            if (root != null)
                root.Parent = null;
        }

        /// <summary>
        /// Returns <c>true</c> if the given interval contains the given point.
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        bool DoesIntervalContain(IntervalNode interval, TPoint point)
        {
            return point.CompareTo(interval.Start) >= 0 && point.CompareTo(interval.End) <= 0;
        }

        /// <summary>
        /// Returns <c>true</c> if the given interval overlaps with the other interval.
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        bool DoIntervalsOverlap(IntervalNode interval, IInterval<TPoint> other)
        {
            return interval.Start.CompareTo(other.End) <= 0 && interval.End.CompareTo(other.Start) >= 0;
        }

        void PerformStabbingQuery(IntervalNode node, TPoint point, List<IntervalNode> result)
        {
            if (node == null)
                return;

            if (point.CompareTo(node.MaxEndPoint) > 0)
                return;

            if (node.Left != null)
                PerformStabbingQuery(node.Left, point, result);

            if (DoesIntervalContain(node, point))
                result.Add(node);

            if (point.CompareTo(node.Start) < 0)
                return;

            if (node.Right != null)
                PerformStabbingQuery(node.Right, point, result);
        }

        List<IntervalNode> PerformStabbingQuery(IntervalNode node, IInterval<TPoint> interval)
        {
            var result = new List<IntervalNode>();
            PerformStabbingQuery(node, interval, result);
            return result;
        }

        void PerformStabbingQuery(IntervalNode node, IInterval<TPoint> interval, List<IntervalNode> result)
        {
            if (node == null)
                return;

            if (interval.Start.CompareTo(node.MaxEndPoint) > 0)
                return;

            if (node.Left != null)
                PerformStabbingQuery(node.Left, interval, result);

            if (DoIntervalsOverlap(node, interval))
                result.Add(node);

            if (interval.End.CompareTo(node.Start) < 0)
                return;

            if (node.Right != null)
                PerformStabbingQuery(node.Right, interval, result);
        }

        void Rebalance(IntervalNode node)
        {
            if (node.Balance > 1)
            {
                if (node.Left.Balance < 0)
                    RotateLeft(node.Left);
                RotateRight(node);
            }
            else if (node.Balance < -1)
            {
                if (node.Right.Balance > 0)
                    RotateRight(node.Right);
                RotateLeft(node);
            }
        }

        void RotateLeft(IntervalNode node)
        {
            var parent = node.Parent;
            var isNodeLeftChild = node.IsLeftChild;

            // Make node.Right the new root of this sub tree (instead of node)
            var pivotNode = node.Right;
            node.Right = pivotNode.Left;
            pivotNode.Left = node;

            if (parent != null)
            {
                if (isNodeLeftChild)
                    parent.Left = pivotNode;
                else
                    parent.Right = pivotNode;
            }
            else
            {
                SetRoot(pivotNode);
            }
        }

        void RotateRight(IntervalNode node)
        {
            var parent = node.Parent;
            var isNodeLeftChild = node.IsLeftChild;

            // Make node.Left the new root of this sub tree (instead of node)
            var pivotNode = node.Left;
            node.Left = pivotNode.Right;
            pivotNode.Right = node;

            if (parent != null)
            {
                if (isNodeLeftChild)
                    parent.Left = pivotNode;
                else
                    parent.Right = pivotNode;
            }
            else
            {
                SetRoot(pivotNode);
            }
        }

        #endregion

        #region Inner classes

        [Serializable]
        class IntervalNode
        {

            IntervalNode left;
            IntervalNode right;

            public IntervalNode Parent { get; set; }

            /// <summary>
            /// Gets the starting point.
            /// </summary>
            public TPoint Start { get; private set; }

            /// <summary>
            /// Gets the ending point.
            /// </summary>
            public TPoint End { get; private set; }

            /// <summary>
            /// Gets the interval represented by this node.
            /// </summary>
            public TInterval Interval { get; private set; }

            int Height { get; set; }

            public TPoint MaxEndPoint { get; private set; }

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="interval"></param>
            /// <param name="start"></param>
            /// <param name="end"></param>
            public IntervalNode(TInterval interval)
            {
                Contract.Requires<ArgumentOutOfRangeException>(interval.Start.CompareTo(interval.End) <= 0, "The supplied interval has an invalid range, where start is greater than end");

                Interval = interval;

                // copy start and end off interval value
                Start = interval.Start;
                End = interval.End;

                UpdateMaxEndPoint();
            }

            /// <summary>
            /// Gets the node on the left.
            /// </summary>
            public IntervalNode Left
            {
                get
                {
                    return left;
                }
                set
                {
                    left = value;
                    if (left != null)
                        left.Parent = this;
                    UpdateHeight();
                    UpdateMaxEndPoint();
                }
            }

            /// <summary>
            /// Gets the node on the right.
            /// </summary>
            public IntervalNode Right
            {
                get
                {
                    return right;
                }
                set
                {
                    right = value;
                    if (right != null)
                        right.Parent = this;
                    UpdateHeight();
                    UpdateMaxEndPoint();
                }
            }

            /// <summary>
            /// Returns the balance of the node.
            /// </summary>
            public int Balance
            {
                get
                {
                    if (Left != null && Right != null)
                        return Left.Height - Right.Height;
                    if (Left != null)
                        return Left.Height + 1;
                    if (Right != null)
                        return -(Right.Height + 1);
                    return 0;
                }
            }

            public bool IsLeftChild
            {
                get { return Parent != null && Parent.Left == this; }
            }

            public void UpdateHeight()
            {
                if (Left != null && Right != null)
                    Height = System.Math.Max(Left.Height, Right.Height) + 1;
                else if (Left != null)
                    Height = Left.Height + 1;
                else if (Right != null)
                    Height = Right.Height + 1;
                else
                    Height = 0;
            }

            /// <summary>
            /// Returns the maximum value.
            /// </summary>
            /// <param name="value1"></param>
            /// <param name="value2"></param>
            /// <returns></returns>
            static TPoint Max(TPoint value1, TPoint value2)
            {
                return value1.CompareTo(value2) > 0 ? value1 : value2;
            }

            public void UpdateMaxEndPoint()
            {
                var max = End;
                if (Left != null)
                    max = Max(max, Left.MaxEndPoint);
                if (Right != null)
                    max = Max(max, Right.MaxEndPoint);
                MaxEndPoint = max;
            }

            /// <summary>
            /// Returns a string version of the instance.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Format("[{0},{1}], MaxEnd={2}", Start, End, MaxEndPoint);
            }

        }

        /// <summary>
        /// Provides an enumerator over a <see cref="IntervalTree{TInterval, TPoint}"/>.
        /// </summary>
        class IntervalTreeEnumerator :
           IEnumerator<TInterval>
        {

            readonly ulong modificationsAtCreation;
            readonly IntervalTree<TInterval, TPoint> tree;
            readonly IntervalNode startNode;
            IntervalNode current;
            bool hasVisitedCurrent;
            bool hasVisitedRight;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="tree"></param>
            public IntervalTreeEnumerator(IntervalTree<TInterval, TPoint> tree)
            {
                if (tree == null)
                    throw new ArgumentNullException(nameof(tree));

                this.tree = tree;
                modificationsAtCreation = tree.modifications;
                startNode = GetLeftMostDescendantOrSelf(tree.root);
                Reset();
            }

            /// <summary>
            /// Gets the current value.
            /// </summary>
            public TInterval Current
            {
                get
                {
                    if (current == null)
                        throw new InvalidOperationException("Enumeration has finished.");

                    if (ReferenceEquals(current, startNode) && !hasVisitedCurrent)
                        throw new InvalidOperationException("Enumeration has not started.");

                    return current.Interval;
                }
            }

            /// <summary>
            /// Gets the current value.
            /// </summary>
            object IEnumerator.Current
            {
                get { return Current; }
            }

            /// <summary>
            /// Resets the enumerator.
            /// </summary>
            public void Reset()
            {
                if (modificationsAtCreation != tree.modifications)
                    throw new InvalidOperationException("Collection was modified.");

                current = startNode;
                hasVisitedCurrent = false;
                hasVisitedRight = false;
            }

            /// <summary>
            /// Moves to the next item in the tree.
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                if (modificationsAtCreation != tree.modifications)
                    throw new InvalidOperationException("Collection was modified.");

                if (tree.root == null)
                    return false;

                // Visit this node
                if (!hasVisitedCurrent)
                {
                    hasVisitedCurrent = true;
                    return true;
                }

                // Go right, visit the right's left most descendant (or the right node itself)
                if (!hasVisitedRight && current.Right != null)
                {
                    current = current.Right;
                    MoveToLeftMostDescendant();
                    hasVisitedCurrent = true;
                    hasVisitedRight = false;
                    return true;
                }

                // Move upward
                do
                {
                    var wasVisitingFromLeft = current.IsLeftChild;
                    current = current.Parent;
                    if (wasVisitingFromLeft)
                    {
                        hasVisitedCurrent = false;
                        hasVisitedRight = false;
                        return MoveNext();
                    }
                } while (current != null);

                return false;
            }

            void MoveToLeftMostDescendant()
            {
                current = GetLeftMostDescendantOrSelf(current);
            }

            IntervalNode GetLeftMostDescendantOrSelf(IntervalNode node)
            {
                if (node == null)
                    return null;

                while (node.Left != null)
                    node = node.Left;

                return node;
            }

            /// <summary>
            /// Disposes of the instance.
            /// </summary>
            public void Dispose()
            {

            }

        }

        #endregion

    }

    /// <summary>
    /// An interval tree that supports duplicate entries.
    /// </summary>
    /// <typeparam name="TPoint"></typeparam>
    [Serializable]
    public class IntervalTree<TPoint> :
        IntervalTree<IInterval<TPoint>, TPoint>
        where TPoint : IComparable<TPoint>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public IntervalTree()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="intervals"></param>
        public IntervalTree(IEnumerable<IInterval<TPoint>> intervals)
            : base(intervals)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public IntervalTree(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        /// <summary>
        /// Adds the given interval range into the collection.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void Add(TPoint start, TPoint end)
        {
            Add(Interval.Create(start, end));
        }

        /// <summary>
        /// Returns <c>true</c> if intervals exist between the given points.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool ContainsOverlappingInterval(TPoint start, TPoint end)
        {
            return ContainsOverlappingInterval(Interval.Create(start, end));
        }

        /// <summary>
        /// Returns the set of intervals that overlap with the given interval.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IInterval<TPoint>[] FindOverlapping(TPoint start, TPoint end)
        {
            return FindOverlapping(Interval.Create(start, end));
        }

    }

}