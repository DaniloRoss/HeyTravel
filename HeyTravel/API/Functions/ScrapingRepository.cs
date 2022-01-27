using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using API.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace API.Functions
{
    public class ScrapingRepository : IScrapingRepository
    {
        /// <summary>
        /// Metodo che dato in input uno stato, restituisce il suo codice ISO a due caratteri
        /// </summary>
        /// <param name="stato">Stato in Inglese di cui estrarre il codice a due caratteri</param>
        /// <returns></returns>
        public string ExtractCountryCode(string stato)
        {
            string statoInput;
            string link = "https://www.nationsonline.org/oneworld/country_code_list.htm";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web?.Load(link);

            stato = stato.ToLower();
            statoInput = stato;

            if (stato == "russia")
            {
                statoInput = "russian federation";
            }
            foreach (var tabella in document.DocumentNode.SelectNodes(".//table"))
            {
                string idTab = tabella.GetAttributeValue("id", null);
                string[] split = idTab.Split('-');
                if (string.Compare(split[2].ToLower(), statoInput.Substring(0, 1)) > 0 || string.Compare(split[2].ToLower(), statoInput.Substring(0, 1)) == 0
                    || string.Compare(split[3].ToLower(), statoInput.Substring(0, 1)) < 0 || string.Compare(split[3].ToLower(), statoInput.Substring(0, 1)) == 0)
                {
                    foreach (var riga in tabella.SelectNodes(".//tr"))
                    {
                        if (riga.SelectSingleNode(".//td[contains(@class, 'abs')]").InnerText.Trim().ToLower() == statoInput)
                        {
                            return riga.SelectSingleNode(".//td[3]").InnerText.Trim();

                        }
                    }
                }
            }
            return null;

        }
        public async Task<string> Translate(string text, string target, string source)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
            {
                { "x-rapidapi-host", "google-translate1.p.rapidapi.com" },
                { "x-rapidapi-key", "56817d175dmshc711ac9d0fe0bf8p179522jsn5d8a789d077e" },
            },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "q", $"{text}" },
                { "target", $"{target}" },
                { "source", $"{source}" },
            }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RootTranslation>(body.Result).data.translations[0].translatedText;
                return result;
            }
        }
        /// <summary>
        /// Metodo che dato in input uno stato, estrae le prime 20 città per popolazione
        /// </summary>
        /// <param name="stato">Stato in Italiano da cui estrarre le città</param>
        /// <returns></returns>
        public async Task<IEnumerable<Citta>> ExtractBestCitiesPerCountry(string stato)
        {
            string statotradotto, codicestato;

            stato = char.ToUpper(stato[0]) + stato.Substring(1).ToLower();

            //if (stato.Contains("avorio"))
            //{
            //    statotradotto = await Translate(stato, "en", "fr");
            //}
            //else
            //{
            //    statotradotto = await Translate(stato, "en", "it");
            //}
            statotradotto = "Italy";

            codicestato = ExtractCountryCode(statotradotto);

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://wft-geo-db.p.rapidapi.com/v1/geo/cities?limit=10&countryIds={codicestato}&sort=-population&languageCode=IT&types=CITY"),
                Headers =
                {
                    { "x-rapidapi-host", "wft-geo-db.p.rapidapi.com" },
                    { "x-rapidapi-key", "3d0684d35amsh068100b881d194cp1cd704jsn90bc3c996d91" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RootCitta>(body).data;
                foreach (var citta in result)
                {
                    string link = $"https://it.wikipedia.org/wiki/{citta.name}";
                    HtmlWeb web = new HtmlWeb();
                    HtmlDocument document = web?.Load(link);

                    HtmlNode nodoAbitanti = document.DocumentNode.SelectSingleNode(".//a[contains(@title, 'Popolazione')]");
                    string popolazione=nodoAbitanti.ParentNode.ParentNode.SelectSingleNode(".//td").InnerText.Trim();
                    popolazione = popolazione.Replace("&#160;", "")?.Split("&")[0];
                }
                return null;
            }
        }
        public IEnumerable<Meteo> ExtractMeteo(string stato, string citta)
        {
            string link = default(string);
            if (citta == "&")
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

            if (document == null)
            {
                return eleMeteo;
            }

            NodesTabelle = document.DocumentNode.SelectNodes(".//table");

            if (NodesTabelle == null || document.DocumentNode.SelectSingleNode("//span").InnerText.StartsWith("Errore"))
            {
                return eleMeteo;
            }

            List<string> eleNomi = new List<string>();
            foreach (var tabellaNomi in NodesTabelle)
            {
                string captionNome = tabellaNomi.SelectSingleNode(".//caption").InnerText.Trim();
                string MeteoCittaNomi = captionNome.Substring(0, captionNome.IndexOf('-') - 1);
                if (eleNomi.Where(p => p == MeteoCittaNomi).Count() == 0)
                {
                    eleNomi.Add(MeteoCittaNomi);
                }
            }

            foreach (string nomecitta in eleNomi)
            {
                Meteo met = new Meteo();
                met.Stato = char.ToUpper(stato[0]) + stato.Substring(1);
                met.Citta = nomecitta;
                foreach (var tabella in NodesTabelle)
                {
                    string captionNome = tabella.SelectSingleNode(".//caption").InnerText.Trim();
                    string MeteoCittaNomi = captionNome.Substring(0, captionNome.IndexOf('-') - 1);
                    if (nomecitta == MeteoCittaNomi)
                    {
                        if (tabella.GetClasses().ToList()[0] == "cities")
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
                        if (tabella.GetClasses().ToList()[0] == "precipit")
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
                        if (tabella.GetClasses().ToList()[0] == "sole")
                        {
                            List<OreSole> eleOreSole = new List<OreSole>();
                            for (int i = 2; i < 40; i = i + 3)
                            {
                                HtmlNode cella1 = tabella.ChildNodes[i];
                                HtmlNode cella2 = tabella.ChildNodes[i + 1];
                                HtmlNode cella3 = tabella.ChildNodes[i + 2];
                                OreSole OreSole = new OreSole();
                                OreSole.Mese = cella1.ChildNodes[0].InnerText.Trim().ToString();
                                OreSole.MediaGiornaliera = decimal.Parse(cella2.InnerText.Trim().ToString());
                                OreSole.TotaleMese = int.Parse(cella3.InnerText.Trim().ToString());
                                eleOreSole.Add(OreSole);
                            }
                            met.OreSole = eleOreSole;
                        }
                        if (tabella.GetClasses().ToList()[0] == "mare")
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

        /// <summary>
        /// Funzione he estrae i dati dei casi di Covid19 in base al paese
        /// </summary>
        /// <param name="stato"></param>
        /// <returns>Dati su contagi</returns>
        public async Task<Casi> DataCovid(string stato)
        {
            decimal casiattivi = default;
            decimal giornalieri = default;
            decimal popolazione = default;
            decimal percentuale = default;

            string UrlCovid = "https://www.worldometers.info/coronavirus/#nav-yesterday";
            var web = new HtmlWeb();
            var doc = web.Load(UrlCovid);
            var statoen = await Translate(stato, "en", "it");
            try
            {
                casiattivi = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@id='main_table_countries_yesterday']//tr[contains(., '{statoen}')]/td")[8].InnerText.Trim().Replace("/n", null).Replace(",", null));
                giornalieri = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@id='main_table_countries_yesterday']//tr[contains(., '{statoen}')]/td")[3].InnerText.Trim().Replace("/n", null).Replace(",", null));
                popolazione = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@id='main_table_countries_yesterday']//tr[contains(., '{statoen}')]/td")[14].InnerText.Trim().Replace("/n", null).Replace(",", null));
                percentuale = (casiattivi / popolazione) * 100;
            }
            catch (NullReferenceException)
            {
                Casi error = new Casi();
                return error;
            }
            Casi casi = new Casi { Stato = stato, CasiAttivi = (int)casiattivi, CasiGiornalieri = (int)giornalieri, PercentualeContagi = percentuale, Popolazione = (int)popolazione };
            return casi;            
        }

        /// <summary>
        /// Funzione che estrae i dati delle vaccinazioni n base al paese
        /// </summary>
        /// <param name="stato"></param>
        /// <returns>Dati sulle vaccinazioni</returns>
        public Vaccini DataVaccini(string stato)
        {
            int nuovedosi = default;
            int vaccinati = default;
            int dositot = default;
            string UrlCovid = "https://news.google.com/covid19/map?hl=it&state=7&gl=IT&ceid=IT%3Ait";
            var web = new HtmlWeb();
            var doc = web.Load(UrlCovid);
            try
            {
                vaccinati = int.Parse(doc.DocumentNode.SelectNodes($"//table[@class='pH8O4c']//tr[contains(., '{stato}')]//td")[3].InnerText.Trim().Replace("/n", null).Replace(".", null));
                dositot = int.Parse(doc.DocumentNode.SelectNodes($"//table[@class='pH8O4c']//tr[contains(., '{stato}')]//td")[0].InnerText.Trim().Replace("/n", null).Replace(".", null));
                try
                {
                    nuovedosi = int.Parse(doc.DocumentNode.SelectNodes($"//table[@class='pH8O4c']//tr[contains(., '{stato}')]/td")[1].InnerText.Trim().Replace("/n", null).Replace(".", null));

                }
                catch
                {
                    nuovedosi = 0;
                }
            }
            catch (NullReferenceException)
            {
                Vaccini error = new Vaccini();
                return error;
            }
            decimal perc = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@class='pH8O4c']//tr[contains(., '{stato}')]//td")[4].InnerText.Trim().Replace("/n", null).Replace("%", null));
            Vaccini vaccini = new Vaccini { Stato = stato, Vaccinati = (int)vaccinati, DosiTotali = dositot, NuoveDosi = nuovedosi, PercentualeVaccini = perc };
            return vaccini;
        }

        public async Task<string> CovidMap()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://covid19-data.p.rapidapi.com/geojson-ww"),
                Headers =
                {
                    { "x-rapidapi-host", "covid19-data.p.rapidapi.com" },
                    { "x-rapidapi-key", "56817d175dmshc711ac9d0fe0bf8p179522jsn5d8a789d077e" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}
