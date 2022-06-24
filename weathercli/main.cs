using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;

namespace weathercli
{
    internal class main
    {
        public static void start()
        {

            // check network status

            bool net = networkinfo.getnetinfo();           
            
            if (net) // network is available 
            {
                //get location
                locationrequest a = new locationrequest();
                string location = a.getlocation();

                #region caching?

                Console.WriteLine("use cache or send request?:  (c/r)");
                string selection = "r";
                selection = Console.ReadLine();

                if (selection == "c") //cache selected
                {
                    Console.Clear();
                    Console.WriteLine("Data may be outdated...");
                    
                    int doublestop = 0;
                    var dynamicresponse = JsonConvert.DeserializeObject<dynamic>(weatherCache.readCache());

                    Debug.WriteLine("\n-main-  using chache data\n");

                    if (doublestop == 0)
                    {
                        doublestop++;

                        int timestamp = Convert.ToInt32(dynamicresponse.response.obTimestamp);
                        Console.WriteLine("weather from the " + unix.convertunix(timestamp));

                        weatherstatus.getvisu(Convert.ToString(dynamicresponse.response.ob.weather));

                        Console.WriteLine("");
                        Console.WriteLine("its " + dynamicresponse.response.ob.weather + " at " + dynamicresponse.response.ob.tempC + "°C in " + dynamicresponse.response.place.city);
                        Console.WriteLine("");

                        navmenu.submenu();
                        Console.ReadKey();

                    }
                }
                else //when request selected
                {
                    //use apirequest function 1 to send location to api
                    weatherrequest.apirequest(1, location);
                    Console.WriteLine("");
                }

                #endregion

            }
            if (!net) // network isnt reachable 
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
