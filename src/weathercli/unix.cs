using System;
using System.Linq;


namespace weathercli
{
    internal class unix
    {
        public static DateTime convertunix(int unix)
        {
           DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
           dt = dt.AddSeconds(unix).ToLocalTime();
           return dt;
        }
        

    }

}