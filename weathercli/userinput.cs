using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkboxx;

namespace weathercli
{
    internal class userinput
    {
        public static void startscreen()
        {

            int auswahl = 0;
            string checkboxHeadline = "What do you want to do?";
            string[] opts = { "Get current weather", "set weather alert", "options" };
            Checkbox startinput = new Checkbox(checkboxHeadline, opts);
            var res1 = startinput.Select();
            foreach (var checkboxReturn in res1)
            {
                auswahl = checkboxReturn.Index;
            }
            if (auswahl == 0)
            {
                weatherrequest.currentWeather();
            }
            else if (auswahl == 1)
            {
                weatherrequest.setAlert();
            }
            else if (auswahl == 2)
            {
                weatherrequest.options();
            }
            Console.ReadLine();
        }
    }
}
