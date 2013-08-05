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
    }
}
