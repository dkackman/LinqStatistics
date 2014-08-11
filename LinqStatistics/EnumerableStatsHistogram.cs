using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        //
        // Summary:
        //     Computes the Histogram of a sequence of nullable int values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable int values to calculate the Histogram of.
        //
        //   binCount:
        //     The number of bins into which to segregate the data.
        //
        // Returns:
        //     The Histogram of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        //     binCount is less then or equal to 0
        public static IEnumerable<Bin<double?>> Histogram(this IEnumerable<int?> source, int binCount)
        {
            var histogram = source.AllValues().Histogram(binCount);
            var nulls = new List<Bin<double?>>(1)
            {
                new Bin<double?>(null, source.Count(i => i == null))
            };

            return nulls.Concat(histogram.Select(b => new Bin<Double?>(b.RepresentativeValue , b.Count)));
        }

        //
        // Summary:
        //     Computes the Histogram of a sequence of int values.
        //
        // Parameters:
        //   source:
        //     A sequence of int values to calculate the Histogram of.
        //
        //   binCount:
        //     The number of bins into which to segregate the data.
        //
        // Returns:
        //     The Histogram of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        //     binCount is less then or equal to 0
        public static IEnumerable<Bin<double>> Histogram(this IEnumerable<int> source, int binCount)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            if (binCount <= 0)
                throw new InvalidOperationException("binCount must be greater than 0");

            var min = source.Min();

            var bucketSize = source.Range() / (double)binCount;
            double start = min;

            List<Bin<double>> bins = new List<Bin<double>>(binCount);
            for (int i = 0; i < binCount; i++)
            {
                bins.Add(new Bin<double>(start + (bucketSize * i), 0));
            }

            foreach (var value in source)
            {
                int bucketIndex = 0;
                if (bucketSize > 0.0)
                {
                    bucketIndex = (int)Math.Round((value - min) / bucketSize, 0);
                    if (bucketIndex == binCount)
                    {
                        bucketIndex--;
                    }
                }
                bins[bucketIndex].Count++;
            }
            return bins;
        }

        //
        // Summary:
        //     Computes the Histogram of a sequence of values.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Histogram of.
        //
        // Returns:
        //     The Histogram of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static IEnumerable<Bin<T>> Histogram<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            return from t in source
                   group t by t into g
                   orderby g.Key
                   select new Bin<T>(g.Key, g.Count());
        }

        //
        // Summary:
        //     Computes the Histogram of a sequence of nullable values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Histogram of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Histogram of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        public static IEnumerable<Bin<T>> Histogram<TSource, T>(this IEnumerable<TSource> source, Func<TSource, T> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).Histogram();
        }
    }
}