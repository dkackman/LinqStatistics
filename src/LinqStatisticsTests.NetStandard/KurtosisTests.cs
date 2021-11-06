﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqStatistics.UnitTests
{
    [TestClass]
    public class KurtosisTests
    {
        [TestMethod]
        public void KurtosisInts()
        {
            var data = TestData.GetInts();
            var result = data.Kurtosis();

            // single pass = -1.1542857142857144
            // excel = 0.342857143

            Assert.AreEqual(result, 0.34285714285714697, double.Epsilon);
        }

        //[TestMethod]
        //public void Kurtosis()
        //{
        //    var data = new double[] { 3.4, 7.1, 1.5, 8.6, 4.9 };

        //    var result = data.Kurtosis();

        //    Assert.AreEqual(result, -0.928457, double.Epsilon);
        //}
    }
}
