using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Meteo
    {
        public string Stato { get; set; }
        public string Città { get; set; }
        public  List<Temperature> Temperature { get; set; }
        public List<Precipitazioni> Precipitazioni { get; set; }
        public List<OreSole> OreSole { get; set; }
        public List<Mare> Mare { get; set; }
    }

    public class Temperature
    {
        public string Mese { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
    }

    public class Precipitazioni
    {
        public string Mese { get; set; }
        public int Quantità { get; set; }
        public int Giorni { get; set; }
    }

    public class OreSole
    {
        public string Mese { get; set; }
        public decimal MediaGiornaliera { get; set; }
        public int TotaleMese { get; set; }
    }

    public class Mare
    {
        public string Mese { get; set; }
        public decimal Temperatura { get; set; }
    }
}
