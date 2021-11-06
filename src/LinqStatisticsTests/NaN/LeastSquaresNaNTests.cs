using LinqStatistics.NaN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LinqStatistics.UnitTests.NaN
{
    [TestClass]
    public class LeastSquaresNaNTests
    {
        [TestMethod]
        public void LeastSquaresDoubleNaN()
        {
            var data = new List<Tuple<double, double>>();

            var result = data.LeastSquaresNaN();

            Assert.IsNotNull(result);
            Assert.IsTrue(double.IsNaN(result.B));
            Assert.IsTrue(double.IsNaN(result.M));
        }
    }
}
