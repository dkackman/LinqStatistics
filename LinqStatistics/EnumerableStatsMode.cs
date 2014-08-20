using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        public static IEnumerable<T> Modes<T>(this IEnumerable<T?> source) where T : struct
        {
            IEnumerable<T> values = source.AllValues();
            if (values.Any())
                return values.Modes<T>();

            return Enumerable.Empty<T>();
        }

        public static IEnumerable<T> Modes<T>(this IEnumerable<T> source) where T : struct
        {
            return from count in source.CountEach()
                   where count.Count > 1
                   orderby count.Count descending
                   select count.RepresentativeValue;
        }

        public static T? Mode<T>(this IEnumerable<T?> source) where T : struct
        {
            IEnumerable<T> values = source.AllValues();
            if (values.Any())
                return values.Mode<T>();

            return null;
        }

        public static T? Mode<T>(this IEnumerable<T> source) where T : struct
        {
            var sortedList = from number in source
                             orderby number
                             select number;

            int count = 0;
            int max = 0;
            T current = default(T);
            T? mode = new T?();

            foreach (T next in sortedList)
            {
                if (current.Equals(next) == false)
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

            if (max > 1)
                return mode;

            return null;
        }

        public static TMode? Mode<TSource, TMode>(this IEnumerable<TSource> source, Func<TSource, TMode> selector) where TMode : struct
        {
            return source.Select(selector).Mode<TMode>();
        }

        public static TMode? Mode<TSource, TMode>(this IEnumerable<TSource> source, Func<TSource, TMode?> selector) where TMode : struct
        {
            return source.Select(selector).Mode<TMode>();
        }
    }
}
