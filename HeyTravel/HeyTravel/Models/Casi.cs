using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyTravel.Models
{
    public class Casi
    { 
        public string Stato { get; set; }
        public int CasiAttivi { get; set; }
        public int CasiGiornalieri { get; set; }
        public int Popolazione { get; set; }
        public decimal PercentualeContagi { get; set; }
    }

    public class Vaccini
    {
        public string Stato { get; set; }
        public int Vaccinati { get; set; }
        public int DosiTotali { get; set; }
        public int NuoveDosi { get; set; }
        public decimal PercentualeVaccini { get; set; }
    }
}
