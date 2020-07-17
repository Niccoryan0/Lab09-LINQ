using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace Lab09_LINQ.Classes
{
    public class Root
    {
        public string type { get; set; }
        public IEnumerable<Features> features { get; set; }
    }
}
