using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        //
        // Summary:
        //     Computes the Pearson of a sequence of nullable System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Decimal values to calculate the Pearson of.
        //
        // Returns:
        //     The Pearson of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        public static decimal? Pearson(this IEnumerable<decimal?> source, IEnumerable<decimal?> other)
        {
            IEnumerable<decimal> values = source.Coalesce();
            if (values.Any())
                return values.Pearson(other.Coalesce());

            return null;
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Decimal values to calculate the Pearson of.
        //
        // Returns:
        //     The Pearson of the sequence of values.
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
        public static decimal Pearson(this IEnumerable<decimal> source, IEnumerable<decimal> other)
        {
            return (decimal)source.Select(x => (double)x).Pearson(other.Select(x => (double)x));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of nullable System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Double values to calculate the Pearson of.
        //
        // Returns:
        //     The Pearson of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        public static double? Pearson(this IEnumerable<double?> source, IEnumerable<double?> other)
        {
            IEnumerable<double> values = source.Coalesce();
            if (values.Any())
                return values.Pearson(other.Coalesce());

            return null;
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Double values to calculate the Pearson of.
        //
        // Returns:
        //     The Pearson of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static double Pearson(this IEnumerable<double> source, IEnumerable<double> other)
        {
            if (source.Count() != other.Count())
                throw new ArgumentException("Collections are not of the same length", "other");

            return source.Covariance(other) / (source.StandardDeviationP() * other.StandardDeviationP());
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of nullable System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Single values to calculate the Pearson of.
        //
        // Returns:
        //     The Pearson of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        public static float? Pearson(this IEnumerable<float?> source, IEnumerable<float?> other)
        {
            IEnumerable<float> values = source.Coalesce();
            if (values.Any())
                return values.Pearson(other.Coalesce());

            return null;
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Single values to calculate the Pearson of.
        //
        // Returns:
        //     The Pearson of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static float Pearson(this IEnumerable<float> source, IEnumerable<float> other)
        {
            return (float)source.Select(x => (double)x).Pearson(other.Select(x => (double)x));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of nullable System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int32values to calculate the Pearson of.
        //
        // Returns:
        //     The Pearson of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static double? Pearson(this IEnumerable<int?> source, IEnumerable<int?> other)
        {
            IEnumerable<int> values = source.Coalesce();
            if (values.Any())
                return values.Pearson(other.Coalesce());

            return null;
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int32 values to calculate the Pearson of.
        //
        // Returns:
        //     The Pearson of the sequence of values.
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
        public static double Pearson(this IEnumerable<int> source, IEnumerable<int> other)
        {
            return source.Select(x => (double)x).Pearson(other.Select(x => (double)x));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of nullable System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int64 values to calculate the Pearson of.
        //
        // Returns:
        //     The Pearson of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static double? Pearson(this IEnumerable<long?> source, IEnumerable<long?> other)
        {
            IEnumerable<long> values = source.Coalesce();
            if (values.Any())
                return values.Pearson(other.Coalesce());

            return null;
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int64 values to calculate the Pearson of.
        //
        // Returns:
        //     The Pearson of the sequence of values.
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
        public static double Pearson(this IEnumerable<long> source, IEnumerable<long> other)
        {
            return source.Select(x => (double)x).Pearson(other.Select(x => (double)x));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of nullable System.Decimal values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Pearson of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Pearson of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        public static decimal? Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, decimal?> selector)
        {
            return source.Select(selector).Pearson(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of System.Decimal values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values that are used to calculate an Pearson.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Pearson of the sequence of values.
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
        public static decimal Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, decimal> selector)
        {
            return source.Select(selector).Pearson(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of nullable System.Double values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Pearson of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Pearson of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        public static double? Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, double?> selector)
        {
            return source.Select(selector).Pearson(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of System.Double values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Pearson of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Pearson of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static double Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, double> selector)
        {
            return source.Select(selector).Pearson(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of nullable System.Single values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Pearson of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Pearson of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        public static float? Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, float?> selector)
        {
            return source.Select(selector).Pearson(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of System.Single values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Pearson of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Pearson of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static float Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, float> selector)
        {
            return source.Select(selector).Pearson(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of nullable System.Int32 values that are
        //     obtained by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Pearson of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Pearson of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static double? Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, int?> selector)
        {
            return source.Select(selector).Pearson(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of System.Int32 values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Pearson of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Pearson of the sequence of values.
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
        public static double Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, int> selector)
        {
            return source.Select(selector).Pearson(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of nullable System.Int64 values that are
        //     obtained by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Pearson of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Pearson of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        public static double? Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, long?> selector)
        {
            return source.Select(selector).Pearson(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Pearson of a sequence of System.Int64 values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Pearson of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Pearson of the sequence of values.
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
        public static double Pearson<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, long> selector)
        {
            return source.Select(selector).Pearson(other.Select(selector));
        }
    }
}
