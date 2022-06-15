using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            weatherCache.writeCache("teststring");
            weatherCache.readCache();
        }
        public static void options()
        {

        }

        public static string returnvalue= "error";

        public static async void apirequest(int functions, string location)
        {
            if (weatherCache.weatherOld() == true)
            {

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
                    weatherCache.writeCache(dynamicresponse.ToString());


                    if (doublestop == 0)
                    {
                        doublestop++;
                        if (functions == 1)
                        {
                            Console.WriteLine("The current weather: ");
                            if (dynamicresponse.response.ob.weather == "Mostly Cloudy")
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine(@"      
        .-~~~-.
.- ~ ~-(       )_ 
/                 ~ -.
|                      \
\                       .
  ~- . _____________.-~)
                                ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (dynamicresponse.response.ob.weather == "Mostly Sunny")
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(@"      
      ;   :   ;
   .   \_,!,_/   ,
    `.,'     `.,'
     /         \
~ -- :         : -- ~
     \         /
    ,'`._   _.'`.
   '   / `!` \   `
      ;   :   ;                                 ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine();
                            Console.WriteLine("its " + dynamicresponse.response.ob.weather + " at " + dynamicresponse.response.ob.tempC +"°C in " + dynamicresponse.response.place.city);


                        }
                    }
                }

            }
        }
    }
}
