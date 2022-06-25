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
                Debug.WriteLine("\n-getlocation-  get location...");
                this.watcher = new GeoCoordinateWatcher();
                this.watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
                bool started = this.watcher.TryStart(false, TimeSpan.FromMilliseconds(2000));
                if (!started)
                {
                    Console.WriteLine("\n-getlocation-  GeoCoordinateWatcher timed out on start.");
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
                
                Debug.WriteLine("\n-getlocation-  location fetched\n");
                return location;
            
            } 
    }
}
