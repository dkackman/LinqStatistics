using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using LinqStatistics.NaN;

namespace LinqStatistics.UnitTests
{
    [TestClass]
    public class LeastSquaresTests
    {
        [TestMethod]
        public void LeastSquares1()
        {
            var data = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 2),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(5, 6),
                new Tuple<int, int>(7, 8),
                new Tuple<int, int>(9, 10)
            };

            var ls = data.LeastSquares();
            Assert.AreEqual(ls.M, 0.90163934426229508);
            Assert.AreEqual(ls.B, 1.6721311475409837);
            Assert.AreEqual(ls.RSquared, 0.99180327868852458);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LeastSquaresExceptsOnSingleElementSource()
        {
            var data = new List<Tuple<double, double>>()
            {
                new Tuple<double, double>(1, 10)
            };

            var ls = data.LeastSquares();
        }

        [TestMethod]
        public void LeastSquaresNaNSingleElementSourceReturnsNaN()
        {
            var data = new List<Tuple<double, double>>()
            {
                new Tuple<double, double>(1, 10)
            };

            var ls = data.LeastSquaresNaN();
            Assert.IsTrue(LeastSquares.IsNaN(ls));
            Assert.IsTrue(double.IsNaN(ls.M));
            Assert.IsTrue(double.IsNaN(ls.B));
            Assert.IsTrue(double.IsNaN(ls.RSquared));
        }

        [TestMethod]
        public void LeastSquaresSimpleLinearTrend()
        {
            var data = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(3, 3),
                new Tuple<int, int>(4, 4)
            };

            var ls = data.LeastSquares();
            Assert.AreEqual(ls.M, 1.0);
            Assert.AreEqual(ls.B, 0.0);
            Assert.AreEqual(ls.RSquared, 1.0);

            var pearson = data.Pearson();
            Assert.IsTrue(pearson.AboutEqual(1));
        }
    }
}
