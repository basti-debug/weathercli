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
            Debug.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-STARTING_-_-_-_-_-_-_-_-_-_-_-_-_-_-");


            Console.SetWindowSize(48, 30);
            Console.WriteLine("weathercli V1");
            Console.ForegroundColor = ConsoleColor.White;

            string path = @"C:\Users\" + Environment.UserName + @"\Documents\weathercli";
            Debug.WriteLine(path);

            // creating path for caching
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            main.start();
         
            Console.ReadKey();
            
                        
            
        }
    }

}
