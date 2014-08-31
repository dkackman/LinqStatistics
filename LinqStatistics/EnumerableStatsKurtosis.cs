using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
    	
        /// <summary>
        /// Computes the Kurtosis of a sequence of nullable int values
        /// </summary>
        /// <param name="source">A sequence of nullable int values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static double? Kurtosis(this IEnumerable<int?> source)
        {
            IEnumerable<int> values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }

        /// <summary>
        /// Computes the Kurtosis of a sequence of int values
        /// </summary>
        /// <param name="source">A sequence of int values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static double Kurtosis(this IEnumerable<int> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            int n = 0;
            double mean = 0;
            double M2 = 0;
            double M3 = 0;
            double M4 = 0;

            foreach (var x in source)
            {
                int n1 = n;
                n += 1;
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

        /// <summary>
        ///     Computes the Kurtosis of a sequence of int values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate an Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static double Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        ///     Computes the Kurtosis of a sequence of nullable int values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate an Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static double? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Kurtosis();
        }
 	
        /// <summary>
        /// Computes the Kurtosis of a sequence of nullable long values
        /// </summary>
        /// <param name="source">A sequence of nullable long values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static double? Kurtosis(this IEnumerable<long?> source)
        {
            IEnumerable<long> values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }

        /// <summary>
        /// Computes the Kurtosis of a sequence of long values
        /// </summary>
        /// <param name="source">A sequence of long values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static double Kurtosis(this IEnumerable<long> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            int n = 0;
            double mean = 0;
            double M2 = 0;
            double M3 = 0;
            double M4 = 0;

            foreach (var x in source)
            {
                int n1 = n;
                n += 1;
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

        /// <summary>
        ///     Computes the Kurtosis of a sequence of long values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate an Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static double Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        ///     Computes the Kurtosis of a sequence of nullable long values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate an Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static double? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Kurtosis();
        }
 	
        /// <summary>
        /// Computes the Kurtosis of a sequence of nullable decimal values
        /// </summary>
        /// <param name="source">A sequence of nullable decimal values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static decimal? Kurtosis(this IEnumerable<decimal?> source)
        {
            IEnumerable<decimal> values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }

        /// <summary>
        /// Computes the Kurtosis of a sequence of decimal values
        /// </summary>
        /// <param name="source">A sequence of decimal values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static decimal Kurtosis(this IEnumerable<decimal> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            int n = 0;
            decimal mean = 0;
            decimal M2 = 0;
            decimal M3 = 0;
            decimal M4 = 0;

            foreach (var x in source)
            {
                int n1 = n;
                n += 1;
                decimal delta = x - mean;
                decimal delta_n = delta / n;
                decimal delta_n2 = delta_n * delta_n;
                decimal term1 = delta * delta_n * n1;
                mean = mean + delta_n;
                M4 += term1 * delta_n2 * (n * n - 3 * n + 3) + 6 * delta_n2 * M2 - 4 * delta_n * M3;
                M3 += term1 * delta_n * (n - 2) - 3 * delta_n * M2;
                M2 += term1;
            }
            return (n * M4) / (M2 * M2) - 3;
        }

        /// <summary>
        ///     Computes the Kurtosis of a sequence of decimal values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate an Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static decimal Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        ///     Computes the Kurtosis of a sequence of nullable decimal values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate an Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static decimal? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Kurtosis();
        }
 	
        /// <summary>
        /// Computes the Kurtosis of a sequence of nullable float values
        /// </summary>
        /// <param name="source">A sequence of nullable float values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static float? Kurtosis(this IEnumerable<float?> source)
        {
            IEnumerable<float> values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }

        /// <summary>
        /// Computes the Kurtosis of a sequence of float values
        /// </summary>
        /// <param name="source">A sequence of float values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static float Kurtosis(this IEnumerable<float> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            int n = 0;
            float mean = 0;
            float M2 = 0;
            float M3 = 0;
            float M4 = 0;

            foreach (var x in source)
            {
                int n1 = n;
                n += 1;
                float delta = x - mean;
                float delta_n = delta / n;
                float delta_n2 = delta_n * delta_n;
                float term1 = delta * delta_n * n1;
                mean = mean + delta_n;
                M4 += term1 * delta_n2 * (n * n - 3 * n + 3) + 6 * delta_n2 * M2 - 4 * delta_n * M3;
                M3 += term1 * delta_n * (n - 2) - 3 * delta_n * M2;
                M2 += term1;
            }
            return (n * M4) / (M2 * M2) - 3;
        }

        /// <summary>
        ///     Computes the Kurtosis of a sequence of float values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate an Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static float Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        ///     Computes the Kurtosis of a sequence of nullable float values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate an Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static float? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Kurtosis();
        }
 	
        /// <summary>
        /// Computes the Kurtosis of a sequence of nullable double values
        /// </summary>
        /// <param name="source">A sequence of nullable double values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static double? Kurtosis(this IEnumerable<double?> source)
        {
            IEnumerable<double> values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }

        /// <summary>
        /// Computes the Kurtosis of a sequence of double values
        /// </summary>
        /// <param name="source">A sequence of double values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static double Kurtosis(this IEnumerable<double> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            int n = 0;
            double mean = 0;
            double M2 = 0;
            double M3 = 0;
            double M4 = 0;

            foreach (var x in source)
            {
                int n1 = n;
                n += 1;
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

        /// <summary>
        ///     Computes the Kurtosis of a sequence of double values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate an Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static double Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        ///     Computes the Kurtosis of a sequence of nullable double values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate an Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        public static double? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).Kurtosis();
        }
     }
}