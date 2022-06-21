using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace weathercli
{
    internal class weatherrequest
    {
        static int doublestop = 0;

        public static void currentWeather()
        {

        }
        public static void setAlert()
        {
        }
        public static void options()
        {

        }

        public static string returnvalue = "error";

        public static async void apirequest(int function, string location)
        {
            if(function == 1)
            {
                /*if (weatherCache.weatherOld())
                {
                    Debug.WriteLine("-----------------------GETTING NEW WEATHER FROM API-----------------------");
                    string url = "https://aerisweather1.p.rapidapi.com/observations/" + location;
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),
                        Headers =
    {
        { "X-RapidAPI-Key", "669084b3c7msh56151ee8082858fp1b9eddjsnd5fd23b18432" },
        { "X-RapidAPI-Host", "aerisweather1.p.rapidapi.com" },
    },
                    };
                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var body = await response.Content.ReadAsStringAsync();
                        var dynamicresponse = JsonConvert.DeserializeObject<dynamic>(body);
                        Debug.WriteLine("GOT WEATHER FROM API");
                        weatherCache.writeCache(dynamicresponse.ToString());


                        if (doublestop == 0)
                        {
                            doublestop++;
                            
                                Console.WriteLine("The current weather: ");

                                weatherstatus.getvisu(Convert.ToString(dynamicresponse.response.ob.weather));

                                Console.WriteLine("");
                                Console.WriteLine("its " + dynamicresponse.response.ob.weather + " at " + dynamicresponse.response.ob.tempC + "°C in " + dynamicresponse.response.place.city);
                                Console.WriteLine("");

                                navmenu.submenu();
                        }
                    }

                }
                else if (weatherCache.weatherOld() != true)
                { */
                    var dynamicresponse = JsonConvert.DeserializeObject<dynamic>(weatherCache.readCache());
                    Debug.WriteLine("USING OLD WEATHER");
                    if (doublestop == 0)
                    {
                        doublestop++;
                        
                            Console.WriteLine("The current weather: ");

                            weatherstatus.getvisu(Convert.ToString(dynamicresponse.response.ob.weather));

                            Console.WriteLine("");
                            Console.WriteLine("its " + dynamicresponse.response.ob.weather + " at " + dynamicresponse.response.ob.tempC + "°C in " + dynamicresponse.response.place.city);
                            Console.WriteLine("");

                            navmenu.submenu();

                    }
                //}
            }

            if (function == 2)
            {
                var dynamicresponse = JsonConvert.DeserializeObject<dynamic>(weatherCache.readCache())
                    
            }


        }
    }
}
