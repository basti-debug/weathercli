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
                locationrequest a = new locationrequest();
                
                string location = a.getlocation();

                Console.WriteLine(" ");
                Console.WriteLine("network sucess");
                Console.WriteLine(location);
                weatherrequest.apirequest(1,location);
                Console.ReadKey();

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
