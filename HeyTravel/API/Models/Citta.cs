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
        //public int id { get; set; }
        //public string wikiDataId { get; set; }
        //public string type { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        //public string countryCode { get; set; }
        //public string region { get; set; }
        //public object regionCode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
    public class LocalNames
    {
        public string af { get; set; }
        public string ar { get; set; }
        public string ascii { get; set; }
        public string az { get; set; }
        public string bg { get; set; }
        public string ca { get; set; }
        public string da { get; set; }
        public string de { get; set; }
        public string el { get; set; }
        public string en { get; set; }
        public string eu { get; set; }
        public string fa { get; set; }
        public string feature_name { get; set; }
        public string fi { get; set; }
        public string fr { get; set; }
        public string gl { get; set; }
        public string he { get; set; }
        public string hi { get; set; }
        public string hr { get; set; }
        public string hu { get; set; }
        public string id { get; set; }
        public string it { get; set; }
        public string ja { get; set; }
        public string la { get; set; }
        public string lt { get; set; }
        public string mk { get; set; }
        public string nl { get; set; }
        public string no { get; set; }
        public string pl { get; set; }
        public string pt { get; set; }
        public string ro { get; set; }
        public string ru { get; set; }
        public string sk { get; set; }
        public string sl { get; set; }
        public string sr { get; set; }
        public string th { get; set; }
        public string tr { get; set; }
        public string vi { get; set; }
        public string zu { get; set; }
    }

    public class Root
    {
        public string name { get; set; }
        public LocalNames local_names { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string country { get; set; }
        public string state { get; set; }
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
    public class Ita
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class NativeName
    {
        public Ita ita { get; set; }
    }

    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }
        public NativeName nativeName { get; set; }
    }

    public class EUR
    {
        public string name { get; set; }
        public string symbol { get; set; }
    }

    public class Currencies
    {
        public EUR EUR { get; set; }
    }

    public class Idd
    {
        public string root { get; set; }
        public List<string> suffixes { get; set; }
    }

    public class Languages
    {
        public string ita { get; set; }
    }

    public class Ara
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Ces
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Cym
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Deu
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Est
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Fin
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Fra
    {
        public string official { get; set; }
        public string common { get; set; }
        public string f { get; set; }
        public string m { get; set; }
    }

    public class Hrv
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Hun
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Jpn
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Kor
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Nld
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Per
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Pol
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Por
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Rus
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Slk
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Spa
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Swe
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Urd
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Zho
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Translations
    {
        public Ara ara { get; set; }
        public Ces ces { get; set; }
        public Cym cym { get; set; }
        public Deu deu { get; set; }
        public Est est { get; set; }
        public Fin fin { get; set; }
        public Fra fra { get; set; }
        public Hrv hrv { get; set; }
        public Hun hun { get; set; }
        public Ita ita { get; set; }
        public Jpn jpn { get; set; }
        public Kor kor { get; set; }
        public Nld nld { get; set; }
        public Per per { get; set; }
        public Pol pol { get; set; }
        public Por por { get; set; }
        public Rus rus { get; set; }
        public Slk slk { get; set; }
        public Spa spa { get; set; }
        public Swe swe { get; set; }
        public Urd urd { get; set; }
        public Zho zho { get; set; }
    }

    public class Eng
    {
        public string f { get; set; }
        public string m { get; set; }
    }

    public class Demonyms
    {
        public Eng eng { get; set; }
        public Fra fra { get; set; }
    }

    public class Maps
    {
        public string googleMaps { get; set; }
        public string openStreetMaps { get; set; }
    }

    public class Gini
    {
        public double _2017 { get; set; }
    }

    public class Car
    {
        public List<string> signs { get; set; }
        public string side { get; set; }
    }

    public class Flags
    {
        public string png { get; set; }
        public string svg { get; set; }
    }

    public class CoatOfArms
    {
        public string png { get; set; }
        public string svg { get; set; }
    }

    public class CapitalInfo
    {
        public List<double> latlng { get; set; }
    }

    public class PostalCode
    {
        public string format { get; set; }
        public string regex { get; set; }
    }

    public class RootCode
    {
        public Name name { get; set; }
        public List<string> tld { get; set; }
        public string cca2 { get; set; }
        public string ccn3 { get; set; }
        public string cca3 { get; set; }
        public string cioc { get; set; }
        public bool independent { get; set; }
        public string status { get; set; }
        public bool unMember { get; set; }
        public Currencies currencies { get; set; }
        public Idd idd { get; set; }
        public List<string> capital { get; set; }
        public List<string> altSpellings { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public Languages languages { get; set; }
        public Translations translations { get; set; }
        public List<double> latlng { get; set; }
        public bool landlocked { get; set; }
        public List<string> borders { get; set; }
        public double area { get; set; }
        public Demonyms demonyms { get; set; }
        public string flag { get; set; }
        public Maps maps { get; set; }
        public int population { get; set; }
        public Gini gini { get; set; }
        public string fifa { get; set; }
        public Car car { get; set; }
        public List<string> timezones { get; set; }
        public List<string> continents { get; set; }
        public Flags flags { get; set; }
        public CoatOfArms coatOfArms { get; set; }
        public string startOfWeek { get; set; }
        public CapitalInfo capitalInfo { get; set; }
        public PostalCode postalCode { get; set; }
    }
}
