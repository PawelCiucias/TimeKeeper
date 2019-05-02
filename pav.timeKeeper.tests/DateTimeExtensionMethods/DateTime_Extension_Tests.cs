using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using pav.timeKeeper.mobile.Core;

namespace pav.timeKeeper.tests.DateTimeExtensionMethods
{
    [TestClass]
    public class DateTime_Extension_Tests
    {
        [TestMethod]
        public void First_day_of_the_week_test()
        {
            var testDate = new DateTime(2019, 5, 1);

            var lastThursday = new DateTime(2019, 4, 25);
            var lastFriday = new DateTime(2019, 4, 26);
            var lastSaturday = new DateTime(2019, 4, 27);
            var lastSunday = new DateTime(2019, 4, 28);
            var lastMonday = new DateTime(2019, 4, 29);
            var lastTuesday = new DateTime(2019, 4, 30);
            var lastWednesday = new DateTime(2019, 5, 1);

            Assert.AreEqual(lastThursday, testDate.StartOfWeek(DayOfWeek.Thursday));
            Assert.AreEqual(lastFriday, testDate.StartOfWeek(DayOfWeek.Friday));
            Assert.AreEqual(lastSaturday, testDate.StartOfWeek(DayOfWeek.Saturday));
            Assert.AreEqual(lastSunday, testDate.StartOfWeek(DayOfWeek.Sunday));
            Assert.AreEqual(lastMonday, testDate.StartOfWeek(DayOfWeek.Monday));
            Assert.AreEqual(lastTuesday, testDate.StartOfWeek(DayOfWeek.Tuesday));
            Assert.AreEqual(lastWednesday, testDate.StartOfWeek(DayOfWeek.Wednesday));
        }

        [TestMethod]
        public void Last_day_of_the_week_test()
        {
            var wednesday = new DateTime(2019, 5, 1);

            var nextThursday = new DateTime(2019, 5, 2);
            var nextFriday = new DateTime(2019, 5, 3);
            var nextSaturday = new DateTime(2019, 5, 4);
            var nextSunday = new DateTime(2019, 5, 5);
            var nextMonday = new DateTime(2019, 5, 6);
            var nextTuesday = new DateTime(2019, 5, 7);
            var nextWednesday = new DateTime(2019, 5, 8);

            Assert.AreEqual(nextTuesday, wednesday.EndOfWeek(startOfWeek: DayOfWeek.Wednesday));
            Assert.AreEqual(wednesday, wednesday.EndOfWeek(startOfWeek: DayOfWeek.Thursday));
            Assert.AreEqual(nextThursday, wednesday.EndOfWeek(startOfWeek: DayOfWeek.Friday));
            Assert.AreEqual(nextFriday, wednesday.EndOfWeek(startOfWeek: DayOfWeek.Saturday));
            Assert.AreEqual(nextSaturday, wednesday.EndOfWeek(startOfWeek: DayOfWeek.Sunday));
            Assert.AreEqual(nextSunday, wednesday.EndOfWeek(startOfWeek: DayOfWeek.Monday));
            Assert.AreEqual(nextMonday, wednesday.EndOfWeek(startOfWeek: DayOfWeek.Tuesday));
        }

        [TestMethod]
        public void First_day_of_the_month_test()
        {
            var firstOfMonth = new DateTime(2019, 3, 1);
            var dt = new DateTime(2019, 3, 1);
            for (var i = 0; i< 31; i++) 
                Assert.AreEqual(firstOfMonth, dt.AddDays(i).FirstOfMonth());
        }

        [TestMethod]
        public void Last_day_of_the_month_test()
        {
            var firstOfMonth = new DateTime(2019, 3, 1);
            var lastOfMonth = new DateTime(2019, 3, 31);
          
            for (var i = 0; i < 31; i++)
                Assert.AreEqual(lastOfMonth, firstOfMonth.AddDays(i).LastOfMonth());
        }
    }
}
