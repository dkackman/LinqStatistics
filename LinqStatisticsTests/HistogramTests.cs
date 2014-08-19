using System;
using System.Linq;
using System.Reflection;
using System.IO;
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

            var histogram = list.CountEach().ToList();

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

            var histogram = list.CountEach().ToList();
            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            for (int i = 0; i < histogram.Count; i++)
            {
                Assert.AreEqual(i, histogram[i].RepresentativeValue);
            }
        }

        [TestMethod]
        public void HistogramThreeBinsUnbounded()
        {
            var list = new List<int>()
            {
                1,1,1,2,2,2,3,3
            };

            var histogram = list.HistogramUnbounded(3);

            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            // we get one extra bin for [bin(count - 1).Max, infinity) since this is an unbouded histogram
            Assert.AreEqual(4, histogram.Count());
            Assert.AreEqual(double.PositiveInfinity, histogram.Last().Range.Max);
        }

        [TestMethod]
        public void HistogramUnbounded()
        {
            var list = new List<int>()
            {
                1,2,2,3,3,3,4,4,4,4,5,5,5,5,5,6,6,6,6,7,7,7,8,8,9
            };

            var histogram = list.HistogramUnbounded(list.BinCountSquareRoot()).ToList();

            Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

            Assert.AreEqual(3, histogram[0].Count);

            Assert.AreEqual(7, histogram[1].Count);

            Assert.AreEqual(5, histogram[2].Count);

            Assert.AreEqual(7, histogram[3].Count);

            Assert.AreEqual(2, histogram[4].Count);

            Assert.AreEqual(1, histogram[5].Count);
        }

        private static IEnumerable<double> LoadData()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LinqStatisticsTests.HistogramData2.txt"))
            using (StreamReader reader = new StreamReader(stream))
            {
                var list = new List<double>();
                string line = reader.ReadLine();
                while (line != null)
                {
                    list.Add(Math.Round(Convert.ToDouble(line),1, MidpointRounding.AwayFromZero));
                    line = reader.ReadLine();
                }
                return list;
            }
        }

        [TestMethod]
        public void MatchInteractiveHistogram()
        {
            var list = LoadData();

            var histogram = list.Histogram(7).ToList();

            Assert.AreEqual(list.Count(), histogram.Select(b => b.Count).Sum());

            Assert.AreEqual(3, histogram[0].Count);

            Assert.AreEqual(7, histogram[1].Count);

            Assert.AreEqual(5, histogram[2].Count);

            Assert.AreEqual(7, histogram[3].Count);

            Assert.AreEqual(2, histogram[4].Count);

            Assert.AreEqual(1, histogram[5].Count);
        }
        //[TestMethod]
        //public void HistogramOfDoubles()
        //{
        //    var list = new List<double>()
        //    {
        //        1.1, 2.2, 2.3, 3.4, 3.5, 3.6, 4.7, 4.8, 4.9, 4.1, 5.2, 5.3, 5.4, 5.5, 5.6, 6.7, 6.8, 6.9, 6.1, 7.2, 7.3, 7.4, 8.5, 8.6, 9.7
        //    };

        //    var histogram = list.Histogram(6).ToList();

        //    Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

        //    Assert.AreEqual(1, histogram[0].Count);

        //    Assert.AreEqual(2, histogram[1].Count);

        //    Assert.AreEqual(4, histogram[2].Count);

        //    Assert.AreEqual(9, histogram[3].Count);

        //    Assert.AreEqual(6, histogram[4].Count);

        //    Assert.AreEqual(3, histogram[5].Count);
        //}

        //[TestMethod]
        //public void HistogramOfNullableDoubles()
        //{
        //    var list = new List<double?>()
        //    {
        //        null, 1.1, 2.2, 2.3, 3.4, 3.5, null, 3.6, 4.7, 4.8, 4.9, null, 4.1, 5.2, 5.3, 5.4, 5.5, null, 5.6, 6.7, 6.8, 6.9, 6.1, 7.2, 7.3, 7.4, 8.5, 8.6, 9.7
        //    };

        //    var histogram = list.Histogram(6).ToList();

        //    Assert.AreEqual(list.Count, histogram.Select(b => b.Count).Sum());

        //    Assert.AreEqual(4, histogram[0].Count);
        //    Assert.IsNull(histogram[0].RepresentativeValue);

        //    Assert.AreEqual(1, histogram[1].Count);

        //    Assert.AreEqual(2, histogram[2].Count);

        //    Assert.AreEqual(4, histogram[3].Count);

        //    Assert.AreEqual(9, histogram[4].Count);

        //    Assert.AreEqual(6, histogram[5].Count);

        //    Assert.AreEqual(3, histogram[6].Count);
        //}
    }
}
