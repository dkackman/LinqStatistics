using LinqStatistics.NaN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LinqStatistics.UnitTests
{
    /// <summary>
    /// Summary description for RangeTests
    /// </summary>
    [TestClass]
    public class RangeTests
    {
        public RangeTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Range()
        {
            IEnumerable<int> source = new int[] { 1, 2, 3, 4, 5 };

            int result = source.Range();

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RangeEmptyExcepts()
        {
            var source = new List<double>();

            var result = source.Range();
        }

        [TestMethod]
        public void RangeNaN()
        {
            var source = new List<double>();

            var result = source.RangeNaN();

            Assert.IsTrue(double.IsNaN(result));
        }

        [TestMethod]
        public void MinMax()
        {
            IEnumerable<int> source = new int[] { 1, 2, 3, 4, 5 };

            var result = source.MinMax();

            Assert.AreEqual(1, result.Min);
            Assert.AreEqual(5, result.Max);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MinMaxNoElements()
        {
            IEnumerable<int> source = new List<int>();

            var result = source.MinMax();
        }

        [TestMethod]
        public void MinMaxNoElementsNaN()
        {
            IEnumerable<double> source = new List<double>();

            var result = source.MinMaxNaN();

            Assert.IsTrue(double.IsNaN(result.Max));
            Assert.IsTrue(double.IsNaN(result.Min));
        }
    }
}
