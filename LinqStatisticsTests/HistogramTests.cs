using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqStatistics.UnitTests
{
    [TestClass]
    public class HistogramTests
    {
        [TestMethod]
        public void CounEachIntegers()
        {
            var list = new List<int>()
            {
                0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7
            };

            var counts = list.CountEach().ToList();

            Assert.AreEqual(list.Count, counts.Select(b => b.Count).Sum());

            Assert.AreEqual(counts.Count(), list.Distinct().Count());

            Assert.AreEqual(counts[0].RepresentativeValue, 0);
            Assert.AreEqual(counts[0].Count, 1);

            Assert.AreEqual(counts[1].RepresentativeValue, 1);
            Assert.AreEqual(counts[1].Count, 2);

            Assert.AreEqual(counts[2].RepresentativeValue, 2);
            Assert.AreEqual(counts[2].Count, 3);

            Assert.AreEqual(counts[3].RepresentativeValue, 3);
            Assert.AreEqual(counts[3].Count, 4);

            Assert.AreEqual(counts[4].RepresentativeValue, 4);
            Assert.AreEqual(counts[4].Count, 3);

            Assert.AreEqual(counts[5].RepresentativeValue, 5);
            Assert.AreEqual(counts[5].Count, 3);

            Assert.AreEqual(counts[6].RepresentativeValue, 6);
            Assert.AreEqual(counts[6].Count, 2);

            Assert.AreEqual(counts[7].RepresentativeValue, 7);
            Assert.AreEqual(counts[7].Count, 1);
        }

        [TestMethod]
        public void CountEachOrdersCorrectly()
        {
            var list = new List<int>()
            {
                9, 1, 1, 2, 8, 2, 2, 3, 3, 0, 3, 3, 4, 8, 4, 5, 4, 5, 5, 1, 5, 6, 0, 6, 7
            };

            var histogram = list.CountEach().ToList();
            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            for (int i = 0; i < histogram.Count; i++)
            {
                Assert.AreEqual(i, histogram[i].RepresentativeValue);
            }
        }

        [TestMethod]
        public void HistogramUnboundedLastBinHasMaxAsInfinity()
        {
            var list = new List<int>()
            {
                1,1,1,2,2,2,3,3
            };

            var histogram = list.Histogram(3);

            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            Assert.AreEqual(double.PositiveInfinity, histogram.Last().Range.Max);
        }

        [TestMethod]
        public void HistogramMaxInclusiveLastBinHasIsMaxInclusive()
        {
            var list = new List<int>()
            {
                1,1,1,2,2,2,3,3
            };

            var histogram = list.Histogram(3, BinningMode.MaxValueInclusive);

            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            Assert.IsTrue(histogram.Last().Range.Contains(list.Max()));
        }

        [TestMethod]
        public void HistogramUnbounded()
        {
            var list = new List<int>()
            {
                1,2,2,3,3,3,4,4,4,4,5,5,5,5,5,6,6,6,6,7,7,7,8,8,9
            };

            var histogram = list.Histogram(list.BinCountSquareRoot()).ToList();

            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            Assert.AreEqual(3, histogram[0].Count);

            Assert.AreEqual(7, histogram[1].Count);

            Assert.AreEqual(5, histogram[2].Count);

            Assert.AreEqual(7, histogram[3].Count);

            Assert.AreEqual(2, histogram[4].Count);

            Assert.AreEqual(1, histogram[5].Count);
        }

        [TestMethod]
        public void MatchInteractiveHistogram()
        {
            var list = DataLoader.LoadData<int>("HistogramData.txt", s => Convert.ToInt32(s));

            // http://www.shodor.org/interactivate/activities/Histogram/#

            var histogram = list.Histogram(10, BinningMode.ExpandRange).ToList();

            Assert.AreEqual(list.Count(), histogram.Select(b => b.Count).Sum());

            Assert.AreEqual(4, histogram[0].Count);

            Assert.AreEqual(8, histogram[1].Count);

            Assert.AreEqual(52, histogram[2].Count);

            Assert.AreEqual(41, histogram[3].Count);

            Assert.AreEqual(36, histogram[4].Count);

            Assert.AreEqual(20, histogram[5].Count);

            Assert.AreEqual(3, histogram[6].Count);

            Assert.AreEqual(5, histogram[7].Count);

            Assert.AreEqual(1, histogram[8].Count);

            Assert.AreEqual(3, histogram[9].Count);
        }

        [TestMethod]
        public void HistogramOfDoubles()
        {
            var list = new List<double>()
            {
                1.1, 2.2, 2.3, 3.4, 3.5, 3.6, 4.7, 4.8, 4.9, 4.1, 5.2, 5.3, 5.4, 5.5, 5.6, 6.7, 6.8, 6.9, 6.1, 7.2, 7.3, 7.4, 8.5, 8.6, 9.7
            };

            var histogram = list.Histogram(6).ToList();

            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            Assert.AreEqual(3, histogram[0].Count);

            Assert.AreEqual(3, histogram[1].Count);

            Assert.AreEqual(6, histogram[2].Count);

            Assert.AreEqual(6, histogram[3].Count);

            Assert.AreEqual(4, histogram[4].Count);

            Assert.AreEqual(3, histogram[5].Count);

            Assert.AreEqual(0, histogram[6].Count);
        }
    }
}
