using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Globalization;

namespace weathercli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //public static DateTime unixconv(int unix)
            //{
            //    DateTime dt = new DateTime(1970,1,1,0,0,0,0,DateTime.UtcNow);
            //    dt = dt.AddSeconds( unix ).ToLocalTime();
            //    return dt;
            //}
            NumberFormatInfo point = new CultureInfo("en-US", false).NumberFormat;
            point.NumberDecimalSeparator = ".";
            LocationRequest.Start();
            Console.WriteLine(LocationRequest.Latitude.ToString(point) + " " + LocationRequest.Longitude.ToString(point));
            Console.ReadKey();
        }
    }
    
}
