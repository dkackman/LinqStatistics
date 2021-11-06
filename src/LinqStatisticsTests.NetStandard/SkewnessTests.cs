using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqStatistics.UnitTests
{
    [TestClass]
    public class SkewnessTests
    {
        [TestMethod]
        public void SkewnessInts()
        {
            var source = TestData.GetInts();

            var skewness = source.Skewness();

            Assert.AreEqual(0.75283719913172575, skewness, double.Epsilon);
        }
    }
}
