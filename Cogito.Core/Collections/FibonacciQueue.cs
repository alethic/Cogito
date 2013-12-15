using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Collections
{

    [DebuggerDisplay("Count = {Count}")]
    public sealed class FibonacciQueue<TVertex, TDistance> :
        IPriorityQueue<TVertex>
    {

        /// <summary>
        /// Returns the method that implement the access indexer.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static Func<TKey, TValue> GetIndexer<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            Contract.Requires<ArgumentNullException>(dictionary != null);
            Contract.Ensures(Contract.Result<Func<TKey, TValue>>() != null);

            var method = dictionary.GetType().GetProperty("Item").GetGetMethod();
            return (Func<TKey, TValue>)Delegate.CreateDelegate(typeof(Func<TKey, TValue>), dictionary, method, true);
        }

        readonly FibonacciHeap<TDistance, TVertex> heap;
        readonly Dictionary<TVertex, FibonacciHeapCell<TDistance, TVertex>> cells;
        readonly Func<TVertex, TDistance> distances;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="distances"></param>
        public FibonacciQueue(
            Func<TVertex, TDistance> distances)
            : this(0, null, distances, Comparer<TDistance>.Default.Compare)
        {
            Contract.Requires<ArgumentNullException>(distances != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="valueCount"></param>
        /// <param name="values"></param>
        /// <param name="distances"></param>
        public FibonacciQueue(
            int valueCount,
            IEnumerable<TVertex> values,
            Func<TVertex, TDistance> distances)
            : this(valueCount, values, distances, Comparer<TDistance>.Default.Compare)
        {
            Contract.Requires<ArgumentOutOfRangeException>(valueCount >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(valueCount == 0 || (values != null && valueCount == Enumerable.Count(values)));
            Contract.Requires<ArgumentNullException>(distances != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="valueCount"></param>
        /// <param name="values"></param>
        /// <param name="distances"></param>
        /// <param name="distanceComparison"></param>
        public FibonacciQueue(
            int valueCount,
            IEnumerable<TVertex> values,
            Func<TVertex, TDistance> distances,
            Func<TDistance, TDistance, int> distanceComparison)
        {
            Contract.Requires<ArgumentOutOfRangeException>(valueCount >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(valueCount == 0 || (values != null && valueCount == Enumerable.Count(values)));
            Contract.Requires<ArgumentNullException>(distances != null);
            Contract.Requires<ArgumentNullException>(distanceComparison != null);

            this.distances = distances;
            this.cells = new Dictionary<TVertex, FibonacciHeapCell<TDistance, TVertex>>(valueCount);
            if (valueCount > 0)
                foreach (var x in values)
                    this.cells.Add(
                        x,
                        new FibonacciHeapCell<TDistance, TVertex>
                        {
                            Priority = this.distances(x),
                            Value = x,
                            Removed = true
                        }
                    );
            this.heap = new FibonacciHeap<TDistance, TVertex>(HeapDirection.Increasing, distanceComparison);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="distanceComparison"></param>
        public FibonacciQueue(
            Dictionary<TVertex, TDistance> values,
            Func<TDistance, TDistance, int> distanceComparison)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(distanceComparison != null);

            distances = GetIndexer(values);
            cells = new Dictionary<TVertex, FibonacciHeapCell<TDistance, TVertex>>(values.Count);

            foreach (var kv in values)
                cells.Add(
                    kv.Key,
                    new FibonacciHeapCell<TDistance, TVertex>
                    {
                        Priority = kv.Value,
                        Value = kv.Key,
                        Removed = true
                    }
                );

            heap = new FibonacciHeap<TDistance, TVertex>(HeapDirection.Increasing, distanceComparison);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="values"></param>
        public FibonacciQueue(
            Dictionary<TVertex, TDistance> values)
            : this(values, Comparer<TDistance>.Default.Compare)
        {
            Contract.Requires<ArgumentNullException>(values != null);
        }

        #region IQueue<TVertex> Members

        public int Count
        {
            [Pure]
            get { return heap.Count; }
        }

        [Pure]
        public bool Contains(TVertex value)
        {
            FibonacciHeapCell<TDistance, TVertex> result;
            return
                cells.TryGetValue(value, out result) &&
                !result.Removed;
        }

        public void Update(TVertex v)
        {
            heap.ChangeKey(cells[v], distances(v));
        }

        public void Enqueue(TVertex value)
        {
            cells[value] = heap.Enqueue(distances(value), value);
        }

        public TVertex Dequeue()
        {
            var result = heap.Top;
            Contract.Assert(result != null);
            heap.Dequeue();
            return result.Value;
        }

        public TVertex Peek()
        {
            Contract.Assert(heap.Top != null);

            return heap.Top.Value;
        }

        [Pure]
        public TVertex[] ToArray()
        {
            TVertex[] result = new TVertex[heap.Count];
            int i = 0;
            foreach (var entry in heap)
                result[i++] = entry.Value;
            return result;
        }

        #endregion

    }

}
