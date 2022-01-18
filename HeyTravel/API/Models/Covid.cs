using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Covid
    {
        public string Stato { get; set; }
        public int CasiAttivi { get; set; }
        public int CasiGiornalieri { get; set; }
        public int Popolazione { get; set; }
        public decimal PercentualeContagi { get; set; }
    }
}
