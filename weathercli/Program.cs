using Microsoft.Toolkit.Uwp.Notifications;
using functions;

namespace weathercli
{
    class Program
    {  
        static void Main(string[] args)
        {
            /*public DateTime unixconv(int unix)
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
                dt = dt.AddSeconds(unix).ToLocalTime();
                return dt;
            }*/
            
            functions.notification.sendnotification(1,5,"s",20,"Rain");
        }
    }
}
