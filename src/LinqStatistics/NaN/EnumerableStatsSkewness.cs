﻿//
// THIS FILE IS AUTOGENERATED - DO NOT EDIT
// In order to make changes make sure to edit the t4 template file (*.tt)
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics.NaN
{
    public static partial class EnumerableStats
    {
    	
        /// <summary>
        /// Computes the sample Skewness of a sequence of nullable int values
        /// </summary>
        /// <param name="source">A sequence of nullable int values to calculate the Skewness of.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static double? SkewnessNaN(this IEnumerable<int?> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.SkewnessNaN();

            return null;
        }

        /// <summary>
        /// Computes the sample Skewness of a sequence of int values
        /// </summary>
        /// <param name="source">A sequence of int values to calculate the Skewness of.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static double SkewnessNaN(this IEnumerable<int> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            double mean = (double)source.AverageNaN();
            if (double.IsNaN(mean))
                return double.NaN;

            double s = (double)source.StandardDeviationNaN();
            double M3 = 0;
            long n = 0;

            checked
            { 
                foreach (var x in source)
                {
                    n++;
                    M3 += Math.Pow(((double)x - mean) / s, 3.0);
                }
            }

            if (n < 3)
                return double.NaN;

            return (double)((M3 * n) / ((n - 1) * (n - 2)));
        }

        /// <summary>
        ///     Computes the sample Skewness of a sequence of int values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Skewness</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static double SkewnessNaN<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).SkewnessNaN();
        }

        /// <summary>
        ///     Computes the sample Skewness of a sequence of nullable int values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Skewness</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static double? SkewnessNaN<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).SkewnessNaN();
        }
 	
        /// <summary>
        /// Computes the sample Skewness of a sequence of nullable long values
        /// </summary>
        /// <param name="source">A sequence of nullable long values to calculate the Skewness of.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static double? SkewnessNaN(this IEnumerable<long?> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.SkewnessNaN();

            return null;
        }

        /// <summary>
        /// Computes the sample Skewness of a sequence of long values
        /// </summary>
        /// <param name="source">A sequence of long values to calculate the Skewness of.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static double SkewnessNaN(this IEnumerable<long> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            double mean = (double)source.AverageNaN();
            if (double.IsNaN(mean))
                return double.NaN;

            double s = (double)source.StandardDeviationNaN();
            double M3 = 0;
            long n = 0;

            checked
            { 
                foreach (var x in source)
                {
                    n++;
                    M3 += Math.Pow(((double)x - mean) / s, 3.0);
                }
            }

            if (n < 3)
                return double.NaN;

            return (double)((M3 * n) / ((n - 1) * (n - 2)));
        }

        /// <summary>
        ///     Computes the sample Skewness of a sequence of long values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Skewness</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static double SkewnessNaN<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).SkewnessNaN();
        }

        /// <summary>
        ///     Computes the sample Skewness of a sequence of nullable long values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Skewness</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static double? SkewnessNaN<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).SkewnessNaN();
        }
 	
        /// <summary>
        /// Computes the sample Skewness of a sequence of nullable float values
        /// </summary>
        /// <param name="source">A sequence of nullable float values to calculate the Skewness of.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static float? SkewnessNaN(this IEnumerable<float?> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.SkewnessNaN();

            return null;
        }

        /// <summary>
        /// Computes the sample Skewness of a sequence of float values
        /// </summary>
        /// <param name="source">A sequence of float values to calculate the Skewness of.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static float SkewnessNaN(this IEnumerable<float> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            double mean = (double)source.AverageNaN();
            if (double.IsNaN(mean))
                return float.NaN;

            double s = (double)source.StandardDeviationNaN();
            double M3 = 0;
            long n = 0;

            checked
            { 
                foreach (var x in source)
                {
                    n++;
                    M3 += Math.Pow(((double)x - mean) / s, 3.0);
                }
            }

            if (n < 3)
                return float.NaN;

            return (float)((M3 * n) / ((n - 1) * (n - 2)));
        }

        /// <summary>
        ///     Computes the sample Skewness of a sequence of float values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Skewness</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static float SkewnessNaN<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).SkewnessNaN();
        }

        /// <summary>
        ///     Computes the sample Skewness of a sequence of nullable float values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Skewness</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static float? SkewnessNaN<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).SkewnessNaN();
        }
 	
        /// <summary>
        /// Computes the sample Skewness of a sequence of nullable double values
        /// </summary>
        /// <param name="source">A sequence of nullable double values to calculate the Skewness of.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static double? SkewnessNaN(this IEnumerable<double?> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.SkewnessNaN();

            return null;
        }

        /// <summary>
        /// Computes the sample Skewness of a sequence of double values
        /// </summary>
        /// <param name="source">A sequence of double values to calculate the Skewness of.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static double SkewnessNaN(this IEnumerable<double> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            double mean = (double)source.AverageNaN();
            if (double.IsNaN(mean))
                return double.NaN;

            double s = (double)source.StandardDeviationNaN();
            double M3 = 0;
            long n = 0;

            checked
            { 
                foreach (var x in source)
                {
                    n++;
                    M3 += Math.Pow(((double)x - mean) / s, 3.0);
                }
            }

            if (n < 3)
                return double.NaN;

            return (double)((M3 * n) / ((n - 1) * (n - 2)));
        }

        /// <summary>
        ///     Computes the sample Skewness of a sequence of double values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Skewness</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static double SkewnessNaN<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).SkewnessNaN();
        }

        /// <summary>
        ///     Computes the sample Skewness of a sequence of nullable double values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a Skewness</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Skewness of the sequence of values.</returns>
        public static double? SkewnessNaN<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).SkewnessNaN();
        }
     }
}
