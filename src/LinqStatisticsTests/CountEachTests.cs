using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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

        struct Tmp : IComparable
        {
            public int x;
            public int y;

            public int CompareTo(object obj)
            {
                if (obj is Tmp other)
                {
                    return (x + y) - (other.x + other.y);
                }

                return -1;
            }
        }

        [TestMethod]
        public void CountEachSelector()
        {
            var list = new List<Tmp>()
             {
                new Tmp { x = 1, y = 1 },
                new Tmp { x = 2, y = 1 }
            };

            var eaches = list.CountEach(item => item.y);

            Assert.AreEqual(1, eaches.Count());

            Assert.AreEqual(1, eaches.First().RepresentativeValue);
            Assert.AreEqual(2, eaches.First().Count);
        }

        class TmpComparer : IEqualityComparer<Tmp>
        {
            public bool Equals(Tmp a, Tmp b)
            {
                return a.x == b.x && a.y == b.y;
            }

            public int GetHashCode(Tmp obj)
            {
                return 13 ^ obj.x.GetHashCode() ^ obj.y.GetHashCode();
            }
        }

        [TestMethod]
        public void CountEachComprarer()
        {

            var list = new List<Tmp>()
             {
                new Tmp { x = 1, y = 1 },
                new Tmp { x = 2, y = 1 }
            };

            var eaches = list.CountEach(new TmpComparer());

            Assert.AreEqual(2, eaches.Count());

            Assert.IsTrue(eaches.First().RepresentativeValue.x == 1 && eaches.First().RepresentativeValue.y == 1);
            Assert.IsTrue(eaches.Last().RepresentativeValue.x == 2 && eaches.Last().RepresentativeValue.y == 1);
        }
    }
}
