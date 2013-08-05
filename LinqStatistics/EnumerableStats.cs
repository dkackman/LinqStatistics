using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
        public static IEnumerable<T> Coalesce<T>(this IEnumerable<T?> source) where T : struct
        {
            Debug.Assert(source != null);
            return source.Where(x => x.HasValue).Select(x => (T)x);
        }
    }
}
