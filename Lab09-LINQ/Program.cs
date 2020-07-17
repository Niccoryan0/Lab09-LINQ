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

        /// <summary>
        /// Runs each method to output the information for the lab.
        /// </summary>
        static void Main()
        {
            GetJson();
            OutputAll();
            IEnumerable<Features> noNoNames = FilterNoNameNeighborhoods(JsonData);
            OnlyDistinctNeighborhoods(noNoNames);
            ConsolidatedMethods();
            FilterNoNamesWithQueryStatements();
        }

        /// <summary>
        /// Deserialize JSON data
        /// </summary>
        public static void GetJson()
        {
            string jsonString = File.ReadAllText("../../../../data.json");
            JsonData = JsonConvert.DeserializeObject<Root>(jsonString);
        }

        /// <summary>
        /// Output all the neighborhood names from the JSON data
        /// </summary>
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

        /// <summary>
        /// Outputs all neighborhood names that aren't empty
        /// </summary>
        /// <param name="data">Data to be queried</param>
        /// <returns>Filtered data</returns>
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

        /// <summary>
        /// Filters the neighborhood data to only unique neighborhood names
        /// </summary>
        /// <param name="data">Data to be filtered</param>
        /// <returns>Filtered data</returns>
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

        /// <summary>
        /// Filters data down to non-empty unique neighborhood names in one string of methods
        /// </summary>
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

        /// <summary>
        /// Filter out unnamed neighborhoods using a query statement
        /// </summary>
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
