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
        public static bool weatherOld()
        {
            if (weatherAvailable()!=true)
            {
                Debug.WriteLine("WEATHER WAS NOT AVAILABLE AND GOT OUTPUTTED AS OLD");
                return true;
            }
            int weatherdate = JsonConvert.DeserializeObject<dynamic>(readCache()).response.ob.timestamp;
            DateTime weathertime = unix.convertunix(weatherdate);
            DateTime currentTime = DateTime.Now;
            if(Convert.ToInt16(currentTime.Subtract(weathertime).TotalMinutes) >= 20)
            {
                Debug.WriteLine("WEATHERAGE: " + Convert.ToInt16(currentTime.Subtract(weathertime).TotalMinutes));
                Debug.WriteLine("WEATHER IS OLD");
                return true;
            }
            else
            {
                Debug.WriteLine("WEATHER IS NOT OLD");
                return false;
            }
        }
       public static string readCache()
        {
            string path = @"C:\Users\" + Environment.UserName + @"\Documents\weathercli\weather.json";
            string weather = File.ReadAllText(path);
            //var weatherser = JsonConvert.DeserializeObject<dynamic>(weather);
            Debug.WriteLine("READING CACHE");
            return weather;
        }
       public static void writeCache(string Datei)
        {
            string path = @"C:\Users\" + Environment.UserName + @"\Documents\weathercli\weather.json";
            File.WriteAllText(path, Datei);
            Debug.WriteLine("WRITING CACHE");
        }
        public static bool weatherAvailable()
        {
            string path = @"C:\Users\" + Environment.UserName + @"\Documents\weathercli\weather.json";
            Debug.WriteLine("CHECKING IF WEATHER AVAILABLE");
            if(File.Exists(path))
            {
                Debug.WriteLine("--WEATHER IS AVAILABLE");
                return true;
            }
            else
            {
                Debug.WriteLine("--WEATHER IS NOT AVAILABLE");
                return false;
            }
        }

    }
}
