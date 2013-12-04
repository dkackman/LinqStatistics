using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            Assert.AreEqual(result, -1.1542857142857144, double.Epsilon);
        }
    }
}
