using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Cogito.Collections
{

    [DebuggerDisplay("Count = {Count}")]
    public sealed class FibonacciQueue<TVertex, TDistance> : IPriorityQueue<TVertex>
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
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));

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
            if (distances == null)
                throw new ArgumentNullException(nameof(distances));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="valueCount"></param>
        /// <param name="values"></param>
        /// <param name="distances"></param>
        public FibonacciQueue(int valueCount, IEnumerable<TVertex> values, Func<TVertex, TDistance> distances)
            : this(valueCount, values, distances, Comparer<TDistance>.Default.Compare)
        {
            if (valueCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(valueCount));
            if (distances == null)
                throw new ArgumentNullException(nameof(distances));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="valueCount"></param>
        /// <param name="values"></param>
        /// <param name="distances"></param>
        /// <param name="distanceComparison"></param>
        public FibonacciQueue(int valueCount, IEnumerable<TVertex> values, Func<TVertex, TDistance> distances, Func<TDistance, TDistance, int> distanceComparison)
        {
            if (valueCount < 0)
                throw new ArgumentOutOfRangeException(nameof(valueCount));
            if (distances == null)
                throw new ArgumentNullException(nameof(distances));
            if (distanceComparison == null)
                throw new ArgumentNullException(nameof(distanceComparison));

            this.distances = distances;
            cells = new Dictionary<TVertex, FibonacciHeapCell<TDistance, TVertex>>(valueCount);
            if (valueCount > 0)
                foreach (var x in values)
                    cells.Add(
                        x,
                        new FibonacciHeapCell<TDistance, TVertex>
                        {
                            Priority = this.distances(x),
                            Value = x,
                            Removed = true
                        }
                    );
            heap = new FibonacciHeap<TDistance, TVertex>(HeapDirection.Increasing, distanceComparison);
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
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (distanceComparison == null)
                throw new ArgumentNullException(nameof(distanceComparison));

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
            if (values == null)
                throw new ArgumentNullException(nameof(values));
        }

        #region IQueue<TVertex> Members

        public int Count
        {
            get { return heap.Count; }
        }

        public bool Contains(TVertex value)
        {
            return cells.TryGetValue(value, out var result) && !result.Removed;
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
            heap.Dequeue();
            return result.Value;
        }

        public TVertex Peek()
        {
            return heap.Top.Value;
        }

        public TVertex[] ToArray()
        {
            var result = new TVertex[heap.Count];
            int i = 0;
            foreach (var entry in heap)
                result[i++] = entry.Value;
            return result;
        }

        #endregion

    }

}
