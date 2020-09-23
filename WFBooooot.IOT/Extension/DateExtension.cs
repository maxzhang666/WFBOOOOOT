using System;

namespace WFBooooot.IOT.Extension
{
    public static class DateExtension
    {
        public static DateTime ToLocal(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Local);
        }
    }
}