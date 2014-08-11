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

            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            Assert.AreEqual(histogram.Count(), list.Distinct().Count());

            Assert.AreEqual(histogram[0].RepresentativeValue, 0);
            Assert.AreEqual(histogram[0].Count, 1);

            Assert.AreEqual(histogram[1].RepresentativeValue, 1);
            Assert.AreEqual(histogram[1].Count, 2);

            Assert.AreEqual(histogram[2].RepresentativeValue, 2);
            Assert.AreEqual(histogram[2].Count, 3);

            Assert.AreEqual(histogram[3].RepresentativeValue, 3);
            Assert.AreEqual(histogram[3].Count, 4);

            Assert.AreEqual(histogram[4].RepresentativeValue, 4);
            Assert.AreEqual(histogram[4].Count, 3);

            Assert.AreEqual(histogram[5].RepresentativeValue, 5);
            Assert.AreEqual(histogram[5].Count, 3);

            Assert.AreEqual(histogram[6].RepresentativeValue, 6);
            Assert.AreEqual(histogram[6].Count, 2);

            Assert.AreEqual(histogram[7].RepresentativeValue, 7);
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
            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            for (int i = 0; i < histogram.Count; i++)
            {
                Assert.AreEqual(i, histogram[i].RepresentativeValue);
            }
        }

        [TestMethod]
        public void HistogramTwoBins()
        {
            var list = new List<int>()
            {
                1,1,1,2,2,2
            };

            var histogram = list.Histogram(2).ToList();

            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            Assert.AreEqual(2, histogram.Count);

            Assert.AreEqual(3, histogram[0].Count);
            Assert.AreEqual(3, histogram[1].Count);
        }

        [TestMethod]
        public void HistogramThreeBins()
        {
            var list = new List<int>()
            {
                1,1,1,2,2,2,3,3
            };

            var histogram = list.Histogram(3);

            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            Assert.AreEqual(3, histogram.Count());
        }

        [TestMethod]
        public void HistogramMatchExcel()
        {
            var list = new List<int>()
            {
                1,2,2,3,3,3,4,4,4,4,5,5,5,5,5,6,6,6,6,7,7,7,8,8,9
            };

            var histogram = list.Histogram(6).ToList();

            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            Assert.AreEqual(1, histogram[0].Count);
            Assert.AreEqual(1.0, histogram[0].RepresentativeValue);

            Assert.AreEqual(2, histogram[1].Count);
            //Assert.AreEqual(2.6, histogram[1].RepresentativeValue);

            Assert.AreEqual(7, histogram[2].Count);
           // Assert.AreEqual(4.2, histogram[2].RepresentativeValue);

            Assert.AreEqual(5, histogram[3].Count);
            //Assert.AreEqual(5.8, histogram[3].RepresentativeValue);

            Assert.AreEqual(7, histogram[4].Count);
            //Assert.AreEqual(7.4, histogram[4].RepresentativeValue);

            Assert.AreEqual(3, histogram[5].Count);
        }
    }
}
