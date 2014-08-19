using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public enum BinningMode
    {
        Unbounded,
        MaxValueInclusive,
        ExpandRange
    }

    public static class TestHist
    {
        /// <summary>
        /// Computes the Histogram of a sequence of int values.
        /// </summary>
        /// <param name="source">A sequence of int values to calculate the Histogram of.</param>
        /// <param name="binCount">The number of bins into which to segregate the data.</param>
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
