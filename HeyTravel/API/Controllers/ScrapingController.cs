using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Functions;
using API.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    //[Authorize]
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
        public async Task<Casi> DataCovid(string stato)
        {
            Casi covid = await scrapingRepository.DataCovid(stato);
            return covid;
        }
        [HttpGet("Covid/vaccini/{stato}")]
        public Vaccini DataVaccini(string stato)
        {
            Vaccini vaccini = scrapingRepository.DataVaccini(stato);
            return vaccini;
        }
        [HttpGet("Covid/map/")]
        public async Task<string> CovidMap()
        {
            var map = await scrapingRepository.CovidMap();
            return map;
        }
    }
}
