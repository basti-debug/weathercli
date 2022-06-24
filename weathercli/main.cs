using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weathercli
{
    internal class main
    {
        public static void start()
        {
            // get network info

            bool net = networkinfo.getnetinfo();


            // switch when network 
            if (net)
            {
                //get location
                locationrequest a = new locationrequest();
                string location = a.getlocation();

                //use apirequest function 1 to send location to api
                weatherrequest.apirequest(1,location);
                Console.WriteLine("");

            }
            if (!net)
            {
                Console.WriteLine("");
                Console.WriteLine("your network is back ? \n press the any key ");
                Console.ReadKey();
                Console.Clear();
                start();
                
            }
        }
    }
}
