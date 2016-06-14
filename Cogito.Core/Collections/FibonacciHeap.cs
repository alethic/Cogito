using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using Cogito.Linq;

namespace Cogito.Collections
{

    [DebuggerDisplay("Count = {Count}")]
    public sealed class FibonacciHeap<TPriority, TValue> :
        IEnumerable<KeyValuePair<TPriority, TValue>>
    {

        struct NodeLevel
        {

            public readonly FibonacciHeapCell<TPriority, TValue> node;
            public readonly int level;

            public NodeLevel(FibonacciHeapCell<TPriority, TValue> node, int level)
            {
                this.node = node;
                this.level = level;
            }

        }

        readonly Func<TPriority, TPriority, int> priorityComparsion;
        readonly HeapDirection direction;

        FibonacciHeapLinkedList<TPriority, TValue> nodes;
        FibonacciHeapCell<TPriority, TValue> next;
        Dictionary<int, FibonacciHeapCell<TPriority, TValue>> degreeToNode;
        short directionMultiplier;
        int count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FibonacciHeap()
            : this(HeapDirection.Increasing, Comparer<TPriority>.Default.Compare)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="direction"></param>
        public FibonacciHeap(HeapDirection direction)
            : this(direction, Comparer<TPriority>.Default.Compare)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="priorityComparison"></param>
        public FibonacciHeap(HeapDirection direction, Func<TPriority, TPriority, int> priorityComparison)
        {
            nodes = new FibonacciHeapLinkedList<TPriority, TValue>();
            degreeToNode = new Dictionary<int, FibonacciHeapCell<TPriority, TValue>>();
            directionMultiplier = (short)(direction == HeapDirection.Increasing ? 1 : -1);
            this.direction = direction;
            this.priorityComparsion = priorityComparison;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public HeapDirection Direction
        {
            get { return direction; }
        }

        public Func<TPriority, TPriority, int> PriorityComparison
        {
            get { return this.priorityComparsion; }
        }

        public string DrawHeap()
        {
            var lines = new List<string>();
            var lineNum = 0;
            var columnPosition = 0;
            var list = new List<NodeLevel>();
            foreach (var node in nodes) list.Add(new NodeLevel(node, 0));
            list.Reverse();
            var stack = new Stack<NodeLevel>(list);
            while (stack.Count > 0)
            {
                var currentcell = stack.Pop();
                lineNum = currentcell.level;
                if (lines.Count <= lineNum)
                    lines.Add(String.Empty);
                var currentLine = lines[lineNum];
                currentLine = currentLine.PadRight(columnPosition, ' ');
                var nodeString = currentcell.node.Priority.ToString() + (currentcell.node.Marked ? "*" : "") + " ";
                currentLine += nodeString;
                if (currentcell.node.Children != null && currentcell.node.Children.First != null)
                {
                    var children = new List<FibonacciHeapCell<TPriority, TValue>>(currentcell.node.Children);
                    children.Reverse();
                    foreach (var child in children)
                        stack.Push(new NodeLevel(child, currentcell.level + 1));
                }
                else
                {
                    columnPosition += nodeString.Length;
                }
                lines[lineNum] = currentLine;
            }
            return String.Join(Environment.NewLine, lines.ToArray());
        }

        public FibonacciHeapCell<TPriority, TValue> Enqueue(TPriority priority, TValue value)
        {
            var newNode =
                new FibonacciHeapCell<TPriority, TValue>
                {
                    Priority = priority,
                    Value = value,
                    Marked = false,
                    Degree = 1,
                    Next = null,
                    Previous = null,
                    Parent = null,
                    Removed = false
                };

            //We don't do any book keeping or maintenance of the heap on Enqueue,
            //We just add this node to the end of the list of Heaps, updating the Next if required
            this.nodes.AddLast(newNode);
            if (next == null ||
                (this.priorityComparsion(newNode.Priority, next.Priority) * directionMultiplier) < 0)
            {
                next = newNode;
            }
            count++;
            return newNode;
        }

        public void Delete(FibonacciHeapCell<TPriority, TValue> node)
        {
            Contract.Requires(node != null);

            ChangeKeyInternal(node, default(TPriority), true);
            Dequeue();
        }

        public void ChangeKey(FibonacciHeapCell<TPriority, TValue> node, TPriority newKey)
        {
            Contract.Requires(node != null);

            ChangeKeyInternal(node, newKey, false);
        }

        private void ChangeKeyInternal(
            FibonacciHeapCell<TPriority, TValue> node,
            TPriority NewKey, bool deletingNode)
        {
            Contract.Requires(node != null);

            var delta = Math.Sign(this.priorityComparsion(node.Priority, NewKey));
            if (delta == 0)
                return;
            if (delta == this.directionMultiplier || deletingNode)
            {
                //New value is in the same direciton as the heap
                node.Priority = NewKey;
                var parentNode = node.Parent;
                if (parentNode != null && ((priorityComparsion(NewKey, node.Parent.Priority) * directionMultiplier) < 0 || deletingNode))
                {
                    node.Marked = false;
                    parentNode.Children.Remove(node);
                    UpdateNodesDegree(parentNode);
                    node.Parent = null;
                    nodes.AddLast(node);
                    //This loop is the cascading cut, we continue to cut
                    //ancestors of the node reduced until we hit a root 
                    //or we found an unmarked ancestor
                    while (parentNode.Marked && parentNode.Parent != null)
                    {
                        parentNode.Parent.Children.Remove(parentNode);
                        UpdateNodesDegree(parentNode);
                        parentNode.Marked = false;
                        nodes.AddLast(parentNode);
                        var currentParent = parentNode;
                        parentNode = parentNode.Parent;
                        currentParent.Parent = null;
                    }
                    if (parentNode.Parent != null)
                    {
                        //We mark this node to note that it's had a child
                        //cut from it before
                        parentNode.Marked = true;
                    }
                }
                //Update next
                if (deletingNode || (priorityComparsion(NewKey, next.Priority) * directionMultiplier) < 0)
                {
                    next = node;
                }
            }
            else
            {
                //New value is in opposite direction of Heap, cut all children violating heap condition
                node.Priority = NewKey;
                if (node.Children != null)
                {
                    List<FibonacciHeapCell<TPriority, TValue>> toupdate = null;
                    foreach (var child in node.Children)
                    {
                        if ((priorityComparsion(node.Priority, child.Priority) * directionMultiplier) > 0)
                        {
                            if (toupdate == null)
                                toupdate = new List<FibonacciHeapCell<TPriority, TValue>>();
                            toupdate.Add(child);
                        }
                    }

                    if (toupdate != null)
                        foreach (var child in toupdate)
                        {
                            node.Marked = true;
                            node.Children.Remove(child);
                            child.Parent = null;
                            child.Marked = false;
                            nodes.AddLast(child);
                            UpdateNodesDegree(node);
                        }
                }
                UpdateNext();
            }
        }

        static int Max<T>(IEnumerable<T> values, Func<T, int> converter)
        {
            Contract.Requires(values != null);
            Contract.Requires(converter != null);

            int max = int.MinValue;
            foreach (var value in values)
            {
                int v = converter(value);
                if (max < v)
                    max = v;
            }
            return max;
        }

        /// <summary>
        /// Updates the degree of a node, cascading to update the degree of the
        /// parents if necessary
        /// </summary>
        /// <param name="parentNode"></param>
        private void UpdateNodesDegree(
            FibonacciHeapCell<TPriority, TValue> parentNode)
        {
            Contract.Requires(parentNode != null);

            var oldDegree = parentNode.Degree;
            parentNode.Degree =
                parentNode.Children.First != null
                ? Max(parentNode.Children, x => x.Degree) + 1
                : 1;
            FibonacciHeapCell<TPriority, TValue> degreeMapValue;
            if (oldDegree != parentNode.Degree)
            {
                if (degreeToNode.TryGetValue(oldDegree, out degreeMapValue) && degreeMapValue == parentNode)
                {
                    degreeToNode.Remove(oldDegree);
                }
                else if (parentNode.Parent != null)
                {
                    UpdateNodesDegree(parentNode.Parent);
                }
            }
        }

        public KeyValuePair<TPriority, TValue> Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();

            var result = new KeyValuePair<TPriority, TValue>(next.Priority, next.Value);

            nodes.Remove(next);
            next.Next = null;
            next.Parent = null;
            next.Previous = null;
            next.Removed = true;

            FibonacciHeapCell<TPriority, TValue> currentDegreeNode;
            if (degreeToNode.TryGetValue(next.Degree, out currentDegreeNode))
                if (currentDegreeNode == next)
                    degreeToNode.Remove(next.Degree);

            foreach (var child in next.Children)
                child.Parent = null;

            nodes.Merge(next.Children);
            next.Children.Clear();
            count--;
            UpdateNext();

            return result;
        }

        /// <summary>
        /// Updates the Next pointer, maintaining the heap
        /// by folding duplicate heap degrees into each other
        /// Takes O(lg(N)) time amortized
        /// </summary>
        private void UpdateNext()
        {
            this.CompressHeap();
            var node = this.nodes.First;
            next = this.nodes.First;
            while (node != null)
            {
                if ((this.priorityComparsion(node.Priority, next.Priority) * directionMultiplier) < 0)
                {
                    next = node;
                }
                node = node.Next;
            }
        }

        private void CompressHeap()
        {
            var node = this.nodes.First;
            FibonacciHeapCell<TPriority, TValue> currentDegreeNode;
            while (node != null)
            {
                var nextNode = node.Next;
                while (degreeToNode.TryGetValue(node.Degree, out currentDegreeNode) && currentDegreeNode != node)
                {
                    degreeToNode.Remove(node.Degree);
                    if ((this.priorityComparsion(currentDegreeNode.Priority, node.Priority) * directionMultiplier) <= 0)
                    {
                        if (node == nextNode)
                        {
                            nextNode = node.Next;
                        }
                        this.ReduceNodes(currentDegreeNode, node);
                        node = currentDegreeNode;
                    }
                    else
                    {
                        if (currentDegreeNode == nextNode)
                        {
                            nextNode = currentDegreeNode.Next;
                        }
                        this.ReduceNodes(node, currentDegreeNode);
                    }
                }
                degreeToNode[node.Degree] = node;
                node = nextNode;
            }
        }

        /// <summary>
        /// Given two nodes, adds the child node as a child of the parent node
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="childNode"></param>
        private void ReduceNodes(
            FibonacciHeapCell<TPriority, TValue> parentNode,
            FibonacciHeapCell<TPriority, TValue> childNode)
        {
            Contract.Requires(parentNode != null);
            Contract.Requires(childNode != null);

            this.nodes.Remove(childNode);
            parentNode.Children.AddLast(childNode);
            childNode.Parent = parentNode;
            childNode.Marked = false;
            if (parentNode.Degree == childNode.Degree)
            {
                parentNode.Degree += 1;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return nodes.First == null;
            }
        }
        public FibonacciHeapCell<TPriority, TValue> Top
        {
            get
            {
                return this.next;
            }
        }

        public void Merge(FibonacciHeap<TPriority, TValue> other)
        {
            Contract.Requires(other != null);

            if (other.Direction != this.Direction)
            {
                throw new Exception("Error: Heaps must go in the same direction when merging");
            }
            nodes.Merge(other.nodes);
            if ((priorityComparsion(other.Top.Priority, next.Priority) * directionMultiplier) < 0)
            {
                next = other.next;
            }
            count += other.Count;
        }

        public IEnumerator<KeyValuePair<TPriority, TValue>> GetEnumerator()
        {
            var tempHeap = new FibonacciHeap<TPriority, TValue>(this.Direction, this.priorityComparsion);
            var nodeStack = new Stack<FibonacciHeapCell<TPriority, TValue>>();
            nodes.ForEach(x => nodeStack.Push(x));
            while (nodeStack.Count > 0)
            {
                var topNode = nodeStack.Peek();
                tempHeap.Enqueue(topNode.Priority, topNode.Value);
                nodeStack.Pop();
                topNode.Children.ForEach(x => nodeStack.Push(x));
            }
            while (!tempHeap.IsEmpty)
            {
                yield return tempHeap.Top.ToKeyValuePair();
                tempHeap.Dequeue();
            }
        }

        public IEnumerable<KeyValuePair<TPriority, TValue>> GetDestructiveEnumerator()
        {
            while (!this.IsEmpty)
            {
                yield return this.Top.ToKeyValuePair();
                this.Dequeue();
            }
        }

        #region IEnumerable Members

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

    }

}