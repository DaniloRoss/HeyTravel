using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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
    }
}
