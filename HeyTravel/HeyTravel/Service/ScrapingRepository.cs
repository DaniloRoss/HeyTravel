using HeyTravel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace HeyTravel.Service
{
    public class ScrapingRepository : IScrapingRepository
    {
        private readonly HttpClient httpClient;
        public ScrapingRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Casi> DataCovid(string stato)
        {
            return await httpClient.GetFromJsonAsync<Casi>(@$"Scraping/Covid/casi/{stato}");
        }

        public async Task<GeoJson> Mappa()
        {
            var json = await httpClient.GetFromJsonAsync<GeoJson>(@"Scraping/Covid/map");
            var mappa = JsonConvert.SerializeObject(json);
            File.WriteAllText(@"wwwroot/json/mappa_new.json", mappa);
            return json;
        }
    }
}
