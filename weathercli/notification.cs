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
        public static void sendnotification(int type, int wind, string direction, int temp, string state)
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
                new ToastContentBuilder()
            .AddText("Hop on your sailboat", hintMaxLines: 1)
            .AddText(state + " " + temp + " °C")
            .AddText(wind +" kn" + " direction: " + winddirection)
            .Show();
            }
            
        }
           
    }
}
