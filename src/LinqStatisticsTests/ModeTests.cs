using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqStatistics.UnitTests
{
    /// <summary>
    /// Summary description for ModeTests
    /// </summary>
    [TestClass]
    public class ModeTests
    {
        public ModeTests()
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
        public void ModeUniform()
        {
            IEnumerable<int> source = new int[] { 1, 1, 1 };

            int? result = source.Mode();
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void ModeNone()
        {
            IEnumerable<int> source = new int[] { 1, 2, 3 };

            int? result = source.Mode();
            Assert.IsFalse(result.HasValue);
        }


        [TestMethod]
        public void ModeOne()
        {
            IEnumerable<int> source = new int[] { 1, 2, 2, 3 };

            int? result = source.Mode();
            Assert.IsTrue(result == 2);
        }


        [TestMethod]
        public void ModeTwo()
        {
            IEnumerable<int> source = new int[] { 1, 2, 2, 3, 3, 3 };

            int? result = source.Mode();
            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void ModeThree()
        {
            IEnumerable<int> source = new int[] { 1, 2, 2, 3, 3 };

            int? result = source.Mode();
            Assert.IsTrue(result == 2);
        }


        [TestMethod]
        public void ModeNullable()
        {
            IEnumerable<int?> source = new int?[] { 1, 3, 2, 3, null, 2, 3 };

            int? result = source.Mode();
            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void ModeMultiple()
        {
            IEnumerable<int> source = new int[] { 1, 3, 2, 2, 3 };

            IEnumerable<int> result = source.Modes();
            Assert.IsTrue(result.SequenceEqual(new int[] { 2, 3 }));
        }

        [TestMethod]
        public void ModesMultiple2()
        {
            IEnumerable<int> source = new int[] { 1, 3, 2, 2, 3, 3 };

            IEnumerable<int> result = source.Modes();
            Assert.IsTrue(result.SequenceEqual(new int[] { 3, 2 }));
        }

        [TestMethod]
        public void ModesMultipleNullable()
        {
            IEnumerable<int?> source = new int?[] { 1, 2, null, 2, 3, 3, 3 };

            IEnumerable<int> result = source.Modes();
            Assert.IsTrue(result.SequenceEqual(new int[] { 3, 2 }));
        }

        [TestMethod]
        public void ModesSingleValue()
        {
            IEnumerable<int> source = new int[] { 1 };

            int? result = source.Mode();
            Assert.IsTrue(result == null);
        }
    }
}
