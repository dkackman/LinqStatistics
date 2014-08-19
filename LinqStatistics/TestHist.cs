using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static class TestHist
    {
        /// <summary>
        /// Computes the Histogram of a sequence of int values.
        /// </summary>
        /// <param name="source">A sequence of int values to calculate the Histogram of.</param>
        /// <param name="binCount">The number of bins into which to segregate the data.</param>
        /// <returns>The Histogram of the sequence of int values.</returns>
        public static IEnumerable<Bin> Histogram(this IEnumerable<int> source, int binCount)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            var bins = CreateBins(source.Min(), source.Max(), binCount, false);
            source.AssignBins(bins);

            return bins;
        }

        /// <summary>
        /// Computes the Histogram of a sequence of int values.
        /// </summary>
        /// <param name="source">A sequence of int values to calculate the Histogram of.</param>
        /// <param name="binCount">The number of bins into which to segregate the data.</param>
        /// <returns>The Histogram of the sequence of int values.</returns>
        public static IEnumerable<Bin> HistogramUnbounded(this IEnumerable<int> source, int binCount)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            var bins = CreateBins(source.Min(), source.Max(), binCount, true);
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

        private static IList<Bin> CreateBins(double min, double max, int binCount, bool unbounded)
        {
            if (binCount <= 0)
                throw new InvalidOperationException("binCount must be greater than 0");

            double binSize = (max - min) / (double)binCount;
            double halfBin = binSize / 2.0;
            double rangeMin = min - halfBin;
            double rangeMax = rangeMin + binSize;

            // first create a list of all the bins so even empty bins are accounted for
            List<Bin> bins = new List<Bin>(binCount);
            for (int i = 0; i < binCount; i++)
            {
                bins.Add(new Bin(rangeMin + halfBin, rangeMin, rangeMax));
                rangeMin += binSize;
                rangeMax += binSize;
            }

            if (unbounded)
            {
                // if sequence behavior is an unbounded histogram so add a bin for [lastBin.Range.Max, Infinity)
                bins.Add(new Bin(rangeMin + halfBin, rangeMin, double.PositiveInfinity));
            }

            return bins;
        }
    }
}
