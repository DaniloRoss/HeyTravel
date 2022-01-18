using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using HtmlAgilityPack;

namespace API.Functions
{
    public class ScrapingRepository : IScrapingRepository
    {
        public IEnumerable<Meteo> ExtractMeteo (string stato, string città)
        {
            return null;
        }

        public Covid DataCovid(string stato)
        {
            string UrlCovid = "https://www.worldometers.info/coronavirus/#nav-yesterday";
            var web = new HtmlWeb();
            var doc = web.Load(UrlCovid);
            string Country = doc.DocumentNode.SelectSingleNode($"//table[@id='main_table_countries_yesterday']//tr[contains(., '{stato}')]").InnerText;
            //string casiattivi = Country.SelectNodes("//td")[8].InnerText;
            return null;
            
        }
    }
}
