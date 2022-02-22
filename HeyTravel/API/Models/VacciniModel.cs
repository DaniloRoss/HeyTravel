using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class VacciniModel
    {
        public string country_code { get; set; }
        public string country { get; set; }
        public string continent { get; set; }
        public string updated { get; set; }
        public int total_vaccinations { get; set; }
        public int people_vaccinated { get; set; }
        public int people_fully_vaccinated { get; set; }
        public double total_vaccinations_per_hundred { get; set; }
        public double people_vaccinated_per_hundred { get; set; }
        public int population { get; set; }
        public double population_density { get; set; }
        public double median_age { get; set; }
    }
}
