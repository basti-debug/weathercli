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
        

        public static void showweather(string weather, string temp, string city)
        {
            weatherstatus.getvisu(weather);

            Console.WriteLine("");
            Console.WriteLine("its " + weather + " at " + temp + "°C in " + city);
            Console.WriteLine("");

            navmenu.submenu();
            Console.ReadKey();
        }


        public static string returnvalue = "error";

        public static async void apirequest(int function, string location)
        {
            // get normal weather for position 
            if (function == 1)
            { 
            
                if (weatherCache.weatherage()) //using fresh weather because cache isnt updated or doesnt exist
                {

                    int doublestop = 0;

                    Debug.WriteLine("\n-apirequest.weather-  fresh weather - getting weather from api in function 1  //step 1\n");

                    #region apirequest

                    string url = "https://aerisweather1.p.rapidapi.com/observations/" + location;
                    
                    Debug.WriteLine("\n-apirequest.weather-  " + url + "\n");
                    
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

                    #endregion

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var body = await response.Content.ReadAsStringAsync();
                        var dynamicresponse = JsonConvert.DeserializeObject<dynamic>(body);

                        Debug.WriteLine("\n-apirequest.weather-  got weather from api in function 1 //step 2\n");
                        
                        weatherCache.writeCache(dynamicresponse.ToString());
                        



                        if (doublestop == 0)
                        {
                            doublestop++;

                            Console.WriteLine("Current weather:");
                            showweather(dynamicresponse.response.ob.weather, dynamicresponse.response.ob.tempC, dynamicresponse.response.place.city);

                        }       
                    }

                }
                else if (weatherCache.weatherage() != true) //updated & current weather is available and will be used 
                { 
                    int doublestop = 0;
                    var dynamicresponse = JsonConvert.DeserializeObject<dynamic>(weatherCache.readCache());

                    Debug.WriteLine("\n-apirequest.weather-  using existing weather\n");
                    
                    if (doublestop == 0)
                    {
                        doublestop++;

                        Console.WriteLine("Current weather:");
                        showweather(dynamicresponse.response.ob.weather, dynamicresponse.response.ob.tempC, dynamicresponse.response.place.city);

                    }
                }
            

            }

            //get current weather from NEW position
            if (function == 2) 

            {
                #region apirequest
                Debug.WriteLine("\n-apirequest.weather-  getting weather from api in function 2");
                
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

                #endregion

                using (var response = await client.SendAsync(request))
                {   
                    int doublestop = 0;
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var dynamicresponse = JsonConvert.DeserializeObject<dynamic>(body);
                    
                    Debug.WriteLine("\n-apirequest.weather-  got weather from api  //function 2 ");
                    
                    weatherCache.writeCache(dynamicresponse.ToString());


                    if (doublestop == 0)
                    {
                        doublestop++;

                        Console.WriteLine("Current weather:");
                        showweather(dynamicresponse.response.ob.weather, dynamicresponse.response.ob.tempC, dynamicresponse.response.place.city);

                    }
                    }
            }
        }
    }
}
