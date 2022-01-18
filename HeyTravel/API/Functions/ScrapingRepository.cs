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
            if(NodesCities != null)
            {
                foreach (var tabellaCities in NodesCities)
                {
                    List<Temperature> eleTemperature = new List<Temperature>();
                    Temperature Temperature = new Temperature();

                    string captionCities = tabellaCities.SelectSingleNode("//caption").InnerText.Trim();
                    string MeteoCittaCities = captionCities.Substring(0, captionCities.IndexOf('-') - 1);
                    Meteo.Citta = MeteoCittaCities;
                    foreach (HtmlNode riga in tabellaCities.SelectNodes("//tr[contains(@class, 'min-table')]"))
                    {
                        Temperature.Mese = riga.ChildNodes[0].InnerText.Trim().ToString();
                        Temperature.Min = decimal.Parse(riga.ChildNodes[1].InnerText.Trim().ToString());
                        Temperature.Max = decimal.Parse(riga.ChildNodes[2].InnerText.Trim().ToString());
                        eleTemperature.Add(Temperature);
                    }
                    Meteo.Temperature = eleTemperature;
                }
            }
            if(NodesPrecipit != null)
            {
                foreach (var tabellaPrecipit in NodesPrecipit)
                {
                    List<Precipitazioni> elePrecipitazioni = new List<Precipitazioni>();
                    Precipitazioni Precipitazioni = new Precipitazioni();

                    string captionPrecipit = tabellaPrecipit.SelectSingleNode("//caption").InnerText.Trim();
                    string MeteoCittaPrecipit = captionPrecipit.Substring(0, captionPrecipit.IndexOf('-') - 1);
                    Meteo.Citta = MeteoCittaPrecipit;
                    foreach (HtmlNode riga in tabellaPrecipit.SelectNodes("//tr[contains(@class, 'precipit-table')]"))
                    {
                        Precipitazioni.Mese = riga.ChildNodes[0].InnerText.Trim().ToString();
                        Precipitazioni.Quantità = int.Parse(riga.ChildNodes[1].InnerText.Trim().ToString());
                        Precipitazioni.Giorni = int.Parse(riga.ChildNodes[2].InnerText.Trim().ToString());
                        elePrecipitazioni.Add(Precipitazioni);
                    }
                    Meteo.Precipitazioni = elePrecipitazioni;
                }
            }
            if (NodesSole != null)
            {
                foreach (var tabellaSole in NodesSole)
                {
                    List<OreSole> eleOreSole = new List<OreSole>();
                    OreSole OreSole = new OreSole();

                    string captionSole = tabellaSole.SelectSingleNode("//caption").InnerText.Trim();
                    string MeteoCittaSole = captionSole.Substring(0, captionSole.IndexOf('-') - 1);
                    Meteo.Citta = MeteoCittaSole;
                    foreach (HtmlNode riga in tabellaSole.SelectNodes("//tr"))
                    {
                        if(riga.InnerHtml.StartsWith("<th scope=\"col\""))
                        {
                            continue;
                        }
                        OreSole.Mese = riga.ChildNodes[0].InnerText.Trim().ToString();
                        OreSole.MediaGiornaliera = decimal.Parse(riga.ChildNodes[1].InnerText.Trim().ToString());
                        OreSole.TotaleMese = int.Parse(riga.ChildNodes[2].InnerText.Trim().ToString());
                        eleOreSole.Add(OreSole);
                    }
                    Meteo.OreSole = eleOreSole;
                }
            }
            if (NodesMare != null)
            {
                foreach (var tabellaMare in NodesMare)
                {
                    List<Mare> eleMare = new List<Mare>();
                    Mare Mare = new Mare();

                    string captionMare = tabellaMare.SelectSingleNode("//caption").InnerText.Trim();
                    string MeteoCittaMare = captionMare.Substring(0, captionMare.IndexOf('-') - 1);
                    Meteo.Citta = MeteoCittaMare;
                    foreach (HtmlNode riga in tabellaMare.SelectNodes("//tr"))
                    {
                        if (riga.InnerHtml.StartsWith("<th scope=\"col\""))
                        {
                            continue;
                        }
                        Mare.Mese = riga.ChildNodes[0].InnerText.Trim().ToString();
                        Mare.Temperatura = decimal.Parse(riga.ChildNodes[1].InnerText.Trim().ToString());
                        eleMare.Add(Mare);
                    }
                    Meteo.Mare = eleMare;
                }
            }
            eleMeteo.Add(Meteo);
            return eleMeteo;
        }
    }
}
