using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace weathercli
{
    internal class internfunctions
    {
        public static void clearline(int count)
        {
            
            int topcount = Console.CursorTop;   

            for (int i = 0; i < count; i++)
            {
                 Console.SetCursorPosition(0, topcount - i);
                 Console.Write(new string(' ', Console.WindowWidth));
               
            }
            
        }

        public static DateTime convertunix(int unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(unix).ToLocalTime();
            return dt;
        }
    }
}
