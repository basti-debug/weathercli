using System;
using System.Device.Location;
using System.Globalization;
public class LocationRequest
{
    public static double Latitude;
    public static double Longitude;



    public static void Start()
        {
            GeoCoordinateWatcher watcher;
            watcher = new GeoCoordinateWatcher();

            watcher.PositionChanged += (sender, e) =>
            {
                var coordinate = e.Position.Location;
                Latitude = coordinate.Latitude;
                Longitude = coordinate.Longitude;
                //Console.WriteLine("Position has changed: Lat:" + Latitude + " Lon:" + Longitude);
            };

            // Begin listening for location updates.
            watcher.Start();
            while(Latitude == 0 || Longitude == 0){;}
        }
    
}
