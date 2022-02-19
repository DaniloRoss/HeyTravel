using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Functions
{
    public interface IScrapingRepository
    {
        string ExtractCountryCode(string stato);
        Task<IEnumerable<Citta>> ExtractBestCitiesPerCountry(string codicestato);
        IEnumerable<Meteo> ExtractMeteo (string stato, string città);
        List<Casi> DataCovid(string stato);
        Task<Vaccini> DataVaccini(string stato);
        Task<string> CovidMap();
        string CountryTranslate(string stato, string lingua);
        Task<List<string>> GetImages(string stato);
    }
}
