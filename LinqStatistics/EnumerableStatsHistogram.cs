using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        //
        // Summary:
        //     Computes the Histogram of a sequence of values.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Histogram of.
        //
        // Returns:
        //     The Histogram of the sequence of values.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source is null.
        //
        //   System.InvalidOperationException:
        //     source contains no elements.
        public static IEnumerable<Bin<T>> Histogram<T>(this IEnumerable<T> source)
        {
            return from t in source
                   group t by t into g
                   orderby g.Key
                   select new Bin<T>(g.Key, g.Count());
                   

            //return source.GroupBy(i => i)
            //    .Select(g => new
            //    {
            //        Item = g.Key,
            //        Count = g.Count()
            //    })
            //    .OrderBy(g => g.Item)
            //    .Select(g => new Bin<T>(g.Item, g.Count));
        }

        //
        // Summary:
        //     Computes the Histogram of a sequence of nullable values that
        //     are obtained by invoking a transform function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the Histogram of.
        //
        //   selector:
        //     A transform function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The Histogram of the sequence of values, or null if the source sequence is
        //     empty or contains only values that are null.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     source or selector is null.
        public static IEnumerable<Bin<T>> Histogram<TSource, T>(this IEnumerable<TSource> source, Func<TSource, T> selector)
        {
            return source.Select(selector).Histogram();
        }
    }
}