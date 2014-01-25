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

        [TestMethod]
        public void SimpleLinearTrend()
        {
            var data = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(3, 3)
            };

            var ls = data.LeastSquares();
            Assert.AreEqual(ls.M, 1.0);
            Assert.AreEqual(ls.B, 0.0);
        }
    }
}
