using System;
using System.Collections.Generic;
using System.Linq;

namespace Cogito.Linq
{

    /// <summary>
    /// Provides set combinatorial methods.
    /// </summary>
    public static class Combinatorials
    {

        /// <summary>
        /// Returns an enumeration of all combinations of size <paramref name="size"/> for the input collection
        /// <paramref name="self"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> Combinations<T>(this IEnumerable<T> self, int size)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (size < 1)
                throw new ArgumentOutOfRangeException(nameof(size));
            if (size > self.Count())
                throw new ArgumentOutOfRangeException(nameof(size));

            return Combinations(self.ToArray(), size);
        }

        /// <summary>
        /// Returns an enumeration of all combinations of size <paramref name="size"/> for the input array
        /// <paramref name="self"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> Combinations<T>(this T[] self, int size)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (size < 1)
                throw new ArgumentOutOfRangeException(nameof(size));
            if (size > self.Length)
                throw new ArgumentOutOfRangeException(nameof(size));

            // replace input with incrementing series
            var a = new int[size];

            // initialize series with low initial value, and max following
            // first result can be found from this
            for (int i = 0; i < size; i++)
                a[i] = self.Length;
            a[0] = -1;

            while (true)
            {
                // find index into work list that can be incremented
                int k = -1;
                for (int i = size - 1; i >= 0; i--)
                    if (a[i] + size - i <= self.Length - 1)
                    {
                        k = i;
                        break;
                    }

                // no index found, we must be finished
                if (k == -1)
                    break;

                // increment position, reset all following indexes
                a[k]++;
                for (int i = k + 1; i <= size - 1; i++)
                    a[i] = a[i - 1] + 1;

                // finished combination
                yield return MapOutput(self, a);
            }
        }

        /// <summary>
        /// Returns an enumeration of all permutations of <paramref name="self"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> Permutations<T>(this IEnumerable<T> self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            return Permutations(self.ToArray());
        }

        /// <summary>
        /// Returns an enumeration of all permutations of <paramref name="self"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> Permutations<T>(this T[] self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            var a = new int[self.Length];
            for (int i = 0; i < a.Length; i++)
                a[i] = i;

            // initial input is first permutation
            yield return MapOutput(self, a);

            while (true)
            {
                int j = a.Length - 2;
                while (j >= 0 && a[j] > a[j + 1])
                    j--;

                if (j == -1)
                    break;

                int k = a.Length - 1;
                while (a[j] > a[k])
                    k--;

                int t = a[j];
                a[j] = a[k];
                a[k] = t;

                int r = a.Length - 1;
                int s = j + 1;

                while (r > s)
                {
                    t = a[s];
                    a[s] = a[r];
                    a[r] = t;
                    r--;
                    s++;
                }

                // finished permutation
                yield return MapOutput(self, a);
            }
        }

        /// <summary>
        /// Returns an enumeration of all variations of <paramref name="self"/> of size <paramref name="size"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> Variations<T>(this IEnumerable<T> self, int size)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (size > self.Count())
                throw new ArgumentNullException(nameof(size));

            return Variations(self.ToArray(), size);
        }

        /// <summary>
        /// Returns an enumeration of all variations of <paramref name="self"/> of size <paramref name="size"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> Variations<T>(this T[] self, int size)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (size > self.Length)
                throw new ArgumentOutOfRangeException(nameof(size));

            foreach (var combination in Combinations(self, size))
                foreach (var permutation in Permutations(combination))
                    yield return permutation;
        }

        /// <summary>
        /// Maps index list to output.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="indexes"></param>
        /// <returns></returns>
        static T[] MapOutput<T>(T[] input, int[] indexes)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (indexes == null)
                throw new ArgumentNullException(nameof(indexes));
            if (input.Length < 0)
                throw new ArgumentOutOfRangeException(nameof(input));
            if (indexes.Length < 0)
                throw new ArgumentOutOfRangeException(nameof(indexes));

            var output = new T[indexes.Length];
            for (int i = 0; i < indexes.Length; i++)
                output[i] = input[indexes[i]];
            return output;
        }

    }

}
