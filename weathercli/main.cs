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
                #region caching?

                Console.Write("Do you want to use your local ");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(".json");
                Console.BackgroundColor= ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Cache?");
                Console.WriteLine("or do you wana check the current weather with the api?");
                Console.WriteLine("Select: c/r");


                string selection = "r";
                selection = Console.ReadLine();

                if (selection == "c") //cache selected       route 1
                {
                    Console.Clear();
                    Console.WriteLine("Data may be outdated...");
                    Console.WriteLine("");
                    Console.WriteLine("Note: The 'Chance Location' function may not work,");
                    Console.WriteLine("if you dont have any api requests left");
                    Console.WriteLine("");

                    int doublestop = 0;
                    
                    var dynamicresponse = JsonConvert.DeserializeObject<dynamic>(weatherCache.readCache());
                    
                    

                    Debug.WriteLine("\n-main-  using chache data  //route 1\n");

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
                else //when request selected        route 2
                {
                    Console.Clear();
                    Console.WriteLine("getting the location of your device..");

                    Debug.WriteLine("\n-main-  request selected  //route 2\n");

                    //get location
                    locationrequest a = new locationrequest();
                    string location = a.getlocation();

                    Console.Clear();
                    //use apirequest function 1 to send location to api
                    weatherrequest.apirequest(1, location);
                    Console.ReadKey();
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
