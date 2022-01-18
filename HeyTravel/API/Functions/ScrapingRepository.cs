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
            string UrlCovid = "https://www.nytimes.com/interactive/2021/world/covid-vaccinations-tracker.html";
            var web = new HtmlWeb();
            var doc = web.Load(UrlCovid);
            decimal vaccinati = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@class='g-summary-table  svelte-ns1nch']//tr[contains(., '{stato}')]/td")[1].InnerText.Trim().Replace("/n", null).Replace(",", null));
            decimal totvaccinati = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@class='g-summary-table  svelte-ns1nch']//tr[contains(., '{stato}')]/td")[2].InnerText.Trim().Replace("/n", null).Replace(",", null));
            decimal totale = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@class='g-summary-table  svelte-ns1nch']//tr[contains(., '{stato}')]/td")[5].InnerText.Trim().Replace("/n", null).Replace(",", null));
            decimal dosiaggiunte = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@class='g-summary-table  svelte-ns1nch']//tr[contains(., '{stato}')]/td")[6].InnerText.Trim().Replace("/n", null).Replace(",", null));
            Vaccini vaccini = new Vaccini { Stato = stato, Vaccinati = (int)vaccinati, TotalmenteVaccinati = (int)totvaccinati, Totale = (int)totale, DosiAddizionali = (int)dosiaggiunte };
            return vaccini;
        }
    }
}
