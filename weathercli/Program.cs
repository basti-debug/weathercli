using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Globalization;
using System.IO;
using Checkboxx;
using System.Diagnostics;

namespace weathercli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("\n-main-  main start");


            Console.SetWindowSize(50,30);
            Console.WriteLine("weathercli V0.100");
            Console.ForegroundColor = ConsoleColor.White;

            string path = @"C:\Users\" + Environment.UserName + @"\Documents\weathercli";

            // creating path for caching
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            
            main.start();

         
          
                        
            
        }
    }

}
