using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;

namespace functions
{
    public class notification
    {     
        //<summary> 
        //type == type of notification 
        //</summary> 

        public static void sendnotification(int type, int wind, string direction, int temp, string state, string location, string timeuntil, string customtext)
        {
           
            if (type == 1)
            {
                string winddirection = "?";
                if (direction == "n")
                {
                    winddirection = "north";
                }
                if (direction == "s")
                {
                    winddirection = "south";
                }
                if (direction == "e")
                {
                    winddirection = "east";
                }
                if (direction == "w")
                {
                    winddirection = "west";
                }
            new ToastContentBuilder()
            .AddText("Hop on your sailboat", hintMaxLines: 1)
            .AddText(state + " " + temp + " °C")
            .AddText(wind +" kn" + " direction: " + winddirection)
            .Show();
            }

            if (type == 2) // Weather in Notification 
            {
                new ToastContentBuilder()
                .AddText(state + " " + temp + " °C", hintMaxLines: 1)
                .AddAttributionText("in " + location)
                .Show();
            }
            if (type == 3) // Storm Message
            {
                new ToastContentBuilder()
                .AddText("Looks like a " + state + " is comming :( ")
                .AddText("it will hit you probably at " + timeuntil, hintMaxLines: 1)
                .Show();
            }
            if (type == 4) // Custom Message 
            {
                new ToastContentBuilder()
               .AddText(customtext)
               .AddAttributionText("weathercli settings")
               .Show();
            }
        }
           
    }
}
