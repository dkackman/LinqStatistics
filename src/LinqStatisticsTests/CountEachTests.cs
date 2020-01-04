using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LinqStatistics.NaN;

namespace LinqStatistics.UnitTests
{
    [TestClass]
    public class CountEachTests
    {
        [TestMethod]
        public void CountEachBasic()
        {
            var list = new List<int>()
             {
                1, 2, 2, 3, 3, 3, 4, 4
            };

            var eaches = list.CountEach();
                       
            Assert.AreEqual(4, eaches.Count());

            Assert.AreEqual(1, eaches.First().RepresentativeValue);
            Assert.AreEqual(1, eaches.First().Count);

            Assert.AreEqual(2, eaches.Skip(1).First().RepresentativeValue);
            Assert.AreEqual(2, eaches.Skip(1).First().Count);

            Assert.AreEqual(3, eaches.Skip(2).First().RepresentativeValue);
            Assert.AreEqual(3, eaches.Skip(2).First().Count);

            Assert.AreEqual(4, eaches.Skip(3).First().RepresentativeValue);
            Assert.AreEqual(2, eaches.Skip(3).First().Count);
        }
    }
}
