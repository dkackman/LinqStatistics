using System;

namespace LinqStatistics.UnitTests
{
    internal static class Extensions
    {
        public static bool AboutEqual(this double x, double y)
        {
            double epsilon = Math.Max(Math.Abs(x), Math.Abs(y)) * 1E-15;
            return Math.Abs(x - y) <= epsilon;
        }
    }
}
