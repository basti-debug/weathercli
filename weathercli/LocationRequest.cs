using Checkboxx;
using System;
using System.Device.Location;
using System.Globalization;
using System.Threading.Tasks;
using System.Threading;
public class LocationRequest
{
    public static double Latitude;
    public static double Longitude;
    public static string location;
    public static int auswahl2 = 0;




    public static void Start()
    {
        string checkboxHeadline2 = "Where do you want to see the weather from?";
        string[] opts2 = { "Device-GPS", "enter manually" };
        Checkbox startinput = new Checkbox(checkboxHeadline2, opts2);
        var res1 = startinput.Select();
        NumberFormatInfo point = new CultureInfo("en-US", false).NumberFormat;
        point.NumberDecimalSeparator = ".";
        foreach (var checkboxReturn in res1)
        {
            auswahl2 = checkboxReturn.Index;
        }

        if (auswahl2 == 0)
        {
            GeoCoordinateWatcher watcher;
            watcher = new GeoCoordinateWatcher();

            watcher.PositionChanged += async (sender, e) =>
            {
                var coordinate = e.Position.Location;
                Latitude = coordinate.Latitude;
                Longitude = coordinate.Longitude;
                while (Latitude == 0) {; }
                //Console.WriteLine("Position has changed: Lat:" + Latitude + " Lon:" + Longitude);
                location = Convert.ToString(Latitude, point) + " " + Convert.ToString(Longitude, point);
                //Console.WriteLine(location);

            };

            // Begin listening for location updates.
            watcher.Start();
            Thread.Sleep(5000);

        }
        if(auswahl2 == 1)
        {
            Console.WriteLine("Enter the location you want to know the weather from: (city,countrycode)");
            location = Console.ReadLine();
        }

        //PRINTING EMPTY!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }
}
