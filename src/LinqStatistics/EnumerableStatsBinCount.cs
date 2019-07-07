using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        /// <summary>
        /// http://en.wikipedia.org/wiki/Histogram#Number_of_bins_and_width
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The number of bins to use to create a histogram.</returns>
        public static int BinCountSturges<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return (int)Math.Round(Math.Log(source.Count(), 2) + 1, 0);
        }

        /// <summary>
        /// http://en.wikipedia.org/wiki/Histogram#Number_of_bins_and_width
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The number of bins to use to create a histogram.</returns>
        public static int BinCountSquareRoot<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return (int)Math.Round(Math.Sqrt(source.Count()), 0);
        }

        /// <summary>
        /// http://en.wikipedia.org/wiki/Histogram#Number_of_bins_and_width
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The number of bins to use to create a histogram.</returns>
        public static int BinCountRice<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return (int)Math.Round(2.0 * Math.Pow(source.Count(), 1.0 / 3.0), 0);
        }
    }
}
