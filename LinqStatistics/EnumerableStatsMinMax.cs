using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
    	
        /// <summary>
        /// Computes the MinMax of a sequence of nullable int values.
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<int>? MinMax(this IEnumerable<int?> source)
        {
            IEnumerable<int> values = source.AllValues();
            if (values.Any())
                return values.MinMax();

            return null;
        }

        /// <summary>
        /// Computes the MinMax of a sequence of int values.
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<int> MinMax(this IEnumerable<int> source)
        {            
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            MinMax<int> minMax = new MinMax<int>();
            minMax.Min = int.MaxValue;
            minMax.Max = int.MinValue;

            var ret = source.Aggregate<int, MinMax<int>>(minMax, (accumulator, i) =>
            {
                accumulator.Min = Math.Min(accumulator.Min, i);
                accumulator.Max = Math.Max(accumulator.Max, i);
                
                return accumulator;
            });

            ret.Range = ret.Max - ret.Min;

            return ret;
        }

        /// <summary>
        ///     Computes the MinMax of a sequence of nullable int values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<int>? MinMax<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).MinMax();
        }

        /// <summary>
        ///     Computes the MinMax of a sequence of int values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<int> MinMax<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).MinMax();
        }
 	
        /// <summary>
        /// Computes the MinMax of a sequence of nullable long values.
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<long>? MinMax(this IEnumerable<long?> source)
        {
            IEnumerable<long> values = source.AllValues();
            if (values.Any())
                return values.MinMax();

            return null;
        }

        /// <summary>
        /// Computes the MinMax of a sequence of long values.
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<long> MinMax(this IEnumerable<long> source)
        {            
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            MinMax<long> minMax = new MinMax<long>();
            minMax.Min = long.MaxValue;
            minMax.Max = long.MinValue;

            var ret = source.Aggregate<long, MinMax<long>>(minMax, (accumulator, i) =>
            {
                accumulator.Min = Math.Min(accumulator.Min, i);
                accumulator.Max = Math.Max(accumulator.Max, i);
                
                return accumulator;
            });

            ret.Range = ret.Max - ret.Min;

            return ret;
        }

        /// <summary>
        ///     Computes the MinMax of a sequence of nullable long values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<long>? MinMax<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).MinMax();
        }

        /// <summary>
        ///     Computes the MinMax of a sequence of long values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<long> MinMax<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).MinMax();
        }
 	
        /// <summary>
        /// Computes the MinMax of a sequence of nullable float values.
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<float>? MinMax(this IEnumerable<float?> source)
        {
            IEnumerable<float> values = source.AllValues();
            if (values.Any())
                return values.MinMax();

            return null;
        }

        /// <summary>
        /// Computes the MinMax of a sequence of float values.
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<float> MinMax(this IEnumerable<float> source)
        {            
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            MinMax<float> minMax = new MinMax<float>();
            minMax.Min = float.MaxValue;
            minMax.Max = float.MinValue;

            var ret = source.Aggregate<float, MinMax<float>>(minMax, (accumulator, i) =>
            {
                accumulator.Min = Math.Min(accumulator.Min, i);
                accumulator.Max = Math.Max(accumulator.Max, i);
                
                return accumulator;
            });

            ret.Range = ret.Max - ret.Min;

            return ret;
        }

        /// <summary>
        ///     Computes the MinMax of a sequence of nullable float values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<float>? MinMax<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).MinMax();
        }

        /// <summary>
        ///     Computes the MinMax of a sequence of float values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<float> MinMax<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).MinMax();
        }
 	
        /// <summary>
        /// Computes the MinMax of a sequence of nullable double values.
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<double>? MinMax(this IEnumerable<double?> source)
        {
            IEnumerable<double> values = source.AllValues();
            if (values.Any())
                return values.MinMax();

            return null;
        }

        /// <summary>
        /// Computes the MinMax of a sequence of double values.
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<double> MinMax(this IEnumerable<double> source)
        {            
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            MinMax<double> minMax = new MinMax<double>();
            minMax.Min = double.MaxValue;
            minMax.Max = double.MinValue;

            var ret = source.Aggregate<double, MinMax<double>>(minMax, (accumulator, i) =>
            {
                accumulator.Min = Math.Min(accumulator.Min, i);
                accumulator.Max = Math.Max(accumulator.Max, i);
                
                return accumulator;
            });

            ret.Range = ret.Max - ret.Min;

            return ret;
        }

        /// <summary>
        ///     Computes the MinMax of a sequence of nullable double values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<double>? MinMax<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).MinMax();
        }

        /// <summary>
        ///     Computes the MinMax of a sequence of double values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<double> MinMax<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).MinMax();
        }
 	
        /// <summary>
        /// Computes the MinMax of a sequence of nullable decimal values.
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<decimal>? MinMax(this IEnumerable<decimal?> source)
        {
            IEnumerable<decimal> values = source.AllValues();
            if (values.Any())
                return values.MinMax();

            return null;
        }

        /// <summary>
        /// Computes the MinMax of a sequence of decimal values.
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<decimal> MinMax(this IEnumerable<decimal> source)
        {            
            if (source == null)
                throw new ArgumentNullException("source");

            if (!source.Any())
                throw new InvalidOperationException("source sequence contains no elements");

            MinMax<decimal> minMax = new MinMax<decimal>();
            minMax.Min = decimal.MaxValue;
            minMax.Max = decimal.MinValue;

            var ret = source.Aggregate<decimal, MinMax<decimal>>(minMax, (accumulator, i) =>
            {
                accumulator.Min = Math.Min(accumulator.Min, i);
                accumulator.Max = Math.Max(accumulator.Max, i);
                
                return accumulator;
            });

            ret.Range = ret.Max - ret.Min;

            return ret;
        }

        /// <summary>
        ///     Computes the MinMax of a sequence of nullable decimal values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<decimal>? MinMax<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).MinMax();
        }

        /// <summary>
        ///     Computes the MinMax of a sequence of decimal values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The MinMax.</returns>
        public static MinMax<decimal> MinMax<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return source.Select(selector).MinMax();
        }
     }
}