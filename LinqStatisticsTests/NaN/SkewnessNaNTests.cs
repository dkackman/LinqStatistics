using System.Collections.Generic;
using LinqStatistics.NaN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqStatistics.UnitTests.NaN
{
    [TestClass]
    public class SkewnessNaNTests
    {
        [TestMethod]
        public void SkewnessDoubleNaN()
        {
            IEnumerable<double> source = new double[] { };

            double result = source.SkewnessNaN();

            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        public void SkewnessNullableDoubleNaN()
        {
            IEnumerable<double?> source = new double?[] { };

            double? result = source.SkewnessNaN();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void SkewnessFloatNaN()
        {
            IEnumerable<float> source = new float[] { };

            float result = source.SkewnessNaN();

            Assert.AreEqual(float.NaN, result);
        }

        [TestMethod]
        public void SkewnessNullableFloatNaN()
        {
            IEnumerable<float?> source = new float?[] { };

            float? result = source.SkewnessNaN();

            Assert.IsNull(result);
        }

    }
}
