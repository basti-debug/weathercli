using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace weathercli
{
    internal class weatherrequest
    {
        

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
            if (function == 1)
            { 
            
                if (weatherCache.weatherOld())
                {
                    int doublestop = 0;
                    Debug.WriteLine("getting weather from api in function 1");
                    string url = "https://aerisweather1.p.rapidapi.com/observations/" + location;    
                    Debug.WriteLine(url);
                    Debug.WriteLine(doublestop);
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),
                        Headers =
    {
        { "X-RapidAPI-Key", "cbaf259eb9mshdb3ee63e2cc038ep1a065fjsn3c08fd92c285" },
        { "X-RapidAPI-Host", "aerisweather1.p.rapidapi.com" },
    },
                    };
                    using (var response = await client.SendAsync(request))
                    {

                        Debug.WriteLine("got weather");
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
                { 
                    int doublestop = 0;
                    var dynamicresponse = JsonConvert.DeserializeObject<dynamic>(weatherCache.readCache());
                    Debug.WriteLine("USING OLD WEATHER");
                    if (doublestop == 0)
                    {
                        doublestop++;
                        
                            Console.WriteLine("The current weather is: ");
                            Console.WriteLine(dynamicresponse.response.ob.weather + " with " + dynamicresponse.response.ob.tempC + "°C in " + dynamicresponse.response.place.city);
                            weatherstatus.getvisu(Convert.ToString(dynamicresponse.response.ob.weather));

                            Console.WriteLine("");
                           
                            Console.WriteLine("");

                            
                            navmenu.submenu();
                            Console.ReadKey();

                    }
                }
            

            }

            if (function == 2)
            {
                Debug.WriteLine("getting weather from api in function 2");
                    string url = "https://aerisweather1.p.rapidapi.com/observations/" + location;
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),
                        Headers =
    {
        { "X-RapidAPI-Key", "cbaf259eb9mshdb3ee63e2cc038ep1a065fjsn3c08fd92c285" },
        { "X-RapidAPI-Host", "aerisweather1.p.rapidapi.com" },
    },
                    };
                    using (var response = await client.SendAsync(request))
                    {   
                        int doublestop = 0;
                        
                        Debug.WriteLine("got weather");
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
        }
    }
}
