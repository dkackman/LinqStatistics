﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        /// <summary>
        /// Counts each unique element in a sequence
        /// </summary>
        /// <typeparam name="T">The type of the sequence</typeparam>
        /// <param name="source">The sequence to count</param>
        /// <param name="comparer">Comparer used to determine equality between elements</param>
        /// <returns>The count of each unique element</returns>
        public static IEnumerable<ItemCount<T>> CountEach<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(comparer);

            return source.GroupBy(t => t, comparer).Select(g => new ItemCount<T>(g.Key, g.Count()));
        }

        /// <summary>
        /// Counts each unique element in a sequence
        /// </summary>
        /// <typeparam name="T">The type of the sequence</typeparam>
        /// <param name="source">The sequence to count</param>
        /// <returns>The count of each unique element</returns>
        public static IEnumerable<ItemCount<T>> CountEach<T>(this IEnumerable<T> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            return source.CountEach(EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Counts each unique element in a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TResult">The type of the element selected</typeparam>
        /// <param name="source">A sequence of values to calculate the unique count of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The count of each unique element</returns>
        public static IEnumerable<ItemCount<TResult>> CountEach<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            return source.Select(selector).CountEach();
        }

        /// <summary>
        /// Counts each unique element in a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TResult">The type of the element selected</typeparam>
        /// <param name="source">A sequence of values to calculate the unique count of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="comparer">Comparer used to determine equality between elements</param>/// 
        /// <returns>The count of each unique element</returns>
        public static IEnumerable<ItemCount<TResult>> CountEach<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, IEqualityComparer<TResult> comparer)
        {
            ArgumentNullException.ThrowIfNull(source);

            ArgumentNullException.ThrowIfNull(selector);

            ArgumentNullException.ThrowIfNull(comparer);

            return source.Select(selector).CountEach(comparer);
        }
    }
}
