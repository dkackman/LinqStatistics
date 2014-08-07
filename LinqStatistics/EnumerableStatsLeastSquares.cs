using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of nullable System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Decimal values to calculate the LeastSquares of.
        //
        // Returns:
        //     The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<decimal?, decimal?>> source)
        {
            IEnumerable<Tuple<decimal, decimal>> values = source.AllValues();

            if (values.Any())
                return values.LeastSquares();

            return null;
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Decimal values to calculate the LeastSquares of.
        //
        // Returns:
        //     The LeastSquares of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        public static LeastSquares LeastSquares(this IEnumerable<Tuple<decimal, decimal>> source)
        {
            int numPoints = 0;
            double sumX = 0;
            double sumY = 0;
            double sumXX = 0;
            double sumXY = 0;

            foreach (var tuple in source)
            {
                numPoints++;
                sumX += (double)tuple.Item1;
                sumY += (double)tuple.Item2;
                sumXX += (double)(tuple.Item1 * tuple.Item1);
                sumXY += (double)(tuple.Item1 * tuple.Item2);
            }

            if (numPoints < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");

            double b = (-sumX * sumXY + sumXX * sumY) / (numPoints * sumXX - sumX * sumX);
            double m = (-sumX * sumY + numPoints * sumXY) / (numPoints * sumXX - sumX * sumX);

            return new LeastSquares(m, b);
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of nullable System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Double values to calculate the LeastSquares of.
        //
        // Returns:
        //     The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<double?, double?>> source)
        {
            IEnumerable<Tuple<double, double>> values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Double values to calculate the LeastSquares of.
        //
        // Returns:
        //     The LeastSquares of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static LeastSquares LeastSquares(this IEnumerable<Tuple<double, double>> source)
        {
            int numPoints = 0;
            double sumX = 0;
            double sumY = 0;
            double sumXX = 0;
            double sumXY = 0;

            foreach (var tuple in source)
            {
                numPoints++;
                sumX += tuple.Item1;
                sumY += tuple.Item2;
                sumXX += tuple.Item1 * tuple.Item1;
                sumXY += tuple.Item1 * tuple.Item2;
            }

            if (numPoints < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");

            double b = (-sumX * sumXY + sumXX * sumY) / (numPoints * sumXX - sumX * sumX);
            double m = (-sumX * sumY + numPoints * sumXY) / (numPoints * sumXX - sumX * sumX);

            return new LeastSquares(m, b);
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of nullable System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Single values to calculate the LeastSquares of.
        //
        // Returns:
        //     The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<float?, float?>> source)
        {
            IEnumerable<Tuple<float, float>> values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Single values to calculate the LeastSquares of.
        //
        // Returns:
        //     The LeastSquares of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static LeastSquares LeastSquares(this IEnumerable<Tuple<float, float>> source)
        {
            int numPoints = 0;
            double sumX = 0;
            double sumY = 0;
            double sumXX = 0;
            double sumXY = 0;

            foreach (var tuple in source)
            {
                numPoints++;
                sumX += tuple.Item1;
                sumY += tuple.Item2;
                sumXX += tuple.Item1 * tuple.Item1;
                sumXY += tuple.Item1 * tuple.Item2;
            }

            if (numPoints < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");

            double b = (-sumX * sumXY + sumXX * sumY) / (numPoints * sumXX - sumX * sumX);
            double m = (-sumX * sumY + numPoints * sumXY) / (numPoints * sumXX - sumX * sumX);

            return new LeastSquares(m, b);
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of nullable System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int32values to calculate the LeastSquares of.
        //
        // Returns:
        //     The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<int?, int?>> source)
        {
            IEnumerable<Tuple<int, int>> values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int32 values to calculate the LeastSquares of.
        //
        // Returns:
        //     The LeastSquares of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static LeastSquares LeastSquares(this IEnumerable<Tuple<int, int>> source)
        {
            int numPoints = 0;
            double sumX = 0;
            double sumY = 0;
            double sumXX = 0;
            double sumXY = 0;

            foreach (var tuple in source)
            {
                numPoints++;
                sumX += tuple.Item1;
                sumY += tuple.Item2;
                sumXX += tuple.Item1 * tuple.Item1;
                sumXY += tuple.Item1 * tuple.Item2;
            }

            if (numPoints < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");

            double b = (-sumX * sumXY + sumXX * sumY) / (numPoints * sumXX - sumX * sumX);
            double m = (-sumX * sumY + numPoints * sumXY) / (numPoints * sumXX - sumX * sumX);

            return new LeastSquares(m, b);
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of nullable System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int64 values to calculate the LeastSquares of.
        //
        // Returns:
        //     The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<long?, long?>> source)
        {
            IEnumerable<Tuple<long, long>> values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int64 values to calculate the LeastSquares of.
        //
        // Returns:
        //     The LeastSquares of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static LeastSquares LeastSquares(this IEnumerable<Tuple<long, long>> source)
        {
            int numPoints = 0;
            double sumX = 0;
            double sumY = 0;
            double sumXX = 0;
            double sumXY = 0;

            foreach (var tuple in source)
            {
                numPoints++;
                sumX += tuple.Item1;
                sumY += tuple.Item2;
                sumXX += tuple.Item1 * tuple.Item1;
                sumXY += tuple.Item1 * tuple.Item2;
            }

            if (numPoints < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");

            double b = (-sumX * sumXY + sumXX * sumY) / (numPoints * sumXX - sumX * sumX);
            double m = (-sumX * sumY + numPoints * sumXY) / (numPoints * sumXX - sumX * sumX);

            return new LeastSquares(m, b);
        }

        //
        // Summary:
        //     Computes the LeastSquares of a sequence of nullable System.Decimal values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the LeastSquares of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<decimal?, decimal?>> selector)
        {
            return source.Select(selector).LeastSquares();
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of System.Decimal values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values that are used to calculate an LeastSquares.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The LeastSquares of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<decimal, decimal>> selector)
        {
            return source.Select(selector).LeastSquares();
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of nullable System.Double values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the LeastSquares of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<double?, double?>> selector)
        {
            return source.Select(selector).LeastSquares();
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of System.Double values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the LeastSquares of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The LeastSquares of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<double, double>> selector)
        {
            return source.Select(selector).LeastSquares();
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of nullable System.Single values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the LeastSquares of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<float?, float?>> selector)
        {
            return source.Select(selector).LeastSquares();
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of System.Single values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the LeastSquares of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The LeastSquares of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<float, float>> selector)
        {
            return source.Select(selector).LeastSquares();
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of nullable System.Int32 values that are
        //     obtained by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the LeastSquares of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<int?, int?>> selector)
        {
            return source.Select(selector).LeastSquares();
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of System.Int32 values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the LeastSquares of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The LeastSquares of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<int, int>> selector)
        {
            return source.Select(selector).LeastSquares();
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of nullable System.Int64 values that are
        //     obtained by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the LeastSquares of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<long?, long?>> selector)
        {
            return source.Select(selector).LeastSquares();
        }
        //
        // Summary:
        //     Computes the LeastSquares of a sequence of System.Int64 values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the LeastSquares of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The LeastSquares of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<long, long>> selector)
        {
            return source.Select(selector).LeastSquares();
        }
    }
}
