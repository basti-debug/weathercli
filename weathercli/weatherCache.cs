using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace weathercli
{
    internal class weatherCache
    {
        public static bool weatherOld()
        {

            return true;
        }
       public static string readCache()
        {
            string weather = File.ReadAllText(@"C:\Users\joelr\Documents\weathercli\weather.json");
            //var weatherser = JsonConvert.DeserializeObject<dynamic>(weather);
            Console.WriteLine(weather);
            return weather;
        }
       public static void writeCache(string Datei)
        {
            File.WriteAllText(@"C:\Users\joelr\Documents\weathercli\weather.json", Datei);
        }
        public static bool weatherAvailable()
        {
            if(File.Exists(@"C:\Users\joelr\Documents\weather.json"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
