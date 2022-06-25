using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace weathercli
{
    internal class weatherCache
    {
        public static bool weatherage() //Checks how old the cache is 
        {
            if (weatherAvailable()!=true) 
            {
                Debug.WriteLine("\n-cache-  weather isnt available on device -- function returened old\n");
                return true;
            }
            int weatherdate = JsonConvert.DeserializeObject<dynamic>(readCache()).response.ob.timestamp;
            DateTime weathertime = unix.convertunix(weatherdate);
            DateTime currentTime = DateTime.Now;
            if(Convert.ToInt16(currentTime.Subtract(weathertime).TotalMinutes) >= 20)
            {
                Debug.WriteLine("\n-cache-  weather last updated: " + Convert.ToInt16(currentTime.Subtract(weathertime).TotalMinutes)+ "\n");
                Debug.WriteLine("\n-cache-  weather is too old\n");
                return true;
            }
            else
            {
                Debug.WriteLine("\n-cache-  weather is okay");
                return false;
            }
        }
       public static string readCache() //read chache
        {
            string path = @"C:\Users\" + Environment.UserName + @"\Documents\weathercli\weather.json";
            string weather = File.ReadAllText(path);
            //var weatherser = JsonConvert.DeserializeObject<dynamic>(weather);
            Debug.WriteLine("\n-cache-  reading out cache\n");
            return weather;
        }
       public static void writeCache(string Datei)
        {                                                                                                  
            string path = @"C:\Users\" + Environment.UserName + @"\Documents\weathercli\weather.json";
            File.WriteAllText(path, Datei);
            Debug.WriteLine("\n-cache-  writing json in cache, location: " + path + "\n");
        }
        public static bool weatherAvailable()
        {
            string path = @"C:\Users\" + Environment.UserName + @"\Documents\weathercli\weather.json";
            Debug.WriteLine("\n-cache-  checking if weather exists on the device");
            if(File.Exists(path))
            {
                Debug.WriteLine("\n-cache-  weather exists on the device");
                return true;
            }
            else
            {
                Debug.WriteLine("\n-cache-  weather doesnt exist on device");
                return false;
            }
        }

    }
}
