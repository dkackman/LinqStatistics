﻿using LinqStatistics.NaN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics.UnitTests
{
    /// <summary>
    /// Summary description for CovarianceTests
    /// </summary>
    [TestClass]
    public class CovarianceTests
    {
        public CovarianceTests()
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
        public void Covariance()
        {
            IEnumerable<double> source = TestData.GetDoubles();
            IEnumerable<double> other = TestData.GetDoubles();

            double result = source.Covariance(other);

            Assert.AreEqual(3.081875, result, double.Epsilon);
        }

        [TestMethod]
        public void CovarianceNaN()
        {
            IEnumerable<double> source = new List<double>();
            IEnumerable<double> other = new List<double>();

            double result = source.CovarianceNaN(other);

            Assert.IsTrue(double.IsNaN(result));
        }

        [TestMethod]
        public void Covariance1()
        {
            IEnumerable<double> source = TestData.GetDoubles();
            IEnumerable<double> other = TestData.GetInts().Select(x => (double)x);

            double result = source.Covariance(other);

            Assert.AreEqual(2.59375, result, double.Epsilon);
        }


        [TestMethod]
        public void PearsonIdentity()
        {
            IEnumerable<double> source = TestData.GetDoubles();
            IEnumerable<double> other = TestData.GetDoubles();

            double result = source.Pearson(other);

            Assert.AreEqual(1.0, result, double.Epsilon);
        }

        [TestMethod]
        public void Pearson1()
        {
            IEnumerable<double> source = TestData.GetDoubles();
            IEnumerable<double> other = TestData.GetInts().Select(x => (double)x);

            double result = source.Pearson(other);

            Assert.AreEqual(0.99895649120828689, result, double.Epsilon);
        }
    }
}
