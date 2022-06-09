using System;
using System.Device.Location;
using Checkboxx;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using System.Threading;




namespace weathercli
{   
    class CLocation
    {
        public static double Latitude;
        public static double Longitude;
        public static string location;
        public static int auswahl2 = 0;

            GeoCoordinateWatcher watcher;

            public void GetLocationEvent()
            {
                this.watcher = new GeoCoordinateWatcher();
                this.watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
                bool started = this.watcher.TryStart(false, TimeSpan.FromMilliseconds(2000));
                if (!started)
                {
                    Console.WriteLine("GeoCoordinateWatcher timed out on start.");
                }
            }

            void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
            {
                PrintPosition(e.Position.Location.Latitude, e.Position.Location.Longitude);
            }

            void PrintPosition(double Latitude, double Longitude)
            {
                Console.WriteLine(Latitude +","+ Longitude);
            }
        
        public static void Start()
        {

        string checkboxHeadline2 = "Where do you want to see the weather from?";
        string[] opts2 = { "Device-GPS - may take a while", "enter manually" };
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

          CLocation myLocation = new CLocation();
                  myLocation.GetLocationEvent();
        }
        if (auswahl2 == 1)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the location you want to know the weather from: (city,countrycode)");
                    location = Console.ReadLine();
                    if (!location.Contains(",") || location.Any(c => char.IsDigit(c))) //Check if input contains a comma and doesnt contain a number
                    { throw new Exception("Locations must contain comma, and not contain any numbers"); };
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ungültige Eingabe");
                }
            }
        }
        }
            
        }
    
}