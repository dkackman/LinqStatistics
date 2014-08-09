using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LinqStatistics;

namespace LinqStatisticsTests
{
    [TestClass]
    public class HistogramTests
    {
        [TestMethod]
        public void SimpleHistogram()
        {
            var list = new List<int>()
            {
                0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7
            };

            var histogram = list.Histogram().ToList();

            Assert.AreEqual(histogram.Count(), list.Distinct().Count());

            Assert.AreEqual(histogram[0].Value, 0);
            Assert.AreEqual(histogram[0].Count, 1);

            Assert.AreEqual(histogram[1].Value, 1);
            Assert.AreEqual(histogram[1].Count, 2);

            Assert.AreEqual(histogram[2].Value, 2);
            Assert.AreEqual(histogram[2].Count, 3);

            Assert.AreEqual(histogram[3].Value, 3);
            Assert.AreEqual(histogram[3].Count, 4);

            Assert.AreEqual(histogram[4].Value, 4);
            Assert.AreEqual(histogram[4].Count, 3);

            Assert.AreEqual(histogram[5].Value, 5);
            Assert.AreEqual(histogram[5].Count, 3);

            Assert.AreEqual(histogram[6].Value, 6);
            Assert.AreEqual(histogram[6].Count, 2);

            Assert.AreEqual(histogram[7].Value, 7);
            Assert.AreEqual(histogram[7].Count, 1);
        }

        [TestMethod]
        public void HistogramOrdersCorrectly()
        {
            var list = new List<int>()
            {
                9, 1, 1, 2, 8, 2, 2, 3, 3, 0, 3, 3, 4, 8, 4, 5, 4, 5, 5, 1, 5, 6, 0, 6, 7
            };

            var histogram = list.Histogram().ToList();

            for (int i = 0; i < histogram.Count; i++)
            {
                Assert.AreEqual(i, histogram[i].Value);
            }
        }
    }
}
