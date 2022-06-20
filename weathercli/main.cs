using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weathercli
{
    internal class main
    {
        public static async void start()
        {
            // get network info

            bool net = networkinfo.getnetinfo();


            // switch when network 
            if (net)
            {
                // get current user location 
                CLocation myLocation = new CLocation();
                string location = myLocation.getlocation();

                Console.WriteLine(" ");

                weatherrequest.apirequest(1, location);

            }
            if (!net)
            {
                Console.WriteLine("Restart the application if your network is back...");
                Console.WriteLine("");
                Console.WriteLine("your network is back ? \n press the any key ");
                Console.ReadKey();
                Console.Clear();
                start();
                
            }
        }
    }
}
