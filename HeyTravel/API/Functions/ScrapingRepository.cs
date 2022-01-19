using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public Casi DataCovid(string stato)
        {
            string UrlCovid = "https://www.worldometers.info/coronavirus/#nav-yesterday";
            var web = new HtmlWeb();
            var doc = web.Load(UrlCovid);
            decimal casiattivi = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@id='main_table_countries_yesterday']//tr[contains(., '{stato}')]/td")[8].InnerText.Trim().Replace("/n", null).Replace(",", null));
            decimal giornalieri = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@id='main_table_countries_yesterday']//tr[contains(., '{stato}')]/td")[3].InnerText.Trim().Replace("/n", null).Replace(",", null));
            decimal popolazione = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@id='main_table_countries_yesterday']//tr[contains(., '{stato}')]/td")[14].InnerText.Trim().Replace("/n", null).Replace(",", null));
            decimal percentuale = (casiattivi/popolazione)*100;
            Casi casi = new Casi { Stato = stato, CasiAttivi = (int)casiattivi, CasiGiornalieri = (int)giornalieri, PercentualeContagi = percentuale, Popolazione = (int)popolazione };
            return casi;            
        }
        public Vaccini DataVaccini(string stato)
        {
            int nuovedosi = default;
            string UrlCovid = "https://news.google.com/covid19/map?hl=it&state=7&gl=IT&ceid=IT%3Ait";
            var web = new HtmlWeb();
            var doc = web.Load(UrlCovid);
            int vaccinati = int.Parse(doc.DocumentNode.SelectNodes($"//table[@class='pH8O4c']//tr[contains(., '{stato}')]//td")[3].InnerText.Trim().Replace("/n", null).Replace(".", null));
            int dositot = int.Parse(doc.DocumentNode.SelectNodes($"//table[@class='pH8O4c']//tr[contains(., '{stato}')]//td")[0].InnerText.Trim().Replace("/n", null).Replace(".", null));
            try
            {
                nuovedosi = int.Parse(doc.DocumentNode.SelectNodes($"//table[@class='pH8O4c']//tr[contains(., '{stato}')]/td")[1].InnerText.Trim().Replace("/n", null).Replace(".", null));

            }
            catch
            {
                nuovedosi = 0;
            }
            decimal perc = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@class='pH8O4c']//tr[contains(., '{stato}')]//td")[4].InnerText.Trim().Replace("/n", null).Replace("%", null));
            Vaccini vaccini = new Vaccini { Stato = stato, Vaccinati = (int)vaccinati, DosiTotali = dositot, NuoveDosi = nuovedosi, PercentualeVaccini = perc };
            return vaccini;
        }
    }
}
