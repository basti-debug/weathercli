using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weathercli
{
    internal class navmenu
    {
        static bool selected = false;
        static int position = 0; 

        public static void submenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Options:");
            Console.WriteLine("");
            Console.WriteLine("[x] change location");
            Console.WriteLine("[ ] weatherforecast");
            Console.WriteLine("[ ] set alert");
            Console.WriteLine("[ ] options");
            
            while (!selected)
            {
                if (Console.ReadKey().Key != ConsoleKey.UpArrow)
                {
                    position++;
                    
                }
                if (Console.ReadKey().Key == ConsoleKey.DownArrow)
                {
                    position--;
                }

            }
            
        }

        public static void selector(int position)
        {
            if (position == 0)
            {
                clearline.clearcurrentline(4);
                Console.Write("[x]");
                Console.WriteLine(" change location");
                Console.Write("[ ]");
                Console.WriteLine(" weatherforecast");
                Console.Write("[ ]");
                Console.WriteLine(" set alert");
                Console.Write("[ ]");
                Console.WriteLine(" options");
            }
            if (position == 1)
            {
                Console.Write("[ ]");
                Console.WriteLine(" change location");
                Console.Write("[x]");
                Console.WriteLine(" weatherforecast");
                Console.Write("[ ]");
                Console.WriteLine(" set alert");
                Console.Write("[ ]");
                Console.WriteLine(" options");
            }
            if (position == 2)
            {
                Console.Write("[ ]");
                Console.WriteLine(" change location");
                Console.Write("[ ]");
                Console.WriteLine(" weatherforecast");
                Console.Write("[x]");
                Console.WriteLine(" set alert");
                Console.Write("[ ]");
                Console.WriteLine(" options");
            }
            if (position == 3)
            {
                Console.Write("[ ]");
                Console.WriteLine(" change location");
                Console.Write("[ ]");
                Console.WriteLine(" weatherforecast");
                Console.Write("[ ]");
                Console.WriteLine(" set alert");
                Console.Write("[x]");
                Console.WriteLine(" options");
            }



        }
    }
}
