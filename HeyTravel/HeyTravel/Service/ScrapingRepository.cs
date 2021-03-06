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
        private readonly IJWTRepository jWTRepository;
        public ScrapingRepository(HttpClient httpClient, IJWTRepository jWTRepository)
        {
            this.httpClient = httpClient;
            this.jWTRepository = jWTRepository;
        }
        public async Task<List<Casi>> DataCovid(string stato)
        {
            string token = await jWTRepository.Login();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

            return await httpClient.GetFromJsonAsync<List<Casi>>(@$"Scraping/Covid/casi/{stato}");
        }
        public async Task<List<Citta>> ExtractBestCitiesPerCountryAsync(string stato)
        {
            string token = await jWTRepository.Login();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

            return await httpClient.GetFromJsonAsync<List<Citta>>(@$"Scraping/MiglioriCitta/{stato}");
        }
        public async Task<List<Meteo>> ExtractMeteo(string stato, string citta)
        {
            string token = await jWTRepository.Login();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

            return await httpClient.GetFromJsonAsync<List<Meteo>>(@$"Scraping/Meteo/{stato}/{citta}");
        }
        public async Task<Vaccini> DataVaccini(string stato)
        {
            string token = await jWTRepository.Login();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

            return await httpClient.GetFromJsonAsync<Vaccini>(@$"Scraping/Covid/vaccini/{stato}");
        }

        public async Task<string> Mappa()
        {
            string token = await jWTRepository.Login();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

            var json = await httpClient.GetAsync(@"Scraping/Covid/map");
            var mappa = await json.Content.ReadAsStringAsync();
            File.WriteAllText(@"wwwroot/json/mappa_new.json", mappa);
            return mappa;
        }

        public async Task<List<string>> GetImages(string stato)
        {
            string token = await jWTRepository.Login();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

            try
            {
                var json = await httpClient.GetFromJsonAsync<List<string>>($@"Scraping/Photo/{stato}");
                return json;
            }
            catch
            {
                return new List<string>();
            }
        }
    }
}