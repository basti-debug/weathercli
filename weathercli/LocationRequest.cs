using System;
using System.Device.Location;
using Checkboxx;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;



namespace weathercli
{   
    class CLocation
    {
        public static string location;
        public static int auswahl2 = 0;
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
                
                    if (done == false)
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

       


       
            
    }
    
}