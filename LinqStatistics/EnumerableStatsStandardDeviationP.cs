using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of nullable System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Decimal values to calculate the StandardDeviationP of.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        public static decimal? StandardDeviationP(this IEnumerable<decimal?> source)
        {
            IEnumerable<decimal> values = source.Coalesce();
            if (values.Any())
                return values.StandardDeviationP();
            
            return null;
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Decimal values to calculate the StandardDeviationP of.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values.
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
        public static decimal StandardDeviationP(this IEnumerable<decimal> source)
        {
            return (decimal)source.Select(x => (double)x).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of nullable System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Double values to calculate the StandardDeviationP of.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        public static double? StandardDeviationP(this IEnumerable<double?> source)
        {
            IEnumerable<double> values = source.Coalesce();
            if (values.Any())
                return values.StandardDeviationP();

            return null;
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Double values to calculate the StandardDeviationP of.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static double StandardDeviationP(this IEnumerable<double> source)
        {
            return Math.Sqrt(source.VarianceP());
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of nullable System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Single values to calculate the StandardDeviationP of.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        public static float? StandardDeviationP(this IEnumerable<float?> source)
        {
            IEnumerable<float> values = source.Coalesce();
            if (values.Any())
                return values.StandardDeviationP();

            return null;
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Single values to calculate the StandardDeviationP of.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static float StandardDeviationP(this IEnumerable<float> source)
        {
            return (float)source.Select(x => (double)x).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of nullable System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int32values to calculate the StandardDeviationP of.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static double? StandardDeviationP(this IEnumerable<int?> source)
        {
            IEnumerable<int> values = source.Coalesce();
            if (values.Any())
                return values.StandardDeviationP();

            return null;
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int32 values to calculate the StandardDeviationP of.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values.
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
        public static double StandardDeviationP(this IEnumerable<int> source)
        {
            return source.Select(x => (double)x).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of nullable System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int64 values to calculate the StandardDeviationP of.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static double? StandardDeviationP(this IEnumerable<long?> source)
        {
            IEnumerable<long> values = source.Coalesce();
            if (values.Any())
                return values.StandardDeviationP();

            return null;
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int64 values to calculate the StandardDeviationP of.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values.
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
        public static double StandardDeviationP(this IEnumerable<long> source)
        {
            return source.Select(x => (double)x).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of nullable System.Decimal values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the StandardDeviationP of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        public static decimal? StandardDeviationP<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            return source.Select(selector).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of System.Decimal values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values that are used to calculate an StandardDeviationP.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values.
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
        public static decimal StandardDeviationP<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            return source.Select(selector).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of nullable System.Double values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the StandardDeviationP of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        public static double? StandardDeviationP<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            return source.Select(selector).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of System.Double values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the StandardDeviationP of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static double StandardDeviationP<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            return source.Select(selector).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of nullable System.Single values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the StandardDeviationP of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        public static float? StandardDeviationP<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            return source.Select(selector).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of System.Single values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the StandardDeviationP of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static float StandardDeviationP<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            return source.Select(selector).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of nullable System.Int32 values that are
        //     obtained by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the StandardDeviationP of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        //
        //   System.OverflowException:
        //     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        public static double? StandardDeviationP<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            return source.Select(selector).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of System.Int32 values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the StandardDeviationP of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values.
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
        public static double StandardDeviationP<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            return source.Select(selector).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of nullable System.Int64 values that are
        //     obtained by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the StandardDeviationP of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        public static double? StandardDeviationP<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            return source.Select(selector).StandardDeviationP();
        }
        //
        // Summary:
        //     Computes the StandardDeviationP of a sequence of System.Int64 values that are obtained
        //     by invoking a transform function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the StandardDeviationP of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The StandardDeviationP of the sequence of values.
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
        public static double StandardDeviationP<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            return source.Select(selector).StandardDeviationP();
        }
    }
}
