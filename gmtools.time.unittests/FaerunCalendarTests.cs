using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace gmtools.time.unittests
{
    [TestClass]
    public class FaerunCalendarTests
    {
        [TestMethod]
        public void Verify_Midnight()
        {
            var t = new FaerunCalendar();
            Assert.AreEqual("0:0:0", t.ToString());
        }

        [TestMethod]
        public void Verify_OneAM()
        {
            var t = new FaerunCalendar(1, 0, 0);
            Assert.AreEqual("1:0:0", t.ToString());
        }

        [TestMethod]
        public void Verify_TwoAM()
        {
            var t = new FaerunCalendar(2, 0, 0);
            Assert.AreEqual("2:0:0", t.ToString());
        }

        [TestMethod]
        public void Verify_ThreeThirty()
        {
            var t = new FaerunCalendar(3, 30, 0);
            Assert.AreEqual("3:30:0", t.ToString());
        }

        [TestMethod]
        public void Verify_ElevenFiftySixAndNineteenSeconds()
        {
            var t = new FaerunCalendar(11, 56, 19);
            Assert.AreEqual("11:56:19", t.ToString());
        }

        [TestMethod]
        public void Verify_LastMomentoftheDay()
        {
            var t = new FaerunCalendar(23, 59, 59);
            Assert.AreEqual("23:59:59", t.ToString());
        }

        [TestMethod]
        public void Verify_Increment_Rolls_to_Zero_OnNewHour()
        {
            var t = new FaerunCalendar(1, 59, 59);
            Assert.AreEqual("1:59:59", t.ToString());
            t.AddSecond();
            Assert.AreEqual("2:0:0", t.ToString());
        }

        [TestMethod]
        public void Verify_Increment_Rolls_to_Zero_OnNewMinute()
        {
            var t = new FaerunCalendar(1, 5, 59);
            Assert.AreEqual("1:5:59", t.ToString());
            t.AddSecond();
            Assert.AreEqual("1:6:0", t.ToString());
        }
    }
}
