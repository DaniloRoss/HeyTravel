using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using API.Models;
using HtmlAgilityPack;
using Microsoft.VisualBasic.FileIO;
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

            var lista = document.DocumentNode.SelectNodes(".//table");
            foreach (var tabella in lista)
            {
                string idTab = tabella.GetAttributeValue("id", null);
                string[] split = idTab.Split('-');
                if (split.Length == 3)
                {
                    if ((Encoding.Default.GetBytes(split[1].ToLower())[0] < Encoding.Default.GetBytes(statoInput.Substring(0, 1))[0]) && (Encoding.Default.GetBytes(split[2].ToLower())[0] > Encoding.Default.GetBytes(statoInput.Substring(0, 1))[0]))
                    {
                        foreach (var riga in tabella.SelectNodes(".//tr"))
                        {
                            if (riga.SelectSingleNode(".//td[contains(@class, 'abs')]").InnerText.Trim().ToLower() == statoInput)
                            {
                                return riga.SelectSingleNode(".//td[3]").InnerText.Trim();
                            }
                        }
                    }
                    if (Encoding.Default.GetBytes(split[1].ToLower())[0] == Encoding.Default.GetBytes(statoInput.Substring(0, 1))[0] || Encoding.Default.GetBytes(split[2].ToLower())[0] == Encoding.Default.GetBytes(statoInput.Substring(0, 1))[0])
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
                else
                {
                    if (Encoding.Default.GetBytes(split[2].ToLower())[0] < Encoding.Default.GetBytes(statoInput.Substring(0, 1))[0] && Encoding.Default.GetBytes(split[3].ToLower())[0] > Encoding.Default.GetBytes(statoInput.Substring(0, 1))[0])
                    {
                        foreach (var riga in tabella.SelectNodes(".//tr"))
                        {
                            if (riga.SelectSingleNode(".//td[contains(@class, 'abs')]").InnerText.Trim().ToLower() == statoInput)
                            {
                                return riga.SelectSingleNode(".//td[3]").InnerText.Trim();

                            }
                        }
                    }
                    if (Encoding.Default.GetBytes(split[2].ToLower())[0] == Encoding.Default.GetBytes(statoInput.Substring(0, 1))[0] || Encoding.Default.GetBytes(split[3].ToLower())[0] == Encoding.Default.GetBytes(statoInput.Substring(0, 1))[0])
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
            }
            return null;
        }

        /// <summary>
        /// Traduce il nome di uno stato da una lingua all'altra
        /// </summary>
        /// <param name="stato"></param>
        /// <param name="lingua"></param>
        /// <returns>Traduzione dello stato</returns>
        public string CountryTranslate(string stato, string lingua)
        {
            using (TextFieldParser parser = new TextFieldParser(@"wwwroot/csv/stati.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                string translation = default;
                stato = stato.ToLower();
                stato[0].ToString().ToUpper();
                var statoparsed = char.ToUpper(stato[0]) + stato.Substring(1);


                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (fields[0] == statoparsed)
                    {
                        if (lingua == "en")
                        {
                            translation = fields[1];
                        }
                        if (lingua == "fr")
                        {
                            translation = fields[2];
                        }
                    }
                }
                return translation;
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

            statotradotto = CountryTranslate(stato, "en");
            if (statotradotto == null)
            {
                return null;
            }

            codicestato = ExtractCountryCode(statotradotto);
            if (stato.Contains("avorio"))
            {
                codicestato = "CI";
            }
            if (codicestato == null)
            {
                return null;
            }
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
                return result;
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
        public List<Casi> DataCovid(string stato)
        {
            decimal casiattivi = default;
            decimal giornalieri = default;
            decimal popolazione = default;
            decimal percentuale = default;
            List<Casi> elecasi = new List<Casi>();
            string UrlCovid = "https://www.worldometers.info/coronavirus/#nav-yesterday";
            var web = new HtmlWeb();
            var doc = web.Load(UrlCovid);
            var statoen = CountryTranslate(stato, "en");


            try
            {
                if (stato == "world")
                {
                    var nodes = doc.DocumentNode.SelectNodes("//table[@id='main_table_countries_yesterday']//tr[@style='']");
                    foreach (var row in nodes)
                    {
                        try
                        {
                            var a = row.SelectNodes("//td");
                            string nomestato = row.ChildNodes[3].InnerText.Trim().Replace("/n", null).Replace(",", null);
                            casiattivi = decimal.Parse(row.ChildNodes[17].InnerText.Trim().Replace("/n", null).Replace(",", null));
                            giornalieri = 0;
                            popolazione = decimal.Parse(row.ChildNodes[29].InnerText.Trim().Replace("/n", null).Replace(",", null));
                            percentuale = (casiattivi / popolazione) * 100;

                            elecasi.Add(new Casi { Stato = nomestato, CasiAttivi = (int)casiattivi, CasiGiornalieri = (int)giornalieri, PercentualeContagi = percentuale, Popolazione = (int)popolazione });

                        }
                        catch
                        {

                        }
                    }
                    var json = JsonConvert.SerializeObject(elecasi);
                    File.WriteAllText(@"wwwroot/json/casi.json", json);
                    return elecasi;
                }

                casiattivi = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@id='main_table_countries_yesterday']//tr[contains(., '{statoen}')]/td")[8].InnerText.Trim().Replace("/n", null).Replace(",", null));
                giornalieri = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@id='main_table_countries_yesterday']//tr[contains(., '{statoen}')]/td")[3].InnerText.Trim().Replace("/n", null).Replace(",", null));
                popolazione = decimal.Parse(doc.DocumentNode.SelectNodes($"//table[@id='main_table_countries_yesterday']//tr[contains(., '{statoen}')]/td")[14].InnerText.Trim().Replace("/n", null).Replace(",", null));
                percentuale = (casiattivi / popolazione) * 100;
            }
            catch (NullReferenceException)
            {
                Casi error = new Casi();
                elecasi.Add(error);
                return elecasi;
            }
            Casi casi = new Casi { Stato = stato, CasiAttivi = (int)casiattivi, CasiGiornalieri = (int)giornalieri, PercentualeContagi = percentuale, Popolazione = (int)popolazione };
            elecasi.Add(casi);
            return elecasi;
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
                var riga = doc.DocumentNode.SelectNodes($"//table[@class='pH8O4c']");
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
            catch (Exception ex)
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
            List<Casi> casi = DataCovid("world");
            var jsonmap = JsonConvert.DeserializeObject<GeoJson>(File.ReadAllText(@"wwwroot/json/world_OK.json"));
            File.WriteAllText(@"wwwroot/csv/world_new.csv", string.Empty);
            string line = default;
            line = "";

            using (TextFieldParser parser = new TextFieldParser(@"wwwroot/csv/world.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (fields[0] == "COVID")
                    {
                    }
                    else
                    {
                        try
                        {
                            var casiattivi = casi.First(a => a.Stato == fields[0]).CasiAttivi.ToString();
                            fields[1] = casiattivi;
                        }
                        catch (Exception ex)
                        {
                            fields[1] = "";
                        }
                    }
                    foreach (var field in fields)
                    {
                        if (line == "")
                        {
                            line = line + field;
                        }
                        else
                        {
                            line = line + "," + field;
                        }
                    }
                    File.AppendAllText(@"wwwroot/csv/world_new.csv", line + "\n");
                    line = "";
                }
            }


            using (TextFieldParser parser = new TextFieldParser(@"wwwroot/csv/world_new.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (fields[0] == "COVID")
                    {

                    }
                    else
                    {
                        try
                        {
                            if (fields[0] == "San Marino" || fields[0] == "Vatican City" || fields[0] == "Monaco")
                            {

                            }
                            else
                            {
                                jsonmap.features.FirstOrDefault(a => a.properties.name == fields[3]).properties.casi = decimal.Parse(fields[1]);
                            }
                        }
                        catch (FormatException)
                        {
                            jsonmap.features.FirstOrDefault(a => a.properties.name == fields[3]).properties.casi = 0;
                        }
                        catch (NullReferenceException)
                        {

                        }
                    }
                }
                var mappa = JsonConvert.SerializeObject(jsonmap);
                File.WriteAllText(@"wwwroot/json/mappa.json", mappa);
                return mappa;
            }
        }
    }
}
