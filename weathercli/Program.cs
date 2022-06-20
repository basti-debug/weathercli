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


            string path = @"C:\Users\" + Environment.UserName + @"\Documents\weathercli";
            Debug.WriteLine(path);

            // creating path for caching
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            // get network info

            bool net = networkinfo.getnetinfo();


            // switch when network 
            if (net)
            {
                // get current user location 
                CLocation myLocation = new CLocation();
                string location = myLocation.getlocation();

                Console.WriteLine("");

                weatherrequest.apirequest(1, location);
            }
            if (!net)
            {
                Console.WriteLine("Restart the application if your network is back...");
            }
                      

            Console.ReadLine();
        }
    }

}
