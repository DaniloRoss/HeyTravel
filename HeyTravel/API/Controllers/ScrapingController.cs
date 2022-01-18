using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Functions;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrapingController : ControllerBase
    {
        private readonly IScrapingRepository scrapingRepository;
        public ScrapingController(IScrapingRepository scrapingRepository)
        {
            this.scrapingRepository = scrapingRepository;
        }

        [HttpGet("Meteo/{stato}/{città?}")]
        public List<Meteo> ExtractMeteo(string stato, string città)
        {
            List<Meteo> listameteo = scrapingRepository.ExtractMeteo(stato, città).ToList();
            return listameteo;
        }

        [HttpGet("Covid/casi/{stato}")]
        public Casi DataCovid(string stato)
        {
            Casi covid = scrapingRepository.DataCovid(stato);
            return covid;
        }
        [HttpGet("Covid/vaccini/{stato}")]
        public Vaccini DataVaccini(string stato)
        {
            Vaccini vaccini = scrapingRepository.DataVaccini(stato);
            return vaccini;
        }
    }
}
