﻿//
// THIS FILE IS AUTOGENERATED - DO NOT EDIT
// In order to make changes make sure to edit the t4 template file (*.tt)
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {

        /// <summary>
        /// Computes the sample Kurtosis of a sequence of nullable int values
        /// </summary>
        /// <param name="source">A sequence of nullable int values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static double? Kurtosis(this IEnumerable<int?> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }

        /// <summary>
        /// Computes the sample Kurtosis of a sequence of int values
        /// </summary>
        /// <param name="source">A sequence of int values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static double Kurtosis(this IEnumerable<int> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            var mean = (double)source.Average();

            long n = 0;
            var meanv = 0.0;
            var M2 = 0.0;
            var M4 = 0.0;

            checked
            {
                foreach (var x in source)
                {
                    n++;

                    var delta = (double)x - meanv;
                    meanv += delta / n;
                    M2 += delta * ((double)x - meanv);
                    M4 += Math.Pow((double)x - mean, 4);
                }
            }

            if (n < 4)
                throw new InvalidOperationException("Source must have at least 4 elements");

            var s = Math.Sqrt((double)(M2 / (n - 1))); // stdev

            double term1 = (n * (n + 1.0)) / ((n - 1.0) * (n - 2.0) * (n - 3.0));
            double term2 = M4 / Math.Pow(s, 4);
            double term3 = (3 * Math.Pow(n - 1, 2)) / ((n - 2.0) * (n - 3.0));

            return (double)(term1 * term2 - term3);
        }

        /// <summary>
        ///     Computes the sample Kurtosis of a sequence of int values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static double Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        ///     Computes the sample Kurtosis of a sequence of nullable int values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static double? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        /// Computes the sample Kurtosis of a sequence of nullable long values
        /// </summary>
        /// <param name="source">A sequence of nullable long values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static double? Kurtosis(this IEnumerable<long?> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }

        /// <summary>
        /// Computes the sample Kurtosis of a sequence of long values
        /// </summary>
        /// <param name="source">A sequence of long values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static double Kurtosis(this IEnumerable<long> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            var mean = (double)source.Average();

            long n = 0;
            var meanv = 0.0;
            var M2 = 0.0;
            var M4 = 0.0;

            checked
            {
                foreach (var x in source)
                {
                    n++;

                    var delta = (double)x - meanv;
                    meanv += delta / n;
                    M2 += delta * ((double)x - meanv);
                    M4 += Math.Pow((double)x - mean, 4);
                }
            }

            if (n < 4)
                throw new InvalidOperationException("Source must have at least 4 elements");

            var s = Math.Sqrt((double)(M2 / (n - 1))); // stdev

            double term1 = (n * (n + 1.0)) / ((n - 1.0) * (n - 2.0) * (n - 3.0));
            double term2 = M4 / Math.Pow(s, 4);
            double term3 = (3 * Math.Pow(n - 1, 2)) / ((n - 2.0) * (n - 3.0));

            return (double)(term1 * term2 - term3);
        }

        /// <summary>
        ///     Computes the sample Kurtosis of a sequence of long values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static double Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        ///     Computes the sample Kurtosis of a sequence of nullable long values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static double? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        /// Computes the sample Kurtosis of a sequence of nullable decimal values
        /// </summary>
        /// <param name="source">A sequence of nullable decimal values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static decimal? Kurtosis(this IEnumerable<decimal?> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }

        /// <summary>
        /// Computes the sample Kurtosis of a sequence of decimal values
        /// </summary>
        /// <param name="source">A sequence of decimal values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static decimal Kurtosis(this IEnumerable<decimal> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            var mean = (double)source.Average();

            long n = 0;
            var meanv = 0.0;
            var M2 = 0.0;
            var M4 = 0.0;

            checked
            {
                foreach (var x in source)
                {
                    n++;

                    var delta = (double)x - meanv;
                    meanv += delta / n;
                    M2 += delta * ((double)x - meanv);
                    M4 += Math.Pow((double)x - mean, 4);
                }
            }

            if (n < 4)
                throw new InvalidOperationException("Source must have at least 4 elements");

            var s = Math.Sqrt((double)(M2 / (n - 1))); // stdev

            double term1 = (n * (n + 1.0)) / ((n - 1.0) * (n - 2.0) * (n - 3.0));
            double term2 = M4 / Math.Pow(s, 4);
            double term3 = (3 * Math.Pow(n - 1, 2)) / ((n - 2.0) * (n - 3.0));

            return (decimal)(term1 * term2 - term3);
        }

        /// <summary>
        ///     Computes the sample Kurtosis of a sequence of decimal values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static decimal Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        ///     Computes the sample Kurtosis of a sequence of nullable decimal values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static decimal? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        /// Computes the sample Kurtosis of a sequence of nullable float values
        /// </summary>
        /// <param name="source">A sequence of nullable float values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static float? Kurtosis(this IEnumerable<float?> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }

        /// <summary>
        /// Computes the sample Kurtosis of a sequence of float values
        /// </summary>
        /// <param name="source">A sequence of float values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static float Kurtosis(this IEnumerable<float> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            var mean = (double)source.Average();

            long n = 0;
            var meanv = 0.0;
            var M2 = 0.0;
            var M4 = 0.0;

            checked
            {
                foreach (var x in source)
                {
                    n++;

                    var delta = (double)x - meanv;
                    meanv += delta / n;
                    M2 += delta * ((double)x - meanv);
                    M4 += Math.Pow((double)x - mean, 4);
                }
            }

            if (n < 4)
                throw new InvalidOperationException("Source must have at least 4 elements");

            var s = Math.Sqrt((double)(M2 / (n - 1))); // stdev

            double term1 = (n * (n + 1.0)) / ((n - 1.0) * (n - 2.0) * (n - 3.0));
            double term2 = M4 / Math.Pow(s, 4);
            double term3 = (3 * Math.Pow(n - 1, 2)) / ((n - 2.0) * (n - 3.0));

            return (float)(term1 * term2 - term3);
        }

        /// <summary>
        ///     Computes the sample Kurtosis of a sequence of float values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static float Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        ///     Computes the sample Kurtosis of a sequence of nullable float values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static float? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        /// Computes the sample Kurtosis of a sequence of nullable double values
        /// </summary>
        /// <param name="source">A sequence of nullable double values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static double? Kurtosis(this IEnumerable<double?> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.Kurtosis();

            return null;
        }

        /// <summary>
        /// Computes the sample Kurtosis of a sequence of double values
        /// </summary>
        /// <param name="source">A sequence of double values to calculate the Kurtosis of.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static double Kurtosis(this IEnumerable<double> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            var mean = (double)source.Average();

            long n = 0;
            var meanv = 0.0;
            var M2 = 0.0;
            var M4 = 0.0;

            checked
            {
                foreach (var x in source)
                {
                    n++;

                    var delta = (double)x - meanv;
                    meanv += delta / n;
                    M2 += delta * ((double)x - meanv);
                    M4 += Math.Pow((double)x - mean, 4);
                }
            }

            if (n < 4)
                throw new InvalidOperationException("Source must have at least 4 elements");

            var s = Math.Sqrt((double)(M2 / (n - 1))); // stdev

            double term1 = (n * (n + 1.0)) / ((n - 1.0) * (n - 2.0) * (n - 3.0));
            double term2 = M4 / Math.Pow(s, 4);
            double term3 = (3 * Math.Pow(n - 1, 2)) / ((n - 2.0) * (n - 3.0));

            return (double)(term1 * term2 - term3);
        }

        /// <summary>
        ///     Computes the sample Kurtosis of a sequence of double values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static double Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).Kurtosis();
        }

        /// <summary>
        ///     Computes the sample Kurtosis of a sequence of nullable double values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Kurtosis</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Kurtosis of the sequence of values.</returns>
        /// <remarks>![equation](~/images/kurtosis.gif)</remarks>
        public static double? Kurtosis<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).Kurtosis();
        }
    }
}
