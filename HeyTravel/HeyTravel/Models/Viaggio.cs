using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyTravel.Models
{
    public class Viaggio
    {
        [Key]
        public int ID { get; set; }
        public string StatoArrivo { get; set; }
        public string CittaArrivo { get; set; }
        public string MesePartenza { get; set; }
        public string MeseArrivo { get; set; }
    }
}
