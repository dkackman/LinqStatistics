using System.Collections.Generic;
using LinqStatistics.NaN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqStatistics.UnitTests.NaN
{
    [TestClass]
    public class StandardDeviationNaNTests
    {
        [TestMethod]
        public void StdevDoubleNaN()
        {
            IEnumerable<double> source = new double[] { };

            double result = source.StandardDeviationNaN();

            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        public void StdevNullableDoubleNaN()
        {
            IEnumerable<double?> source = new double?[] { };

            double? result = source.StandardDeviationNaN();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void StdevFloatNaN()
        {
            IEnumerable<float> source = new float[] { };

            float result = source.StandardDeviationNaN();

            Assert.AreEqual(float.NaN, result);
        }

        [TestMethod]
        public void StdevNullableFloatNaN()
        {
            IEnumerable<float?> source = new float?[] { };

            float? result = source.StandardDeviationNaN();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void StdevPDoubleNaN()
        {
            IEnumerable<double> source = new double[] { };

            double result = source.StandardDeviationPNaN();

            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        public void StdevPNullableDoubleNaN()
        {
            IEnumerable<double?> source = new double?[] { };

            double? result = source.StandardDeviationPNaN();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void StdevPFloatNaN()
        {
            IEnumerable<float> source = new float[] { };

            float result = source.StandardDeviationPNaN();

            Assert.AreEqual(float.NaN, result);
        }

        [TestMethod]
        public void StdevPNullableFloatNaN()
        {
            IEnumerable<float?> source = new float?[] { };

            float? result = source.StandardDeviationPNaN();

            Assert.IsNull(result);
        }

    }
}
