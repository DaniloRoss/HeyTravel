using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Citta
    {
        public int id { get; set; }
        public string wikiDataId { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string region { get; set; }
        public object regionCode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int population { get; set; }
    }
    public class CittaAPI
    {
        public int id { get; set; }
        public string wikiDataId { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string region { get; set; }
        public object regionCode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
    
    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class Metadata
    {
        public int currentOffset { get; set; }
        public int totalCount { get; set; }
    }

    public class RootCitta
    {
        public List<CittaAPI> data { get; set; }
        public List<Link> links { get; set; }
        public Metadata metadata { get; set; }
    }
}
