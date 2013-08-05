using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        //
        // Summary:
        //     Computes the Covariance of a sequence of nullable System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Decimal values to calculate the Covariance of.
        //
        // Returns:
        //     The Covariance of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        public static decimal? Covariance(this IEnumerable<decimal?> source, IEnumerable<decimal?> other)
        {
            IEnumerable<decimal> values = source.Coalesce();
            if (values.Any())
                return values.Covariance(other.Coalesce());

            return null;
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Decimal values to calculate the Covariance of.
        //
        // Returns:
        //     The Covariance of the sequence of values.
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
        public static decimal Covariance(this IEnumerable<decimal> source, IEnumerable<decimal> other)
        {
            return (decimal)source.Select(x => (double)x).Covariance(other.Select(x => (double)x));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of nullable System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Double values to calculate the Covariance of.
        //
        // Returns:
        //     The Covariance of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        public static double? Covariance(this IEnumerable<double?> source, IEnumerable<double?> other)
        {
            IEnumerable<double> values = source.Coalesce();
            if (values.Any())
                return values.Covariance(other.Coalesce());

            return null;
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Double values to calculate the Covariance of.
        //
        // Returns:
        //     The Covariance of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static double Covariance(this IEnumerable<double> source, IEnumerable<double> other)
        {
            int len = source.Count();

            if (len != other.Count())
                throw new ArgumentException("Collections are not of the same length", "other");

            double avgSource = source.Average();
            double avgOther = other.Average();
            double covariance = 0;
            
            for (int i = 0; i < len; i++)
                covariance += (source.ElementAt(i) - avgSource) * (other.ElementAt(i) - avgOther);

            return covariance / len; 
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of nullable System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Single values to calculate the Covariance of.
        //
        // Returns:
        //     The Covariance of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        public static float? Covariance(this IEnumerable<float?> source, IEnumerable<float?> other)
        {
            IEnumerable<float> values = source.Coalesce();
            if (values.Any())
                return values.Covariance(other.Coalesce());

            return null;
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Single values to calculate the Covariance of.
        //
        // Returns:
        //     The Covariance of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static float Covariance(this IEnumerable<float> source, IEnumerable<float> other)
        {
            return (float)source.Select(x => (double)x).Covariance(other.Select(x => (double)x));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of nullable System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int32values to calculate the Covariance of.
        //
        // Returns:
        //     The Covariance of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static double? Covariance(this IEnumerable<int?> source, IEnumerable<int?> other)
        {
            IEnumerable<int> values = source.Coalesce();
            if (values.Any())
                return values.Covariance(other.Coalesce());

            return null;
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int32 values to calculate the Covariance of.
        //
        // Returns:
        //     The Covariance of the sequence of values.
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
        public static double Covariance(this IEnumerable<int> source, IEnumerable<int> other)
        {
            return source.Select(x => (double)x).Covariance(other.Select(x => (double)x));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of nullable System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int64 values to calculate the Covariance of.
        //
        // Returns:
        //     The Covariance of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static double? Covariance(this IEnumerable<long?> source, IEnumerable<long?> other)
        {
            IEnumerable<long> values = source.Coalesce();
            if (values.Any())
                return values.Covariance(other.Coalesce());

            return null;
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int64 values to calculate the Covariance of.
        //
        // Returns:
        //     The Covariance of the sequence of values.
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
        public static double Covariance(this IEnumerable<long> source, IEnumerable<long> other)
        {
            return source.Select(x => (double)x).Covariance(other.Select(x => (double)x));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of nullable System.Decimal values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Covariance of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Covariance of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        public static decimal? Covariance<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, decimal?> selector)
        {
            return source.Select(selector).Covariance(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of System.Decimal values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values that are used to calculate an Covariance.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Covariance of the sequence of values.
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
        public static decimal Covariance<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, decimal> selector)
        {
            return source.Select(selector).Covariance(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of nullable System.Double values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Covariance of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Covariance of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        public static double? Covariance<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, double?> selector)
        {
            return source.Select(selector).Covariance(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of System.Double values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Covariance of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Covariance of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static double Covariance<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, double> selector)
        {
            return source.Select(selector).Covariance(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of nullable System.Single values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Covariance of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Covariance of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        public static float? Covariance<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, float?> selector)
        {
            return source.Select(selector).Covariance(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of System.Single values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Covariance of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Covariance of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static float Covariance<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, float> selector)
        {
            return source.Select(selector).Covariance(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of nullable System.Int32 values that are
        //     obtained by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Covariance of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Covariance of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static double? Covariance<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, int?> selector)
        {
            return source.Select(selector).Covariance(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of System.Int32 values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Covariance of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Covariance of the sequence of values.
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
        public static double Covariance<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, int> selector)
        {
            return source.Select(selector).Covariance(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of nullable System.Int64 values that are
        //     obtained by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Covariance of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Covariance of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        public static double? Covariance<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, long?> selector)
        {
            return source.Select(selector).Covariance(other.Select(selector));
        }
        //
        // Summary:
        //     Computes the Covariance of a sequence of System.Int64 values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Covariance of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Covariance of the sequence of values.
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
        public static double Covariance<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, long> selector)
        {
            return source.Select(selector).Covariance(other.Select(selector));
        }
    }
}
