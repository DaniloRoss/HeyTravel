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
        List<Casi> DataCovid(string stato, string percorso = "wwwroot/csv/stati.csv", string percorsocasi = "wwwroot/json/casi.json", string percorsotesto = "wwwroot/csv/elecountry.txt");
        Task<Vaccini> DataVaccini(string stato, string percorso = "wwwroot/csv/stati.csv");
        Task<string> CovidMap(string percorso = "wwwroot/csv/stati.csv", string percorsocasi = "wwwroot/json/casi.json", string percorsotesto = "wwwroot/csv/elecountry.txt", string percorsoworldok = "wwwroot/json/world_OK.json", string percorsoworld = "wwwroot/csv/world.csv", string percorsoworldnew = "wwwroot/csv/world_new.csv", string percorsojson = "wwwroot/json/mappa.json");
        string CountryTranslate(string stato, string lingua, string percorso = "wwwroot/csv/stati.csv");
        Task<List<string>> GetImages(string stato);
    }
}
