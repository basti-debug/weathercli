using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Checkboxx;

namespace weathercli
{
    internal class weatherrequest
    {
        static int doublestop = 0;
        static int maxage = 20;

        public static void currentWeather()
        {

        }
        public static void setAlert()
        {
        }
        public static void options()
        {
            int auswahl = 0;
            string checkboxHeadline = "What do you want to do?";
            string[] opts = { "get current weather age", "change update rate", "return to previous menu"};
            Checkbox startinput = new Checkbox(checkboxHeadline, opts);
            var res1 = startinput.Select();
            foreach (var checkboxReturn in res1)
            {
                auswahl = checkboxReturn.Index;
            }
            if (auswahl == 0)
            {
                int weatherdate = JsonConvert.DeserializeObject<dynamic>(weatherCache.readCache()).response.ob.timestamp;
                DateTime weathertime = unix.convertunix(weatherdate);
                DateTime currentTime = DateTime.Now;
                Console.WriteLine("Current saved weather is " + Convert.ToInt16(currentTime.Subtract(weathertime).TotalMinutes) + " minutes old.");
            }
            else if (auswahl == 1)
            {
               
                try
                {
                    Console.WriteLine("Please enter your new update rate (in minutes:");
                    maxage = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("invalid entry, only numbers allowed");
                }
            }
            else if(auswahl == 2)
            {
                userinput.startscreen();
            }
        }

        public static string returnvalue = "error";

        public static async void apirequest(int functions, string location)
        {
            if (weatherCache.weatherOld() == true)
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
                            Console.WriteLine("its " + dynamicresponse.response.ob.weather + " at " + dynamicresponse.response.ob.tempC + "°C in " + dynamicresponse.response.place.city);


                        }
                    }
                }

            }
            else if (weatherCache.weatherOld() != true)
            {
                var dynamicresponse = JsonConvert.DeserializeObject<dynamic>(weatherCache.readCache());
                Debug.WriteLine("USING OLD WEATHER");
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
                        Console.WriteLine("its " + dynamicresponse.response.ob.weather + " at " + dynamicresponse.response.ob.tempC + "°C in " + dynamicresponse.response.place.city);


                    }
                }
            }

        }
    }
}
