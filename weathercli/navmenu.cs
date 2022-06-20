using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace weathercli
{
    class navmenu
    {
        

        public static void submenu()
        {
            bool selected = false;
            int position = 0;

            Console.WriteLine("");
            Console.WriteLine("Options:");
            Console.CursorTop = Console.CursorTop + 4;
            Console.WriteLine("");
            selector(0);
            
            while (selected == false)
            {  
                
                if (Console.ReadKey(true).Key == ConsoleKey.DownArrow)
                {
                    if (position == 4)
                    {
                        position = 3;
                        selector(position);
                    }
                    else
                    {
                        position++;
                        selector(position);
                    }
                    
                    
                }
                if (Console.ReadKey(true).Key == ConsoleKey.UpArrow)
                {
                    if(position == 0)
                    {

                    }
                    else
                    {
                        position--;
                        selector(position);
                    }
                    
                }
                
            }

            
        }

        public static void selector(int position)
        {
            if (position == 0)
            {
                clearline.clearcurrentline(6);
                Console.WriteLine(" ");
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
                clearline.clearcurrentline(6);
                Console.WriteLine(" ");
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
                clearline.clearcurrentline(6);
                Console.WriteLine(" ");
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
                clearline.clearcurrentline(6);
                Console.WriteLine(" ");
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
