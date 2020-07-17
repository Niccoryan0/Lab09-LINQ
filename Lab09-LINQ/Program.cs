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
            OutputAll();
            IEnumerable<Features> noNoNames = FilterNoNameNeighborhoods(JsonData);
            OnlyDistinctNeighborhoods(noNoNames);
            ConsolidatedMethods();
            FilterNoNamesWithQueryStatements();
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

        public static IEnumerable<Features> FilterNoNameNeighborhoods(Root data)
        {
            IEnumerable<Features> filteredData = data.features.Where(x => x.properties.neighborhood != "");
            foreach (var item in filteredData)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
            Console.WriteLine($"Total: {filteredData.Count()}, press any key to continue.");
            Console.ReadLine();
            Console.Clear();
            return filteredData;
        }

        public static IEnumerable<string> OnlyDistinctNeighborhoods(IEnumerable<Features> data)
        {
            IEnumerable<string> filteredData = data.Select(x => x.properties.neighborhood).Distinct();
            foreach (var item in filteredData)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total: {filteredData.Count()}, press any key to continue(Next screen will be same items, but LINQ queries are consolidated).");
            Console.ReadLine();
            Console.Clear();
            return filteredData;
        }

        public static void ConsolidatedMethods()
        {
            IEnumerable<string> data = JsonData.features.Where(x => x.properties.neighborhood != "")
                                                        .Select(x => x.properties.neighborhood)
                                                        .Distinct();
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total: {data.Count()}, press any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void FilterNoNamesWithQueryStatements()
        {
            IEnumerable<Features> data = from location in JsonData.features
                                           where location.properties.neighborhood != ""
                                           select location;
            foreach (var item in data)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
            Console.WriteLine($"Total: {data.Count()}, press any key to exit the program.");
            Console.ReadLine();
            Console.Clear();
        }

    }

}
