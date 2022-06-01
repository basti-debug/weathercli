using System;
using System.De
public class LocationRequest
{
	public LocationRequest()
	{
        public static void GetLocationGPS()
        {
            GeoCoordinateWatcher watcher;
            watcher = new GeoCoordinateWatcher();

            watcher.PositionChanged += (sender, e) =>
            {
                var coordinate = e.Position.Location;
                double latitude = coordinate.Latitude;
                double longitude = coordinate.Longitude;
                // Uncomment to get only one event.
                watcher.Stop();
            };

            // Begin listening for location updates.
            watcher.Start();
        }
    }
}
