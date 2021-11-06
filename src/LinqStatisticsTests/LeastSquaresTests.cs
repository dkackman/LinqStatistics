﻿using LinqStatistics.NaN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LinqStatistics.UnitTests
{
    [TestClass]
    public class LeastSquaresTests
    {
        [TestMethod]
        public void CastToFunc()
        {
            var data = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(3, 3)
            };

            var ls = data.LeastSquares();
            Func<double, double> func = ls;

            var result = func(2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void SingularMatrixReturnEmpty()
        {
            var data = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0, 0)
            };

            var ls = data.LeastSquares();
            Assert.AreEqual(ls, LeastSquares.Empty);
        }

        // http://stackoverflow.com/questions/5083465/fast-efficient-least-squares-fit-algorithm-in-c
        [TestMethod]
        public void RSquaredIsCorrect()
        {
            var data = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 4),
                new Tuple<int, int>(2, 6),
                new Tuple<int, int>(4, 12),
                new Tuple<int, int>(5, 15),
                new Tuple<int, int>(10, 34),
                new Tuple<int, int>(20, 68)
            };

            var ls = data.LeastSquares();
            Assert.AreEqual(Math.Round(ls.M, 5), 3.43651);
            Assert.AreEqual(Math.Round(ls.B, 5), -0.88889);
            Assert.AreEqual(Math.Round(ls.RSquared, 4), 0.9984);
        }

        [TestMethod]
        public void LeastSquares1()
        {
            var data = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 2),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(5, 6),
                new Tuple<int, int>(7, 8),
                new Tuple<int, int>(9, 10)
            };

            var ls = data.LeastSquares();
            Assert.AreEqual(ls.M, 0.90163934426229508);
            Assert.AreEqual(ls.B, 1.6721311475409837);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LeastSquaresExceptsAppropriately()
        {
            var data = new List<Tuple<double, double>>()
            {
                new Tuple<double, double>(1, 10)
            };

            var ls = data.LeastSquares();
        }

        [TestMethod]
        public void LeastSquaresSingleElementSourceReturnsNaN()
        {
            var data = new List<Tuple<double, double>>()
            {
                new Tuple<double, double>(1, 10)
            };

            var ls = data.LeastSquaresNaN();
            Assert.IsTrue(LeastSquares.IsNaN(ls));
            Assert.IsTrue(double.IsNaN(ls.M));
            Assert.IsTrue(double.IsNaN(ls.B));
        }

        [TestMethod]
        public void LeastSquaresSimpleLinearTrend()
        {
            var data = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(3, 3),
                new Tuple<int, int>(4, 4)
            };

            var ls = data.LeastSquares();
            Assert.AreEqual(ls.M, 1.0);
            Assert.AreEqual(ls.B, 0.0);

            var pearson = data.Pearson();
            Assert.IsTrue(pearson.AboutEqual(1));
        }
    }
}
