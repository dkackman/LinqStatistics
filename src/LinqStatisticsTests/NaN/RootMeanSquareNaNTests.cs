using System.Collections.Generic;
using LinqStatistics.NaN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqStatistics.UnitTests.NaN
{
    [TestClass]
    public class RootMeanSquareNaNTests
    {
        [TestMethod]
        public void RootMeanSquareDoubleNaN()
        {
            IEnumerable<double> source = new double[] { };

            double result = source.RootMeanSquareNaN();

            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        public void RootMeanSquareNullableDoubleNaN()
        {
            IEnumerable<double?> source = new double?[] { };

            double? result = source.RootMeanSquareNaN();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void RootMeanSquareFloatNaN()
        {
            IEnumerable<float> source = new float[] { };

            float result = source.RootMeanSquareNaN();

            Assert.AreEqual(float.NaN, result);
        }

        [TestMethod]
        public void RootMeanSquareNullableFloatNaN()
        {
            IEnumerable<float?> source = new float?[] { };

            float? result = source.RootMeanSquareNaN();

            Assert.IsNull(result);
        }

    }
}
