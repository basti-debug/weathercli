using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Globalization;
using System.IO;
using Checkboxx;

namespace weathercli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(48, 30);
            Console.WriteLine("weathercli V1");
            int auswahl = 0;

            if (!Directory.Exists(@"C:\Users\basti\Documents\weathercli"))
            {
                Directory.CreateDirectory(@"C:\Users\basti\Documents\weathercli");
            }


            // Console.WriteLine(unix.convertunix(1655276264)); -- unix converter 

            //Api Request 

            CLocation myLocation = new CLocation();
            myLocation.GetLocationEvent();


            //Userinput
            /*
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
            */
            Console.ReadLine();
        }
    }

}
