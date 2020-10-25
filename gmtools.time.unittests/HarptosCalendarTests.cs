using gmtools.time.Calendars;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace gmtools.time.unittests
{
    [TestClass]
    public class HarptosCalendarTests
    {
        [TestMethod]
        public void Verify_Midnight()
        {
            var t = new Harptos();
            Assert.AreEqual("0:0:0", t.ToString());
        }

        [TestMethod]
        public void Verify_OneAM()
        {
            var t = new Harptos(1, 0, 0);
            Assert.AreEqual("1:0:0", t.ToString());
        }

        [TestMethod]
        public void Verify_TwoAM()
        {
            var t = new Harptos(2, 0, 0);
            Assert.AreEqual("2:0:0", t.ToString());
        }

        [TestMethod]
        public void Verify_ThreeThirty()
        {
            var t = new Harptos(3, 30, 0);
            Assert.AreEqual("3:30:0", t.ToString());
        }

        [TestMethod]
        public void Verify_ElevenFiftySixAndNineteenSeconds()
        {
            var t = new Harptos(11, 56, 19);
            Assert.AreEqual("11:56:19", t.ToString());
        }

        [TestMethod]
        public void Verify_LastMomentoftheDay()
        {
            var t = new Harptos(23, 59, 59);
            Assert.AreEqual("23:59:59", t.ToString());
        }

        [TestMethod]
        public void Verify_Increment_Rolls_to_Zero_OnNewHour()
        {
            var t = new Harptos(1, 59, 59);
            Assert.AreEqual("1:59:59", t.ToString());
            t.AddSecond();
            Assert.AreEqual("2:0:0", t.ToString());
        }

        [TestMethod]
        public void Verify_Increment_Rolls_to_Zero_OnNewMinute()
        {
            var t = new Harptos(1, 5, 59);
            Assert.AreEqual("1:5:59", t.ToString());
            t.AddSecond();
            Assert.AreEqual("1:6:0", t.ToString());
        }
    }
}
