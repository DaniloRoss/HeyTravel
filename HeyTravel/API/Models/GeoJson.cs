using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
        public class Properties
        {
            public string type { get; set; }
            public string name { get; set; }            
            public decimal casi { get; set; }
        }

        public class Geometry
        {
            public string type { get; set; }
            public List<List<List<object>>> coordinates { get; set; }
        }

        public class Feature
        {
            public string type { get; set; }
            public Properties properties { get; set; }
            public Geometry geometry { get; set; }
        }

        public class GeoJson
        {
            public string type { get; set; }
            public List<Feature> features { get; set; }
        }
}
