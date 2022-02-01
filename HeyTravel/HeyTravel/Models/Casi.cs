using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyTravel.Models
{
    public class Casi
    {
        [Key]
        public int ID { get; set; }
        public string Stato { get; set; }
        public int CasiAttivi { get; set; }
        public int CasiGiornalieri { get; set; }
        public int Popolazione { get; set; }
        public decimal PercentualeContagi { get; set; }
    }

    public class Vaccini
    {
        [Key]
        public int ID { get; set; }
        public string Stato { get; set; }
        public int Vaccinati { get; set; }
        public int DosiTotali { get; set; }
        public int NuoveDosi { get; set; }
        public decimal PercentualeVaccini { get; set; }
    }
}
