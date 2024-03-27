using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LinqStatistics
{
    /// <summary>
    /// Static class with statistical extension methods for <see cref="IEnumerable{T}"/>
    /// </summary>
    public static partial class EnumerableStats
    {
        /// <summary>
        /// Computes the Sum of a sequence of nullable BigInteger values.
        /// </summary>
        /// <param name="source">A sequence of nullable BigInteger values to calculate the Sum of.</param>
        /// <returns>       
        ///     The Sum of the sequence of values, or null if the source sequence is
        ///     empty or contains only values that are null.
        /// </returns>
        public static BigInteger? Sum(this IEnumerable<BigInteger?> source)
        {
            var values = source.AllValues();
            if (values.Any())
            {
                BigInteger sum = 0;
                foreach (var v in values)
                {
                    sum += v;
                }
                return sum;
            }

            return null;
        }

        /// <summary>
        /// Computes the Sum of a sequence of BigInteger values.
        /// </summary>
        /// <param name="source">A sequence of BigInteger values to calculate the Sum of.</param>
        /// <returns>       
        ///     The Sum of the sequence of values.
        /// </returns>
        public static BigInteger Sum(this IEnumerable<BigInteger> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            BigInteger sum = 0;
            foreach (var v in source)
            {
                sum += v;
            }
            return sum;
        }

        /// <summary>
        /// Computes the Sum of a sequence of nullable BigInteger values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>       
        ///     The Sum of the sequence of values.
        /// </returns>
        public static BigInteger? SumNaN<TSource>(this IEnumerable<TSource> source, Func<TSource, BigInteger?> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).Sum();
        }

        /// <summary>
        /// Computes the Sum of a sequence of BigInteger values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence of elements.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>       
        ///     The Sum of the sequence of values.
        /// </returns>
        public static BigInteger Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, BigInteger> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).Sum();
        }
    }
}
