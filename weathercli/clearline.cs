using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace weathercli
{
    internal class clearline
    {
        public static void clearcurrentline(int count)
        {
            
            int topcount = Console.CursorTop;   

            for (int i = 0; i < count; i++)
            {
                 Console.SetCursorPosition(0, topcount - i);
                 Console.Write(new string(' ', Console.WindowWidth));
               
            }
            
        }
    }
}
