using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Globalization;
using System.IO;
using Checkboxx;
using System.Diagnostics;

namespace weathercli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-STARTING_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.SetWindowSize(48, 30);
            Console.WriteLine("weathercli V1");
            int auswahl = 0;
            string path = @"C:\Users\" + Environment.UserName + @"\Documents\weathercli";
            Debug.WriteLine(path);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            // Console.WriteLine(unix.convertunix(1655276264)); -- unix converter 

            //Api Request 

            CLocation myLocation = new CLocation();
            myLocation.GetLocationEvent();


            //Userinput
            Console.ReadLine();
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
                CLocation.Start();
                
            }
            else if(auswahl == 1)
            {
                weatherrequest.setAlert();
            }
            else if(auswahl == 2)
            {
                weatherrequest.options();
            }
            Console.ReadLine();
        }
    }

}
