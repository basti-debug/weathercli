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
        public static void sendnotification(int type)
        {
            new ToastContentBuilder().AddText("test Type Number: "+ type).Show();
        }
           
    }
}
