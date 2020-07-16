using System;
using Newtonsoft.Json;

namespace Lab09_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }



        // Reference from: https://dotnettec.com/newtonsoft-json-serialize-and-deserialize/
        //public static object Deserialize(string path)
        //{
        //    var serializer = new JsonSerializer();
        //    using (var sw = new StreamReader(path))
        //    using (var reader = new JsonTextReader(sw))
        //    {
        //        return serializer.Deserialize(reader);
        //    }
        //}
    }
}
