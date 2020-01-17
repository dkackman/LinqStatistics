using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        /// <summary>
        /// Calculates the modes of a sequences of elements
        /// </summary>
        /// <typeparam name="T">The type of the elemensts in the source sequence</typeparam>
        /// <param name="source">A sequence of values to calculate the Modes of.</param>
        /// <returns>The modes of a sequence of values</returns>
        public static IEnumerable<T> Modes<T>(this IEnumerable<T?> source) where T : struct
        {
            var values = source.AllValues();
            if (values.Any())
                return values.Modes<T>();

            return Enumerable.Empty<T>();
        }

        /// <summary>
        /// Calculates the modes of a sequences of nullable elements
        /// </summary>
        /// <typeparam name="T">The type of the elemensts in the source sequence</typeparam>
        /// <param name="source">A sequence of values to calculate the Modes of.</param>
        /// <returns>The modes of a sequence of values</returns>
        public static IEnumerable<T> Modes<T>(this IEnumerable<T> source) where T : struct
        {
            return from count in source.CountEach().OrderBy(item => item.RepresentativeValue)
                   where count.Count > 1
                   orderby count.Count descending
                   select count.RepresentativeValue;
        }

        /// <summary>
        /// Calculates the mode of a sequences of elements
        /// </summary>
        /// <typeparam name="T">The type of the elemensts in the source sequence</typeparam>
        /// <param name="source">A sequence of values to calculate the Mode of.</param>
        /// <returns>The mode of a sequence of values</returns>
        public static T? Mode<T>(this IEnumerable<T?> source) where T : struct
        {
            var values = source.AllValues();
            if (values.Any())
                return values.Mode<T>();

            return null;
        }

        /// <summary>
        /// Calculates the Mode of a sequences of elements
        /// </summary>
        /// <typeparam name="T">The type of the elemensts in the source sequence</typeparam>
        /// <param name="source">A sequence of values to calculate the Mode of.</param>
        /// <returns>The Mode of a sequence of values</returns>
        public static T? Mode<T>(this IEnumerable<T> source) where T : struct
        {
            var sortedList = from item in source
                             orderby item
                             select item;

            int count = 0;
            int max = 0;
            T current = default(T);
            T? mode = new T?();

            foreach (T next in sortedList)
            {
                if (!current.Equals(next))
                {
                    current = next;
                    count = 1;
                }
                else
                {
                    count++;
                }

                if (count > max)
                {
                    max = count;
                    mode = current;
                }
            }

            return max > 1 ? mode : null;
        }

        /// <summary>
        ///     Computes the Mode of a sequence of values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TMode">The type of the Mode</typeparam>
        /// <param name="source">A sequence of values to calculate the Mode of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Mode of the sequence of values.</returns>
        public static TMode? Mode<TSource, TMode>(this IEnumerable<TSource> source, Func<TSource, TMode> selector) where TMode : struct
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).Mode<TMode>();
        }

        /// <summary>
        ///     Computes the Mode of a sequence of values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TMode">The type of the Mode</typeparam>
        /// <param name="source">A sequence of values to calculate the Mode of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The Mode of the sequence of values.</returns>
        public static TMode? Mode<TSource, TMode>(this IEnumerable<TSource> source, Func<TSource, TMode?> selector) where TMode : struct
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).Mode<TMode>();
        }
    }
}
