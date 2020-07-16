using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Lab09_LINQ.Classes;
using System.Linq;

namespace Lab09_LINQ
{
    class Program
    {
        public static Root JsonData { get; set; }


        static void Main(string[] args)
        {
            GetJson();
        }


        public static void GetJson()
        {
            string jsonString = File.ReadAllText("../../../../data.json");
            JsonData = JsonConvert.DeserializeObject<Root>(jsonString);
            
        }

        public static void OutputAll()
        {
            foreach (var item in JsonData.features)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
            Console.WriteLine($"Total: {JsonData.features.Count()}, press any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void FilterNoNameNeighborhoods()
        {
            Root filteredData = JsonData.features.Select(x => x.properties.neighborhood != "");
        }


    }

}
