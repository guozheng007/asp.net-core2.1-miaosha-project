using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.Utility
{
    public static class DateTimeHelper
    {
        public static DateTime ConvertTimeByUnix(this long unixTime, bool milliseconds = false)
        {
            DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local);

            if (milliseconds)
            {
                return dateTime.AddMilliseconds((double)unixTime);
            }

            return dateTime.AddSeconds((double)unixTime);
        }
    }
}
