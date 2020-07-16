using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace Lab09_LINQ.Classes
{
    public class Features
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }
}
