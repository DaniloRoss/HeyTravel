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

            HtmlNodeCollection NodesTabelle;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web?.Load(link);

            List<Meteo> eleMeteo = new List<Meteo>();

            if (document==null)
            {
                return eleMeteo;
            }

            NodesTabelle = document.DocumentNode.SelectNodes(".//table");

            if(NodesTabelle==null || document.DocumentNode.SelectSingleNode("//span").InnerText.StartsWith("Errore"))
            {
                return eleMeteo;
            }
            
            List<string> eleNomi = new List<string>();
            foreach(var tabellaNomi in NodesTabelle)
            {
                string captionNome = tabellaNomi.SelectSingleNode(".//caption").InnerText.Trim();
                string MeteoCittaNomi = captionNome.Substring(0, captionNome.IndexOf('-') - 1);
                if(eleNomi.Where(p=>p==MeteoCittaNomi).Count()==0)
                {
                    eleNomi.Add(MeteoCittaNomi);
                }
            }

            foreach(string nomecitta in eleNomi) 
            {
                Meteo met = new Meteo();
                met.Stato = char.ToUpper(stato[0])+stato.Substring(1);
                met.Citta = nomecitta;
                foreach (var tabella in NodesTabelle)
                {
                    string captionNome = tabella.SelectSingleNode(".//caption").InnerText.Trim();
                    string MeteoCittaNomi = captionNome.Substring(0, captionNome.IndexOf('-') - 1);
                    if(nomecitta==MeteoCittaNomi)
                    {
                        if(tabella.GetClasses().ToList()[0]=="cities")
                        {
                            List<Temperature> eleTemperature = new List<Temperature>();                            
                            foreach (HtmlNode riga in tabella.SelectNodes(".//tr[contains(@class, 'min-table')]"))
                            {
                                Temperature Temperature = new Temperature();
                                Temperature.Mese = riga.ChildNodes[0].InnerText.Trim().ToString();
                                Temperature.Min = decimal.Parse(riga.ChildNodes[1].InnerText.Trim().ToString());
                                Temperature.Max = decimal.Parse(riga.ChildNodes[2].InnerText.Trim().ToString());
                                Temperature.Media = decimal.Parse(riga.ChildNodes[3].InnerText.Trim().ToString());
                                eleTemperature.Add(Temperature);                                
                            }
                            met.Temperature = eleTemperature;
                        }
                        if(tabella.GetClasses().ToList()[0] == "precipit")
                        {
                            List<Precipitazioni> elePrecipitazioni = new List<Precipitazioni>();
                            foreach (HtmlNode riga in tabella.SelectNodes(".//tr[contains(@class, 'precipit-table')]"))
                            {
                                Precipitazioni Precipitazioni = new Precipitazioni();
                                Precipitazioni.Mese = riga.ChildNodes[0].InnerText.Trim().ToString();
                                Precipitazioni.Quantità = int.Parse(riga.ChildNodes[1].InnerText.Trim().ToString());
                                Precipitazioni.Giorni = int.Parse(riga.ChildNodes[2].InnerText.Trim().ToString());
                                elePrecipitazioni.Add(Precipitazioni);
                            }
                            met.Precipitazioni = elePrecipitazioni;                            
                        }
                        if(tabella.GetClasses().ToList()[0] == "sole")
                        {
                            List<OreSole> eleOreSole = new List<OreSole>();          
                            for(int i=2;i<40;i=i+3)
                            {
                                HtmlNode cella1 = tabella.ChildNodes[i];
                                HtmlNode cella2 = tabella.ChildNodes[i+1];
                                HtmlNode cella3 = tabella.ChildNodes[i+2];
                                OreSole OreSole = new OreSole();
                                OreSole.Mese = cella1.ChildNodes[0].InnerText.Trim().ToString();
                                OreSole.MediaGiornaliera = decimal.Parse(cella2.InnerText.Trim().ToString());
                                OreSole.TotaleMese = int.Parse(cella3.InnerText.Trim().ToString());
                                eleOreSole.Add(OreSole);
                            }
                            met.OreSole = eleOreSole;
                        }
                        if(tabella.GetClasses().ToList()[0] == "mare")
                        {
                            List<Mare> eleMare = new List<Mare>();
                            for (int i = 2; i < 27; i = i + 2)
                            {
                                Mare Mare = new Mare();
                                HtmlNode cella1 = tabella.ChildNodes[i];
                                HtmlNode cella2 = tabella.ChildNodes[i + 1];
                                Mare.Mese = cella1.ChildNodes[0].InnerText.Trim().ToString();
                                Mare.Temperatura = decimal.Parse(cella2.InnerText.Trim().ToString());
                                eleMare.Add(Mare);
                            }
                            met.Mare = eleMare;
                        }
                    }
                }
                eleMeteo.Add(met);
            }            
            return eleMeteo;
        }
    }
}
