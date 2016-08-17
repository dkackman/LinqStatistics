using System;
using System.Collections.Generic;

using LinqStatistics.NaN;

using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void Test1() 
        {
            var list = new List<int>();

            double mean = list.AverageNaN();

            Assert.True(double.IsNaN(mean));
        }
    }
}
