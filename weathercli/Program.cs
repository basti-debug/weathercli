using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Globalization;
using Checkboxx;

namespace weathercli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int auswahl = 0;
            //unixtime
            //public static DateTime unixconv(int unix)
            //{
            //    DateTime dt = new DateTime(1970,1,1,0,0,0,0,DateTime.UtcNow);
            //    dt = dt.AddSeconds( unix ).ToLocalTime();
            //    return dt;
            //}

            //Numberformat
            NumberFormatInfo point = new CultureInfo("en-US", false).NumberFormat;
            point.NumberDecimalSeparator = ".";
            //Userinput
            string checkboxHeadline = "What do you want to do?";
            string[] opts = { "Get current weather", "set weather alert", "options"};
            Checkbox startinput = new Checkbox(checkboxHeadline, opts);
            var res1 = startinput.Select();
            foreach (var checkboxReturn in res1)
            {
                auswahl = checkboxReturn.Index;
            }
            if(auswahl == 0)
            {
                weatherrequest.currentWeather();
            }
            else if(auswahl == 1)
            {
                weatherrequest.setAlert();
            }
            else if(auswahl == 2)
            {
                weatherrequest.options();
            }
        }
    }
    
}
