using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of nullable System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Decimal values to calculate the Kurtosis of.
        //
        // Returns:
        //     The Kurtosis of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        public static decimal? Kurtosis(this IEnumerable<decimal?> source)
        {
            IEnumerable<decimal> values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Decimal values to calculate the Kurtosis of.
        //
        // Returns:
        //     The Kurtosis of the sequence of values.
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
        public static decimal Kurtosis(this IEnumerable<decimal> source)
        {
            return (decimal)source.Select(x => (double)x).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of nullable System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Double values to calculate the Kurtosis of.
        //
        // Returns:
        //     The Kurtosis of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        public static double? Kurtosis(this IEnumerable<double?> source)
        {
            IEnumerable<double> values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Double values to calculate the Kurtosis of.
        //
        // Returns:
        //     The Kurtosis of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static double Kurtosis(this IEnumerable<double> source)
        {
            int n = 0;
            double mean = 0;
            double M2 = 0;
            double M3 = 0;
            double M4 = 0;

            foreach (var x in source)
            {
                int n1 = n;
                n = n + 1;
                double delta = x - mean;
                double delta_n = delta / n;
                double delta_n2 = delta_n * delta_n;
                double term1 = delta * delta_n * n1;
                mean = mean + delta_n;
                M4 += term1 * delta_n2 * (n * n - 3 * n + 3) + 6 * delta_n2 * M2 - 4 * delta_n * M3;
                M3 += term1 * delta_n * (n - 2) - 3 * delta_n * M2;
                M2 += term1;
            }
            return (n * M4) / (M2 * M2) - 3;
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of nullable System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Single values to calculate the Kurtosis of.
        //
        // Returns:
        //     The Kurtosis of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        public static float? Kurtosis(this IEnumerable<float?> source)
        {
            IEnumerable<float> values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Single values to calculate the Kurtosis of.
        //
        // Returns:
        //     The Kurtosis of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static float Kurtosis(this IEnumerable<float> source)
        {
            return (float)source.Select(x => (double)x).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of nullable System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int32values to calculate the Kurtosis of.
        //
        // Returns:
        //     The Kurtosis of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static double? Kurtosis(this IEnumerable<int?> source)
        {
            IEnumerable<int> values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int32 values to calculate the Kurtosis of.
        //
        // Returns:
        //     The Kurtosis of the sequence of values.
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
        public static double Kurtosis(this IEnumerable<int> source)
        {
            return source.Select(x => (double)x).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of nullable System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int64 values to calculate the Kurtosis of.
        //
        // Returns:
        //     The Kurtosis of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static double? Kurtosis(this IEnumerable<long?> source)
        {
            IEnumerable<long> values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int64 values to calculate the Kurtosis of.
        //
        // Returns:
        //     The Kurtosis of the sequence of values.
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
        public static double Kurtosis(this IEnumerable<long> source)
        {
            return source.Select(x => (double)x).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of nullable System.Decimal values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Kurtosis of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Kurtosis of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        public static decimal? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            return source.Select(selector).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of System.Decimal values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values that are used to calculate an Kurtosis.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Kurtosis of the sequence of values.
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
        public static decimal Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            return source.Select(selector).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of nullable System.Double values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Kurtosis of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Kurtosis of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        public static double? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            return source.Select(selector).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of System.Double values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Kurtosis of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Kurtosis of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static double Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            return source.Select(selector).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of nullable System.Single values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Kurtosis of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Kurtosis of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        public static float? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            return source.Select(selector).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of System.Single values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Kurtosis of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Kurtosis of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static float Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            return source.Select(selector).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of nullable System.Int32 values that are
        //     obtained by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Kurtosis of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Kurtosis of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static double? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            return source.Select(selector).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of System.Int32 values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Kurtosis of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Kurtosis of the sequence of values.
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
        public static double Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            return source.Select(selector).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of nullable System.Int64 values that are
        //     obtained by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Kurtosis of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Kurtosis of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        public static double? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            return source.Select(selector).Kurtosis();
        }
        //
        // Summary:
        //     Computes the Kurtosis of a sequence of System.Int64 values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Kurtosis of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Kurtosis of the sequence of values.
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
        public static double Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            return source.Select(selector).Kurtosis();
        }
    }
}
