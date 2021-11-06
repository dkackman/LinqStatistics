using LinqStatistics.NaN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LinqStatistics.UnitTests.NaN
{
    [TestClass]
    public class VarianceNaNTests
    {
        [TestMethod]
        public void VarDoubleNaN()
        {
            IEnumerable<double> source = new double[] { };

            double result = source.VarianceNaN();

            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        public void VarNullableDoubleNaN()
        {
            IEnumerable<double?> source = new double?[] { };

            double? result = source.VarianceNaN();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void VarFloatNaN()
        {
            IEnumerable<float> source = new float[] { };

            float result = source.VarianceNaN();

            Assert.AreEqual(float.NaN, result);
        }

        [TestMethod]
        public void VarNullableFloatNaN()
        {
            IEnumerable<float?> source = new float?[] { };

            float? result = source.VarianceNaN();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void VarPDoubleNaN()
        {
            IEnumerable<double> source = new double[] { };

            double result = source.VariancePNaN();

            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        public void VarPNullableDoubleNaN()
        {
            IEnumerable<double?> source = new double?[] { };

            double? result = source.VariancePNaN();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void VarPFloatNaN()
        {
            IEnumerable<float> source = new float[] { };

            float result = source.VariancePNaN();

            Assert.AreEqual(float.NaN, result);
        }

        [TestMethod]
        public void VarPNullableFloatNaN()
        {
            IEnumerable<float?> source = new float?[] { };

            float? result = source.VariancePNaN();

            Assert.IsNull(result);
        }
    }
}
