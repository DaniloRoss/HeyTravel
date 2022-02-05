using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class StatoProva
    {
        public int id { get; set; }
        public string nome { get; set; }
        public List<CittaProva> eleCitta { get; set; }
        public Casi CasiCovid { get; set; }
        public Vaccini VacciniCovid { get; set; }
        public List<Meteo> eleMeteoGenerale { get; set; }
    }
    public class CittaProva
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
        public List<Aeroporto> eleAeroporti { get; set; }
        public Temperature Temperature { get; set; }
        public Precipitazioni Precipitazioni { get; set; }
        public OreSole OreSole { get; set; }
        public Mare Mare { get; set; }
    }
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
        public List<Citta> data { get; set; }
        public List<Link> links { get; set; }
        public Metadata metadata { get; set; }
    }
    public class Aeroporto
    {
        public string iataCode { get; set; }
        public string icaoCode { get; set; }
        public string name { get; set; }
        public string alpha2countryCode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
    public class RootAeroporto
    {
        public List<Aeroporto> eleAeroporti { get; set; }
    }
}
