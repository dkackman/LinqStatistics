#if BYPASST4
using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqStatistics
{

    /// <summary>
    /// Controls how the range of the bins are determined
    /// </summary>
    public enum BinningMode
    {
        /// <summary>
        /// The minimum will be equal to the sequence min and the maximum equal to infinity
        /// </summary>
        Unbounded,

        /// <summary>
        /// The minimum will be the sequnce min and the maximxum equal to sequence max
        /// The last bin will max inclusive instead of exclusive
        /// </summary>
        MaxValueInclusive,

        /// <summary>
        /// The total range will be expanded such that the min is
        /// less then the sequence min and max is greater then the sequence max
        /// </summary>
        ExpandRange
    }

    public static class TestHist
    {
        /// <summary>
        /// Computes the Histogram of a sequence of int values.
        /// </summary>
        /// <param name="source">A sequence of int values to calculate the Histogram of.</param>
        /// <param name="binCount">The number of bins into which to segregate the data.</param>
        /// <param name="mode">The method used to determine the range of each bin</param>
        /// <returns>The Histogram of the sequence of int values.</returns>
        public static IEnumerable<Bin> Histogram(this IEnumerable<int> source, int binCount, BinningMode mode = BinningMode.Unbounded)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            var bins = BinFactory.CreateBins(source.Min(), source.Max(), binCount, mode);
            source.AssignBins(bins);

            return bins;
        }

        /// <summary>
        /// Computes the Histogram of a sequence of nullable int values.
        /// </summary>
        /// <param name="source">A sequence of nullable int values to calculate the Histogram of.</param>
        /// <param name="binCount">The number of bins into which to segregate the data.</param>
        /// <param name="mode">The method used to determine the range of each bin</param>
        /// <returns>The Histogram of the sequence of nullable int values.</returns>
        public static IEnumerable<Bin> Histogram(this IEnumerable<int?> source, int binCount, BinningMode mode = BinningMode.Unbounded)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            return source.AllValues().Histogram(binCount, mode);
        }

        /// <summary>
        /// Computes the Histogram of a sequence of int values that are obtained
        /// by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Histogram of.</param>
        /// <param name="binCount">The number of bins into which to segregate the data.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="mode">The method used to determine the range of each bin</param>
        /// <returns>The Histogram of the sequence of int values.</returns>
        public static IEnumerable<Bin> Histogram<TSource>(this IEnumerable<TSource> source, int binCount, Func<TSource, int> selector, BinningMode mode = BinningMode.Unbounded)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            var sequence = source.Select(t => selector(t));
            var bins = BinFactory.CreateBins(sequence.Min(), sequence.Max(), binCount, mode);
            sequence.AssignBins(bins);

            return bins;
        }

        /// <summary>
        /// Computes the Histogram of a sequence of nullable int values that are obtained
        /// by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Histogram of.</param>
        /// <param name="binCount">The number of bins into which to segregate the data.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="mode">The method used to determine the range of each bin</param>
        /// <returns>The Histogram of the sequence of nullable int values.</returns>
        public static IEnumerable<Bin> Histogram<TSource>(this IEnumerable<TSource> source, int binCount, Func<TSource, int?> selector, BinningMode mode = BinningMode.Unbounded)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            var sequence = source.Select(t => selector(t)).AllValues();
            var bins = BinFactory.CreateBins(sequence.Min(), sequence.Max(), binCount, mode);
            sequence.AssignBins(bins);

            return bins;
        }

        private static void AssignBins(this IEnumerable<int> source, IList<Bin> bins)
        {
            foreach (var value in source)
            {
                var bin = bins.First(b => b.Range.Contains(value));
                bin.Count++;
            }
        }       
    }
}
#endif