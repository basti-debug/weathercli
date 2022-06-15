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
        public static void currentWeather()
        {
            apirequest();
        }
        public static void setAlert()
        {
            weatherCache.writeCache("teststring");
            weatherCache.readCache();
        }
        public static void options()
        {

        }
        public static async void apirequest()
        {
            if(weatherCache.weatherOld() == true)
            {
                string url = "https://aerisweather1.p.rapidapi.com/observations/" + CLocation.location;
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    Headers = {
                           { "X-RapidAPI-Key", "669084b3c7msh56151ee8082858fp1b9eddjsnd5fd23b18432" },
                           { "X-RapidAPI-Host", "aerisweather1.p.rapidapi.com" }, },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var dynamicresponse = JsonConvert.DeserializeObject<dynamic>(body);
                    weatherCache.writeCache(dynamicresponse.ToString());
                }
                Console.WriteLine(weatherCache.readCache());
            }
            
        }
    }
}
