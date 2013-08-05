using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
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

            Assert.AreEqual(result, 3.081875, double.Epsilon);
        }

        [TestMethod]
        public void Covariance1()
        {
            IEnumerable<double> source = TestData.GetDoubles();
            IEnumerable<double> other = TestData.GetInts().Select(x => (double)x);


            double result = source.Covariance(other);

            Assert.AreEqual(result, 2.59375, double.Epsilon);
        }


        [TestMethod]
        public void PearsonIdentity()
        {
            IEnumerable<double> source = TestData.GetDoubles();
            IEnumerable<double> other = TestData.GetDoubles();


            double result = source.Pearson(other);

            Assert.AreEqual(result, 1.0, double.Epsilon);
        }

        [TestMethod]
        public void Pearson1()
        {
            IEnumerable<double> source = TestData.GetDoubles();
            IEnumerable<double> other = TestData.GetInts().Select(x => (double)x);

            double result = source.Pearson(other);

            Assert.AreEqual(result, 0.998956491208287, double.Epsilon);
        }
    }
}
