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
        public static string path = @"C:\Users\" + Environment.UserName + @"\Documents\weathercli";
        static void Main(string[] args)
        {
            Debug.WriteLine("\n-main-  main start");


            Console.SetWindowSize(60,40);
            Console.WriteLine("weathercli V0.102");
            
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(" ");
            Console.WriteLine("made by basti.debug & joel05");
            Console.WriteLine(" ");

           

            // creating path for caching
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            
            main.start();

         
          
                        
            
        }
    }

}
