using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqStatistics.UnitTests
{
    [TestClass]
    public class AverageTests
    {
        [TestMethod]
        public void AverageNaN()
        {
            var list = new List<int>();

            double mean = list.AverageNaN();

            Assert.IsTrue(double.IsNaN(mean));
        }

        [TestMethod]
        public void AverageNaNEqualsAverage()
        {
            var list = new List<int>()
            {
                9, 1, 1, 2, 8, 2, 2, 3, 3, 0, 3, 3, 4, 8, 4, 5, 4, 5, 5, 1, 5, 6, 0, 6, 7
            };

            double avgNaN = list.AverageNaN();
            double avg = list.Average();

            Assert.AreEqual(avg, avgNaN);
        }
    }
}
