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

        [HttpGet("Meteo/{stato}/{citta}")]
        public List<Meteo> ExtractMeteo(string stato, string citta)
        {
            List<Meteo> listameteo = scrapingRepository.ExtractMeteo(stato, citta).ToList();
            return listameteo;
        }
    }
}
