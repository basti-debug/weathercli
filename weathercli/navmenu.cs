using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weathercli
{
    internal class navmenu
    {
        public static void submenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Options:");
            Console.WriteLine("");
            Console.WriteLine("[ ] change location");
            Console.WriteLine("[x] weatherforecast");
            Console.WriteLine("[ ] set alert");
            Console.WriteLine("[ ] options");
        }
    }
}
