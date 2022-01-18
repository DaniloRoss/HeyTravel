using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
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
        public decimal Vaccinati { get; set; }
        public decimal TotalmenteVaccinati { get; set; }
        public int Totale { get; set; }
        public decimal DosiAddizionali { get; set; }
    }
}
