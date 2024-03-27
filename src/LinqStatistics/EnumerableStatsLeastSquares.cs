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
        /// Computes the LeastSquares of a sequence of Tuple{int?, int?} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{int?, int?} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values, or null if the source sequence is
        ///     empty or contains only values that are null.</returns>
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<int?, int?>> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }

        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{int, int} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{int, int} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values.</returns>
        public static LeastSquares LeastSquares(this IEnumerable<Tuple<int, int>> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            long n = 0;
            var sumX = 0.0;
            var sumY = 0.0;
            var sumXX = 0.0;
            var sumYY = 0.0;
            var sumXY = 0.0;

            checked
            { 
                foreach (var tuple in source)
                {
                    n++;
                    sumX += (double)tuple.Item1;
                    sumY += (double)tuple.Item2;
                    sumXX += (double)(tuple.Item1 * tuple.Item1);
                    sumYY += (double)(tuple.Item2 * tuple.Item2);
                    sumXY += (double)(tuple.Item1 * tuple.Item2);
                }
            }

            if (n < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");
            
            var sumXSquared = sumX * sumX;
            double denominator = n * sumXX - sumXSquared;
            if (denominator == 0.0)
            {
                return LinqStatistics.LeastSquares.Empty;
            }

            double b = (-sumX * sumXY + sumXX * sumY) / denominator;
            double m = (-sumX * sumY + n * sumXY) / denominator;
            double r = (sumXY - sumX * sumY / n) / Math.Sqrt((sumXX - sumXSquared / n) * (sumYY - (sumY * sumY) / n));

            return new LeastSquares(m, b, r * r);
        }

        /// <summary>
        ///     Computes the LeastSquares of a sequence of Tuple{int?, int?} values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the LeastSquares of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The LeastSquares of the sequence of values.</returns>
        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<int?, int?>> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).LeastSquares();
        }

        /// <summary>
        ///     Computes the LeastSquares of a sequence of Tuple{int, int} values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the LeastSquares of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The LeastSquares of the sequence of values.</returns>
        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<int, int>> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).LeastSquares();
        }
 	
        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{long?, long?} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{long?, long?} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values, or null if the source sequence is
        ///     empty or contains only values that are null.</returns>
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<long?, long?>> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }

        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{long, long} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{long, long} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values.</returns>
        public static LeastSquares LeastSquares(this IEnumerable<Tuple<long, long>> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            long n = 0;
            var sumX = 0.0;
            var sumY = 0.0;
            var sumXX = 0.0;
            var sumYY = 0.0;
            var sumXY = 0.0;

            checked
            { 
                foreach (var tuple in source)
                {
                    n++;
                    sumX += (double)tuple.Item1;
                    sumY += (double)tuple.Item2;
                    sumXX += (double)(tuple.Item1 * tuple.Item1);
                    sumYY += (double)(tuple.Item2 * tuple.Item2);
                    sumXY += (double)(tuple.Item1 * tuple.Item2);
                }
            }

            if (n < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");
            
            var sumXSquared = sumX * sumX;
            double denominator = n * sumXX - sumXSquared;
            if (denominator == 0.0)
            {
                return LinqStatistics.LeastSquares.Empty;
            }

            double b = (-sumX * sumXY + sumXX * sumY) / denominator;
            double m = (-sumX * sumY + n * sumXY) / denominator;
            double r = (sumXY - sumX * sumY / n) / Math.Sqrt((sumXX - sumXSquared / n) * (sumYY - (sumY * sumY) / n));

            return new LeastSquares(m, b, r * r);
        }

        /// <summary>
        ///     Computes the LeastSquares of a sequence of Tuple{long?, long?} values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the LeastSquares of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The LeastSquares of the sequence of values.</returns>
        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<long?, long?>> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).LeastSquares();
        }

        /// <summary>
        ///     Computes the LeastSquares of a sequence of Tuple{long, long} values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the LeastSquares of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The LeastSquares of the sequence of values.</returns>
        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<long, long>> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).LeastSquares();
        }
 	
        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{float?, float?} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{float?, float?} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values, or null if the source sequence is
        ///     empty or contains only values that are null.</returns>
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<float?, float?>> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }

        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{float, float} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{float, float} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values.</returns>
        public static LeastSquares LeastSquares(this IEnumerable<Tuple<float, float>> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            long n = 0;
            var sumX = 0.0;
            var sumY = 0.0;
            var sumXX = 0.0;
            var sumYY = 0.0;
            var sumXY = 0.0;

            checked
            { 
                foreach (var tuple in source)
                {
                    n++;
                    sumX += (double)tuple.Item1;
                    sumY += (double)tuple.Item2;
                    sumXX += (double)(tuple.Item1 * tuple.Item1);
                    sumYY += (double)(tuple.Item2 * tuple.Item2);
                    sumXY += (double)(tuple.Item1 * tuple.Item2);
                }
            }

            if (n < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");
            
            var sumXSquared = sumX * sumX;
            double denominator = n * sumXX - sumXSquared;
            if (denominator == 0.0)
            {
                return LinqStatistics.LeastSquares.Empty;
            }

            double b = (-sumX * sumXY + sumXX * sumY) / denominator;
            double m = (-sumX * sumY + n * sumXY) / denominator;
            double r = (sumXY - sumX * sumY / n) / Math.Sqrt((sumXX - sumXSquared / n) * (sumYY - (sumY * sumY) / n));

            return new LeastSquares(m, b, r * r);
        }

        /// <summary>
        ///     Computes the LeastSquares of a sequence of Tuple{float?, float?} values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the LeastSquares of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The LeastSquares of the sequence of values.</returns>
        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<float?, float?>> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).LeastSquares();
        }

        /// <summary>
        ///     Computes the LeastSquares of a sequence of Tuple{float, float} values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the LeastSquares of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The LeastSquares of the sequence of values.</returns>
        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<float, float>> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).LeastSquares();
        }
 	
        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{double?, double?} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{double?, double?} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values, or null if the source sequence is
        ///     empty or contains only values that are null.</returns>
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<double?, double?>> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }

        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{double, double} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{double, double} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values.</returns>
        public static LeastSquares LeastSquares(this IEnumerable<Tuple<double, double>> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            long n = 0;
            var sumX = 0.0;
            var sumY = 0.0;
            var sumXX = 0.0;
            var sumYY = 0.0;
            var sumXY = 0.0;

            checked
            { 
                foreach (var tuple in source)
                {
                    n++;
                    sumX += (double)tuple.Item1;
                    sumY += (double)tuple.Item2;
                    sumXX += (double)(tuple.Item1 * tuple.Item1);
                    sumYY += (double)(tuple.Item2 * tuple.Item2);
                    sumXY += (double)(tuple.Item1 * tuple.Item2);
                }
            }

            if (n < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");
            
            var sumXSquared = sumX * sumX;
            double denominator = n * sumXX - sumXSquared;
            if (denominator == 0.0)
            {
                return LinqStatistics.LeastSquares.Empty;
            }

            double b = (-sumX * sumXY + sumXX * sumY) / denominator;
            double m = (-sumX * sumY + n * sumXY) / denominator;
            double r = (sumXY - sumX * sumY / n) / Math.Sqrt((sumXX - sumXSquared / n) * (sumYY - (sumY * sumY) / n));

            return new LeastSquares(m, b, r * r);
        }

        /// <summary>
        ///     Computes the LeastSquares of a sequence of Tuple{double?, double?} values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the LeastSquares of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The LeastSquares of the sequence of values.</returns>
        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<double?, double?>> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).LeastSquares();
        }

        /// <summary>
        ///     Computes the LeastSquares of a sequence of Tuple{double, double} values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the LeastSquares of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The LeastSquares of the sequence of values.</returns>
        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<double, double>> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).LeastSquares();
        }
 	
        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{decimal?, decimal?} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{decimal?, decimal?} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values, or null if the source sequence is
        ///     empty or contains only values that are null.</returns>
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<decimal?, decimal?>> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }

        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{decimal, decimal} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{decimal, decimal} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values.</returns>
        public static LeastSquares LeastSquares(this IEnumerable<Tuple<decimal, decimal>> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            long n = 0;
            var sumX = 0.0;
            var sumY = 0.0;
            var sumXX = 0.0;
            var sumYY = 0.0;
            var sumXY = 0.0;

            checked
            { 
                foreach (var tuple in source)
                {
                    n++;
                    sumX += (double)tuple.Item1;
                    sumY += (double)tuple.Item2;
                    sumXX += (double)(tuple.Item1 * tuple.Item1);
                    sumYY += (double)(tuple.Item2 * tuple.Item2);
                    sumXY += (double)(tuple.Item1 * tuple.Item2);
                }
            }

            if (n < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");
            
            var sumXSquared = sumX * sumX;
            double denominator = n * sumXX - sumXSquared;
            if (denominator == 0.0)
            {
                return LinqStatistics.LeastSquares.Empty;
            }

            double b = (-sumX * sumXY + sumXX * sumY) / denominator;
            double m = (-sumX * sumY + n * sumXY) / denominator;
            double r = (sumXY - sumX * sumY / n) / Math.Sqrt((sumXX - sumXSquared / n) * (sumYY - (sumY * sumY) / n));

            return new LeastSquares(m, b, r * r);
        }

        /// <summary>
        ///     Computes the LeastSquares of a sequence of Tuple{decimal?, decimal?} values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the LeastSquares of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The LeastSquares of the sequence of values.</returns>
        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<decimal?, decimal?>> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).LeastSquares();
        }

        /// <summary>
        ///     Computes the LeastSquares of a sequence of Tuple{decimal, decimal} values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the LeastSquares of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The LeastSquares of the sequence of values.</returns>
        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<decimal, decimal>> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).LeastSquares();
        }
 	
        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{Int128?, Int128?} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{Int128?, Int128?} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values, or null if the source sequence is
        ///     empty or contains only values that are null.</returns>
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<Int128?, Int128?>> source)
        {
            var values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }

        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{Int128, Int128} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{Int128, Int128} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values.</returns>
        public static LeastSquares LeastSquares(this IEnumerable<Tuple<Int128, Int128>> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            long n = 0;
            var sumX = 0.0;
            var sumY = 0.0;
            var sumXX = 0.0;
            var sumYY = 0.0;
            var sumXY = 0.0;

            checked
            { 
                foreach (var tuple in source)
                {
                    n++;
                    sumX += (double)tuple.Item1;
                    sumY += (double)tuple.Item2;
                    sumXX += (double)(tuple.Item1 * tuple.Item1);
                    sumYY += (double)(tuple.Item2 * tuple.Item2);
                    sumXY += (double)(tuple.Item1 * tuple.Item2);
                }
            }

            if (n < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");
            
            var sumXSquared = sumX * sumX;
            double denominator = n * sumXX - sumXSquared;
            if (denominator == 0.0)
            {
                return LinqStatistics.LeastSquares.Empty;
            }

            double b = (-sumX * sumXY + sumXX * sumY) / denominator;
            double m = (-sumX * sumY + n * sumXY) / denominator;
            double r = (sumXY - sumX * sumY / n) / Math.Sqrt((sumXX - sumXSquared / n) * (sumYY - (sumY * sumY) / n));

            return new LeastSquares(m, b, r * r);
        }

        /// <summary>
        ///     Computes the LeastSquares of a sequence of Tuple{Int128?, Int128?} values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the LeastSquares of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The LeastSquares of the sequence of values.</returns>
        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<Int128?, Int128?>> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).LeastSquares();
        }

        /// <summary>
        ///     Computes the LeastSquares of a sequence of Tuple{Int128, Int128} values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to calculate the LeastSquares of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The LeastSquares of the sequence of values.</returns>
        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<Int128, Int128>> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).LeastSquares();
        }
     }
}