using LinqStatistics.NaN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LinqStatistics.UnitTests.NaN
{
    [TestClass]
    public class KurtosisNaNTests
    {
        [TestMethod]
        public void KurtosisDoubleNaN()
        {
            IEnumerable<double> source = new double[] { };

            double result = source.KurtosisNaN();

            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        public void KurtosisNullableDoubleNaN()
        {
            IEnumerable<double?> source = new double?[] { };

            double? result = source.KurtosisNaN();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void KurtosisFloatNaN()
        {
            IEnumerable<float> source = new float[] { };

            float result = source.KurtosisNaN();

            Assert.AreEqual(float.NaN, result);
        }

        [TestMethod]
        public void KurtosisNullableFloatNaN()
        {
            IEnumerable<float?> source = new float?[] { };

            float? result = source.KurtosisNaN();

            Assert.IsNull(result);
        }

    }
}
