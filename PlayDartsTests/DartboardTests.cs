using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlayDarts.Tests
{
    [TestClass()]
    public class DartboardTests
    {
        [TestMethod()]
        public void TestGetScore_X()
        {
            var dartboard = new Dartboard();
            Assert.AreEqual("X", dartboard.GetScore(-133.69, -147.38));
        }

        [TestMethod()]
        public void TestGetScore_DB()
        {
            var dartboard = new Dartboard();
            Assert.AreEqual("DB", dartboard.GetScore(4.06, 0.71));
        }

        [TestMethod()]
        public void TestGetScore_SB()
        {
            var dartboard = new Dartboard();
            Assert.AreEqual("SB", dartboard.GetScore(2.38, -6.06));
        }

        [TestMethod()]
        public void TestGetScore_20()
        {
            var dartboard = new Dartboard();
            Assert.AreEqual("20", dartboard.GetScore(-5.43, 117.95));
        }

        [TestMethod()]
        public void TestGetScore_7()
        {
            var dartboard = new Dartboard();
            Assert.AreEqual("7", dartboard.GetScore(-73.905, -95.94));
        }

        [TestMethod()]
        public void TestGetScore_T2()
        {
            var dartboard = new Dartboard();
            Assert.AreEqual("T2", dartboard.GetScore(55.53, -87.95));
        }

        [TestMethod()]
        public void TestGetScore_D9()
        {
            var dartboard = new Dartboard();
            Assert.AreEqual("D9", dartboard.GetScore(-145.19, 86.53));
        }
    }
}