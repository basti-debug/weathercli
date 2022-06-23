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
                location = null;
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
                using ( var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var dynr = JsonConvert.DeserializeObject<Rootobject>(body);
                    
                foreach (var d in dynr.results)
                {
                    Console.WriteLine(d);
                }
                    
                    //location = Convert.ToString(dynamicresponse.results.address_components);
                    Console.WriteLine(location);
                    
                }
                
            
            }      

        
public class Rootobject
{
public Result[] results { get; set; }
public string status { get; set; }
}

public class Result
{
public Address_Components[] address_components { get; set; }
public string formatted_address { get; set; }
public Geometry geometry { get; set; }
public string place_id { get; set; }
public string[] types { get; set; }
}

public class Geometry
{
public Bounds bounds { get; set; }
public Location location { get; set; }
public string location_type { get; set; }
public Viewport viewport { get; set; }
}

public class Bounds
{
public Northeast northeast { get; set; }
public Southwest southwest { get; set; }
}

public class Northeast
{
public float lat { get; set; }
public float lng { get; set; }
}

public class Southwest
{
public float lat { get; set; }
public float lng { get; set; }
}

public class Location
{
public float lat { get; set; }
public float lng { get; set; }
}

public class Viewport
{
public Northeast1 northeast { get; set; }
public Southwest1 southwest { get; set; }
}

public class Northeast1
{
public float lat { get; set; }
public float lng { get; set; }
}

public class Southwest1
{
public float lat { get; set; }
public float lng { get; set; }
}

public class Address_Components
{
public string long_name { get; set; }
public string short_name { get; set; }
public string[] types { get; set; }
}

    }
    
}