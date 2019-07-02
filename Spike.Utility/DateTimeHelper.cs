using System;

namespace Spike.Utility
{
    public static class DateTimeHelper
    {
        public static DateTime ConvertTimeByUnix(this long unixTime, bool milliseconds = false)
        {
            DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local);

            if (milliseconds)
            {
                return dateTime.AddMilliseconds(unixTime);
            }

            return dateTime.AddSeconds(unixTime);
        }
    }
}
