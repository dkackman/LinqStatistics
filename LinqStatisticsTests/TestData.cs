using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqStatistics.UnitTests
{
    static class TestData
    {
        public static IEnumerable<int> GetInts()
        {
            return new int[] { 2, 3, 4, 6 };
        }

        public static IEnumerable<int?> GetNullableInts()
        {
            return new int?[] { 2, null, 3, 4, 6 };
        }

        public static IEnumerable<double> GetDoubles()
        {
            return new double[] { 2.1, 3.5, 4.6, 6.9 };
        }

        public static IEnumerable<double?> GetNullableDoubles()
        {
            return new double?[] { 2.1, 3.5, null, 4.6, 6.9 };
        }

        public static IEnumerable<float> GetFloats()
        {
            return new float[] { 2.1f, 3.5f, 4.6f, 6.9f };
        }

        public static IEnumerable<long> GetLongsEven()
        {
            return new long[] { 4298189245, 6256318983, 6220208083, 5117161634, 4145865333, 8206231274, 5791942653, 7493199652, 7100498765, 8849245969, 6576317651, 7516910657, 4110237458, 9528829097, 9193648296, 9535539842, 9223372036854775807, 9223372036854775806 };
        }

        public static IEnumerable<long> GetMaxLongsEven()
        {
            return new long[] { long.MaxValue, long.MaxValue, long.MaxValue, long.MaxValue };
        }

        public static IEnumerable<long> GetMinimumLongsEven()
        {
            return new long[] { long.MinValue, long.MinValue, long.MinValue, long.MinValue };
        }
    }
}
