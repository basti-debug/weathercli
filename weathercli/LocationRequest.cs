using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Device.Location;
using Checkboxx;
using System.Globalization;
using System.Threading;


namespace weathercli
{   
    class locationrequest
    {
        public static string location;
        private bool done = false;

        GeoCoordinateWatcher watcher;

            public string getlocation()
            {
                Debug.WriteLine("get location...");
                this.watcher = new GeoCoordinateWatcher();
                this.watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
                bool started = this.watcher.TryStart(false, TimeSpan.FromMilliseconds(2000));
                if (!started)
                {
                    Console.WriteLine("GeoCoordinateWatcher timed out on start.");
                }


                void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
                {
                    NumberFormatInfo point = new CultureInfo("en-US", false).NumberFormat;
                    point.NumberDecimalSeparator = ".";
                    location = Convert.ToString(e.Position.Location.Latitude, point) + "," + Convert.ToString(e.Position.Location.Longitude, point);
                
                    if (!done)
                    {
                        done = true;
                    }

                }

                while (!done)
                {
                    Task.Delay(1);
                }

                Debug.WriteLine("location fetched");
                return location;
            
            }


        
        
            
            public async void geocode(string enteredlocation)
            {

                string[] larray = enteredlocation.Split(',');
                string trail = larray[0] + "%2C" + larray[1];
                
                Debug.WriteLine(enteredlocation);
                string url = String.Format("https://google-maps-geocoding.p.rapidapi.com/geocode/json?address={0}&language=en", trail);
                Debug.WriteLine(url);

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    Headers =
                    {
                            { "X-RapidAPI-Key", "669084b3c7msh56151ee8082858fp1b9eddjsnd5fd23b18432" },
                            { "X-RapidAPI-Host", "google-maps-geocoding.p.rapidapi.com" },
                    },

                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var dynamicresponse = JsonConvert.DeserializeObject<dynamic>(body);
                    Console.WriteLine(dynamicresponse.results.geometry.location.lat);
                    //location = Convert.ToString(dynamicresponse.results.geometry.location.lat + dynamicresponse.results.geometry.location.lng);
                    Console.WriteLine(location);
                }
                
            
            }      

    }
    
}