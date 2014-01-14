using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LinqStatistics;

namespace LinqStatisticsTests
{
    [TestClass]
    public class LeastSquaresTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LSExceptsAppropriately()
        {
            var data = new List<Tuple<double, double>>()
            {
                new Tuple<double, double>(1, 10)
            };

            var ls = data.LeastSquares();
        }
    }
}
