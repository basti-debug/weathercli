using Microsoft.Toolkit.Uwp.Notifications;
using functions;

namespace weathercli
{
    class Program
    {  
        static void Main(string[] args)
        {
            //public DateTime unixconv(int unix)
            //{
            //    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            //    dt = dt.AddSeconds(unix).ToLocalTime();
            //    return dt;
            //}

            functions.notification.sendnotification(1, 30, "e", 10, "Cloudy", "Slough", "3am", "");
            functions.notification.sendnotification(3,5,"s",20,"Rain","Hard","2pm","");
            functions.notification.sendnotification(2, 5, "s", 20, "Sunny", "London", "8am","");
            functions.notification.sendnotification(4, 15, "n", 10, "", "", "", "your Alerts are disabled");

        }
    }
}
