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
            string link=default(string);
            bool solostato = true;
            if (città=="")
            {
                link = $"https://www.climieviaggi.it/clima/{stato.ToLower()}";
            }
            else
            {
                string cittàLower = città.ToLower();
                if (cittàLower.Contains(" "))
                {
                    cittàLower.Replace(' ', '-');
                }                    
                link = $"https://www.climieviaggi.it/clima/{stato.ToLower()}/{cittàLower}";
                solostato = false;
            }

            HtmlNodeCollection NodesCities;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(link);

            NodesCities = document.DocumentNode.SelectNodes("/html/body/form/div[7]/div[1]/div[4]/div[1]/table[contains(@class, 'cities')]");


            return null;
        }
    }
}
