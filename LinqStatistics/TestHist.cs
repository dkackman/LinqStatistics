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
