using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace weathercli
{
    internal class networkinfo
    {
        public static bool getnetinfo()
        {
            Debug.WriteLine("\n-networkinfo-  network test started...\n");
            string host = ("www.google.com");  
            
                bool result = false;
            
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                {
                }
                result = true;
                return result;
                Debug.WriteLine("\n-networkinfo-  device is connected to the internet");
            }
            catch {
                Debug.WriteLine("\n-networkinfo-  device is not connected to the internet");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"  
            
Error 404
no network connection
            
please check your network connection
                                            ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
          return result;

            
        }
    }
}
