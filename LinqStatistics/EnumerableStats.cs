using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        public static IEnumerable<T> AllValues<T>(this IEnumerable<T?> source) where T : struct
        {
            if (source == null)
                throw new ArgumentNullException("source", "The source enumeration cannot be null");
            
            return source.Where(x => x.HasValue).Select(x => (T)x);
        }
    }
}
