using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Functions;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    public class ScrapingController : ControllerBase
    {
        private readonly IScrapingRepository scrapingRepository;
        public ScrapingController(IScrapingRepository scrapingRepository)
        {
            this.scrapingRepository = scrapingRepository;
        }
        [HttpGet("MiglioriCitta/{stato}")]
        public async Task<IEnumerable<Citta>> ExtractBestCitiesPerCountry(string stato)
        {
            List<Citta> listacitta = new List<Citta>();
            listacitta = await scrapingRepository.ExtractBestCitiesPerCountry(stato) as List<Citta>;
            return listacitta;
        }
        [HttpGet("Meteo/{stato}/{citta}")]
        public List<Meteo> ExtractMeteo(string stato, string citta)
        {
            List<Meteo> listameteo = scrapingRepository.ExtractMeteo(stato, citta).ToList();
            return listameteo;
        }

        
        [HttpGet("Covid/casi/{stato}")]
        public List<Casi> DataCovid(string stato)
        {
            List<Casi> covid = scrapingRepository.DataCovid(stato);
            return covid;
        }
        [HttpGet("Covid/vaccini/{stato}")]
        public async Task<Vaccini> DataVaccini(string stato)
        {
            Vaccini vaccini = await scrapingRepository.DataVaccini(stato);
            return vaccini;
        }
        [HttpGet("Covid/map")]
        public async Task<string> CovidMap()
        {
            string mappa = await scrapingRepository.CovidMap();
            return mappa;
        }

        [HttpGet("Photo/{stato}")]
        public async Task<List<string>> GetPhoto(string stato)
        {
            List<string> elefoto = await scrapingRepository.GetImages(stato);
            return elefoto;
        }
    }
}
