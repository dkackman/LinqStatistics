using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
    	
    	/// <summary>
    	/// Computes the Median of a sequence of mullable intSystem.Int32 values, or null if the source sequence is
        ///     empty or contains only values that are null.
    	/// </summary>
    	/// <param name="source">A sequence of nullable int values to calculate the Median of.</param>
    	/// <returns>The Median of the sequence of values.</returns>
        public static double? Median(this IEnumerable<int?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            IEnumerable<int> values = source.AllValues();
            if (values.Any())
                return values.Median();

            return null;
        }

    	/// <summary>
    	/// Computes the Median of a sequence of intSystem.Int32 values.
    	/// </summary>
    	/// <param name="source">A sequence of int values to calculate the Median of.</param>
    	/// <returns>The Median of the sequence of values.</returns>
        public static double Median(this IEnumerable<int> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            var sortedList = from number in source
                             orderby number
                             select (double)number;

            int count = sortedList.Count();
            int itemIndex = count / 2;

            if (count % 2 == 0)
                // Even number of items.
                return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;

            // Odd number of items.
            return sortedList.ElementAt(itemIndex);
        }

        /// <summary>
        ///     Computes the Median of a sequence of nullable intSystem.Int64 values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double? Median<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Median();
        }

        /// <summary>
        ///     Computes the Median of a sequence of intSystem.Int64 values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double Median<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Median();
        }
 	
    	/// <summary>
    	/// Computes the Median of a sequence of mullable longSystem.Int32 values, or null if the source sequence is
        ///     empty or contains only values that are null.
    	/// </summary>
    	/// <param name="source">A sequence of nullable long values to calculate the Median of.</param>
    	/// <returns>The Median of the sequence of values.</returns>
        public static double? Median(this IEnumerable<long?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            IEnumerable<long> values = source.AllValues();
            if (values.Any())
                return values.Median();

            return null;
        }

    	/// <summary>
    	/// Computes the Median of a sequence of longSystem.Int32 values.
    	/// </summary>
    	/// <param name="source">A sequence of long values to calculate the Median of.</param>
    	/// <returns>The Median of the sequence of values.</returns>
        public static double Median(this IEnumerable<long> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            var sortedList = from number in source
                             orderby number
                             select (double)number;

            int count = sortedList.Count();
            int itemIndex = count / 2;

            if (count % 2 == 0)
                // Even number of items.
                return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;

            // Odd number of items.
            return sortedList.ElementAt(itemIndex);
        }

        /// <summary>
        ///     Computes the Median of a sequence of nullable longSystem.Int64 values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double? Median<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Median();
        }

        /// <summary>
        ///     Computes the Median of a sequence of longSystem.Int64 values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double Median<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Median();
        }
 	
    	/// <summary>
    	/// Computes the Median of a sequence of mullable decimalSystem.Int32 values, or null if the source sequence is
        ///     empty or contains only values that are null.
    	/// </summary>
    	/// <param name="source">A sequence of nullable decimal values to calculate the Median of.</param>
    	/// <returns>The Median of the sequence of values.</returns>
        public static decimal? Median(this IEnumerable<decimal?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            IEnumerable<decimal> values = source.AllValues();
            if (values.Any())
                return values.Median();

            return null;
        }

    	/// <summary>
    	/// Computes the Median of a sequence of decimalSystem.Int32 values.
    	/// </summary>
    	/// <param name="source">A sequence of decimal values to calculate the Median of.</param>
    	/// <returns>The Median of the sequence of values.</returns>
        public static decimal Median(this IEnumerable<decimal> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            var sortedList = from number in source
                             orderby number
                             select (decimal)number;

            int count = sortedList.Count();
            int itemIndex = count / 2;

            if (count % 2 == 0)
                // Even number of items.
                return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;

            // Odd number of items.
            return sortedList.ElementAt(itemIndex);
        }

        /// <summary>
        ///     Computes the Median of a sequence of nullable decimalSystem.Int64 values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static decimal? Median<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Median();
        }

        /// <summary>
        ///     Computes the Median of a sequence of decimalSystem.Int64 values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static decimal Median<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Median();
        }
 	
    	/// <summary>
    	/// Computes the Median of a sequence of mullable floatSystem.Int32 values, or null if the source sequence is
        ///     empty or contains only values that are null.
    	/// </summary>
    	/// <param name="source">A sequence of nullable float values to calculate the Median of.</param>
    	/// <returns>The Median of the sequence of values.</returns>
        public static float? Median(this IEnumerable<float?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            IEnumerable<float> values = source.AllValues();
            if (values.Any())
                return values.Median();

            return null;
        }

    	/// <summary>
    	/// Computes the Median of a sequence of floatSystem.Int32 values.
    	/// </summary>
    	/// <param name="source">A sequence of float values to calculate the Median of.</param>
    	/// <returns>The Median of the sequence of values.</returns>
        public static float Median(this IEnumerable<float> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            var sortedList = from number in source
                             orderby number
                             select (float)number;

            int count = sortedList.Count();
            int itemIndex = count / 2;

            if (count % 2 == 0)
                // Even number of items.
                return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;

            // Odd number of items.
            return sortedList.ElementAt(itemIndex);
        }

        /// <summary>
        ///     Computes the Median of a sequence of nullable floatSystem.Int64 values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static float? Median<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Median();
        }

        /// <summary>
        ///     Computes the Median of a sequence of floatSystem.Int64 values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static float Median<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Median();
        }
 	
    	/// <summary>
    	/// Computes the Median of a sequence of mullable doubleSystem.Int32 values, or null if the source sequence is
        ///     empty or contains only values that are null.
    	/// </summary>
    	/// <param name="source">A sequence of nullable double values to calculate the Median of.</param>
    	/// <returns>The Median of the sequence of values.</returns>
        public static double? Median(this IEnumerable<double?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            IEnumerable<double> values = source.AllValues();
            if (values.Any())
                return values.Median();

            return null;
        }

    	/// <summary>
    	/// Computes the Median of a sequence of doubleSystem.Int32 values.
    	/// </summary>
    	/// <param name="source">A sequence of double values to calculate the Median of.</param>
    	/// <returns>The Median of the sequence of values.</returns>
        public static double Median(this IEnumerable<double> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            var sortedList = from number in source
                             orderby number
                             select (double)number;

            int count = sortedList.Count();
            int itemIndex = count / 2;

            if (count % 2 == 0)
                // Even number of items.
                return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;

            // Odd number of items.
            return sortedList.ElementAt(itemIndex);
        }

        /// <summary>
        ///     Computes the Median of a sequence of nullable doubleSystem.Int64 values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double? Median<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Median();
        }

        /// <summary>
        ///     Computes the Median of a sequence of doubleSystem.Int64 values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the Median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Median of the sequence of values.</returns>
        public static double Median<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Median();
        }
     }
}