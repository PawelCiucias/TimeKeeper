using System;
using System.Collections.Generic;
using System.Text;

namespace pav.timeKeeper.mobile.Core
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff);
        }

        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            var endOfWeek = startOfWeek == DayOfWeek.Sunday ? DayOfWeek.Saturday : startOfWeek - 1;
            
            if (endOfWeek >= dt.DayOfWeek)
                return dt.AddDays(endOfWeek - dt.DayOfWeek);
            
            return dt.AddDays((7 - (int)dt.DayOfWeek + (int)endOfWeek));
        }

        public static DateTime FirstOfMonth(this DateTime dt)
        {
            return dt.AddDays(-1 * dt.Day+1);
        }

        public static DateTime LastOfMonth(this DateTime dt) {
            var tempDate = dt.AddMonths(1);
            return tempDate.AddDays(-tempDate.Day);
        }

    }
}
