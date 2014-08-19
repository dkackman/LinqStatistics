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
        public static IEnumerable<Bin> Histogram(this IEnumerable<double> source, int binCount)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            var min = source.Min();
            var bucketSize = (source.Max() - min) / (double)binCount;
            double rangeMax = 0;

            // first create a list of all the bins so even empty bins are accounted for
            List<Bin> bins = new List<Bin>(binCount);
            for (int i = 0; i < binCount; i++)
            {
                double rangeMin = min + (bucketSize * i);
                rangeMax = rangeMin + bucketSize;

                bins.Add(new Bin(rangeMin + (bucketSize / 2), rangeMin, rangeMax));
            }

            return source.AssignBuckets(CreateBins(bucketSize, min, binCount, false), min, bucketSize);
        }
        private static IEnumerable<Bin> AssignBuckets(this IEnumerable<double> source, IList<Bin> bins, double min, double bucketSize)
        {
            // then count the members of each bin
            foreach (var value in source)
            {
                int bucketIndex = 0;
                if (bucketSize > 0.0)
                {
                    bucketIndex = (int)Math.Floor((value - min) / bucketSize);
                    if (bucketIndex == bins.Count)
                    {
                        bucketIndex--;
                    }
                }
                bins[bucketIndex].Count++;
            }

            return bins;
        }
        /// <summary>
        /// Computes the Histogram of a sequence of int values.
        /// </summary>
        /// <param name="source">A sequence of int values to calculate the Histogram of.</param>
        /// <param name="binCount">The number of bins into which to segregate the data.</param>
        /// <returns>The Histogram of the sequence of int values.</returns>
        public static IEnumerable<Bin> HistogramUnbounded(this IEnumerable<int> source, double start, int binCount)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            var min = source.Min();

            if (min < start)
                throw new InvalidOperationException("start must be less then or equal to the sequence minimum");

            var bucketSize = (source.Max() - start) / (double)binCount;
            return source.AssignBuckets(CreateBins(bucketSize, start, binCount, true), min, bucketSize);
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

            var min = source.Min();
            var bucketSize = (source.Max() - min) / (double)binCount;
            return source.AssignBuckets(CreateBins(bucketSize, min, binCount, true), min, bucketSize);
        }

        /// <summary>
        /// Computes the Histogram of a sequence of int values.
        /// </summary>
        /// <param name="source">A sequence of int values to calculate the Histogram of.</param>
        /// <param name="bins">The collection of bins to segrate values into</param>
        /// <param name="bucketSize">The size of each bin</param>
        /// <returns>The Histogram of the sequence of int values.</returns>
        private static IEnumerable<Bin> AssignBuckets(this IEnumerable<int> source, IList<Bin> bins, double min, double bucketSize)
        {
            // then count the members of each bin
            foreach (var value in source)
            {
                int bucketIndex = 0;
                if (bucketSize > 0.0)
                {
                    bucketIndex = (int)Math.Floor((value - min) / bucketSize);
                    if (bucketIndex == bins.Count)
                    {
                        bucketIndex--;
                    }
                }
                bins[bucketIndex].Count++;
            }

            return bins;
        }

        private static IList<Bin> CreateBins(double bucketSize, double start, int binCount, bool unbounded)
        {
            if (binCount <= 0)
                throw new InvalidOperationException("binCount must be greater than 0");

            double rangeMax = 0;

            // first create a list of all the bins so even empty bins are accounted for
            List<Bin> bins = new List<Bin>(binCount);
            for (int i = 0; i < binCount; i++)
            {
                double rangeMin = start + (bucketSize * i);
                rangeMax = rangeMin + bucketSize;

                bins.Add(new Bin(rangeMin + (bucketSize / 2), rangeMin, rangeMax));
            }

            if (unbounded)
            {
                // if sequence behavior is an unbounded histogram so add a bin for [lastBin.Range.Max, Infinity)
                bins.Add(new Bin(rangeMax + (bucketSize / 2), rangeMax, double.PositiveInfinity));
            }

            return bins;
        }
    }
}
