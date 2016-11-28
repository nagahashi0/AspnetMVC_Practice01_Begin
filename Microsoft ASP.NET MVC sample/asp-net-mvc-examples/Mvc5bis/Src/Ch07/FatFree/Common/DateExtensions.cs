using System;

namespace FatFree.Common
{
    public static class DateExtensions
    {
        public static DateTime Next(this DateTime startDate, Int32 month, Int32 day)
        {
            var d = new DateTime(startDate.Year, month, day);
            if (d < startDate)
                d.AddYears(1);
            return d;
        }
    }
}