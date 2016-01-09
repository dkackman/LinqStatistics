using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqStatistics.UnitTests
{
    [TestClass]
    public class RangeObjectTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RangeConstructorThrowsWhenMinIsGreaterThanMax()
        {
            new Range<int>(1, 0);
        }

        [TestMethod]
        public void RangeContainsMaxInclusiveFalse()
        {
            var range = new Range<int>(1, 10);
            Assert.IsFalse(range.Contains(10));
        }

        [TestMethod]
        public void RangeContainsMaxInclusiveTrue()
        {
            var range = new Range<int>(1, 10, true);
            Assert.IsTrue(range.Contains(10));
        }

        [TestMethod]
        public void RangeEquality()
        {
            var r1 = new Range<int>(1, 10);
            var r2 = new Range<int>(1, 10);

            Assert.IsTrue(r1 == r2);
            Assert.AreEqual(r1, r2);
            Assert.IsTrue(r1.Equals(r2));
        }

        [TestMethod]
        public void RangeInEquality()
        {
            var r1 = new Range<int>(1, 10);
            var r2 = new Range<int>(1, 9);

            Assert.IsTrue(r1 != r2);
            Assert.AreNotEqual(r1, r2);
            Assert.IsFalse(r1.Equals(r2));
        }

        [TestMethod]
        public void RangeGreaterThan()
        {
            var r1 = new Range<int>(1, 5);
            var r2 = new Range<int>(3, 4);

            Assert.IsTrue(r1 > r2);
        }
    }
}
