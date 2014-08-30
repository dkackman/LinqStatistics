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
        //     empty or contains only values that are null.</returns>
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<int?, int?>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            
            IEnumerable<Tuple<int, int>> values = source.AllValues();
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
            if (source == null)
                throw new ArgumentNullException("source");

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
            if (source == null)
                throw new ArgumentNullException("source");

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
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }
 	
        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{long?, long?} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{long?, long?} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.</returns>
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<long?, long?>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            
            IEnumerable<Tuple<long, long>> values = source.AllValues();
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
            if (source == null)
                throw new ArgumentNullException("source");

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
            if (source == null)
                throw new ArgumentNullException("source");

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
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }
 	
        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{float?, float?} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{float?, float?} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.</returns>
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<float?, float?>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            
            IEnumerable<Tuple<float, float>> values = source.AllValues();
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
            if (source == null)
                throw new ArgumentNullException("source");

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
            if (source == null)
                throw new ArgumentNullException("source");

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
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }
 	
        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{double?, double?} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{double?, double?} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.</returns>
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<double?, double?>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            
            IEnumerable<Tuple<double, double>> values = source.AllValues();
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
            if (source == null)
                throw new ArgumentNullException("source");

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
            if (source == null)
                throw new ArgumentNullException("source");

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
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }
 	
        /// <summary>
        /// Computes the LeastSquares of a sequence of Tuple{decimal?, decimal?} values.
        /// </summary>
        /// <param name="source">A sequence of Tuple{decimal?, decimal?} values to calculate the LeastSquares of.</param>
        /// <returns> The LeastSquares of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.</returns>
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<decimal?, decimal?>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            
            IEnumerable<Tuple<decimal, decimal>> values = source.AllValues();
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
            if (source == null)
                throw new ArgumentNullException("source");

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
            if (source == null)
                throw new ArgumentNullException("source");

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
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }
     }
}