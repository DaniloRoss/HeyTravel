using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyTravel.Models
{
    public class Viaggi
    {
        [Key]
        public int ID { get; set; }
        public string StatoPartenza { get; set; }
        public string StatoArrivo { get; set; }
        public string MeseArrivo { get; set; }
        public Vaccini Vaccinati { get; set; }
        public Casi CasiCovid { get; set; }
        public Meteo Meteo { get; set; }
    }
}
