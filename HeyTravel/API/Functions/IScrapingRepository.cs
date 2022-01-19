using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Functions
{
    public interface IScrapingRepository
    {
        IEnumerable<Meteo> ExtractMeteo (string stato, string città);
        Casi DataCovid(string stato);
        Vaccini DataVaccini(string stato);
    }
}
