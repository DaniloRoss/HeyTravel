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
        public IEnumerable<Meteo> ExtractMeteo (string stato, string citta)
        {
            string link=default(string);
            if (citta== "&")
            {
                link = $"https://www.climieviaggi.it/clima/{stato.ToLower()}";
            }
            else
            {
                string cittaLower = citta.ToLower();
                if (cittaLower.Contains(" "))
                {
                    cittaLower.Replace(' ', '-');
                }                    
                link = $"https://www.climieviaggi.it/clima/{stato.ToLower()}/{cittaLower}";
            }

            HtmlNodeCollection NodesCities;
            HtmlNodeCollection NodesPrecipit;
            HtmlNodeCollection NodesSole;
            HtmlNodeCollection NodesMare;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web?.Load(link);
            if(document==null)
            {
                return null;
            }

            NodesCities = document.DocumentNode.SelectNodes(".//table[contains(@class, 'cities')]");
            NodesPrecipit = document.DocumentNode.SelectNodes(".//table[contains(@class, 'precipit')]");
            NodesSole = document.DocumentNode.SelectNodes(".//table[contains(@class, 'sole')]");
            NodesMare = document.DocumentNode.SelectNodes(".//table[contains(@class, 'mare')]");

            List<Meteo> eleMeteo = new List<Meteo>();
            Meteo Meteo = new Meteo();
            Meteo.Stato = char.ToUpper(stato[0])+stato.Substring(1);

            foreach (var tabella in NodesCities)
            {
                List<Temperature> eleTemperature = new List<Temperature>();
                Temperature Temperature = new Temperature();
                
                string caption=tabella.SelectSingleNode("//caption").InnerText.Trim();
                string MeteoCitta = caption.Substring(0, caption.IndexOf('-') - 1);
                Meteo.Citta = MeteoCitta;
                foreach(HtmlNode riga in tabella.SelectNodes("//tr[contains(@class, 'min-table')]"))
                {
                    Temperature.Mese = riga.SelectSingleNode("//th").InnerText.Trim().ToString();
                    Temperature.Min = decimal.Parse(riga.SelectSingleNode("//td[1]").InnerText.Trim().ToString());
                    Temperature.Max = decimal.Parse(riga.SelectSingleNode("//td[2]").InnerText.Trim().ToString());
                    eleTemperature.Add(Temperature);
                }
                Meteo.Temperature = eleTemperature;
            }
            eleMeteo.Add(Meteo);

            return eleMeteo;
        }
    }
}
