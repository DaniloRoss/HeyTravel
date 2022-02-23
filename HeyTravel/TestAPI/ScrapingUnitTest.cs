
using API.Functions;
using API.Models;
using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestAPI
{
    public class ScrapingUnitTest
    {
        [Fact]
        public async void TestCasi()
        {
            //Arrange
            ScrapingRepository scrapingRepository = new ScrapingRepository();

            //Act
            var a = Directory.GetParent(Directory.GetCurrentDirectory());
            var b = Directory.GetParent(a.ToString());
            var c = Directory.GetParent(b.ToString());
            var d = Directory.GetParent(c.ToString());
            string percorso = $"{d}/API/wwwroot/csv/stati.csv";
            string percorsocasi = $"{d}/API/wwwroot/json/casi.json";
            string percorsotesto = $"{d}/API/wwwroot/csv/elecountry.txt";

            List<Casi> result = scrapingRepository.DataCovid("Italia", percorso, percorsocasi, percorsotesto);
            List<Casi> error = scrapingRepository.DataCovid("paeseinesistene", percorso, percorsocasi, percorsotesto);
            List<Casi> world = scrapingRepository.DataCovid("world", percorso, percorsocasi, percorsotesto);

            //Assert
            result[0].Stato.Should().Be("Italia");
            result[0].CasiAttivi.Should().NotBe(0);
            result[0].CasiGiornalieri.Should().NotBe(0);
            result[0].Popolazione.Should().NotBe(0);
            result[0].PercentualeContagi.Should().NotBe(0);

            error[0].Stato.Should().Be("paeseinesistene");
            error[0].Popolazione.Should().Be(0);
            error[0].PercentualeContagi.Should().Be(0);

            world.Count.Should().NotBe(0);
        }

        [Fact]
        public async void TestVaccini()
        {
            //Arrange
            ScrapingRepository scrapingRepository = new ScrapingRepository();

            //Act
            var a = Directory.GetParent(Directory.GetCurrentDirectory());
            var b = Directory.GetParent(a.ToString());
            var c = Directory.GetParent(b.ToString());
            var d = Directory.GetParent(c.ToString());
            Vaccini result = await scrapingRepository.DataVaccini("Italia", $"{d}/API/wwwroot/csv/stati.csv");

            //Assert
            result.Stato.Should().Be("Italy");
            result.Vaccinati.Should().NotBe(null);
            result.DosiTotali.Should().NotBe(null);
            result.NuoveDosi.Should().NotBe(null);
            result.PercentualeVaccini.Should().NotBe(null);
        }

        [Fact]
        public async void TestCodiceStato()
        {
            //Arrange
            ScrapingRepository scrapingRepository = new ScrapingRepository();

            //Act
            var result = scrapingRepository.ExtractCountryCode("Italy");
            var error = scrapingRepository.ExtractCountryCode("PaeseInesistente");

            //Assert
            result.Should().Be("IT");
            error.Should().Be(null);
        }

        [Fact]
        public async void TestStatoCodice()
        {
            //Arrange
            ScrapingRepository scrapingRepository = new ScrapingRepository();

            //Act
            var result = scrapingRepository.ExtractCountryFromCode("IT").Result;

            //Assert
            result.Should().Be("Italia");
        }

        [Fact]
        public async void TestTranslation()
        {
            //Arrange
            ScrapingRepository scrapingRepository = new ScrapingRepository();

            //Act
            var a = Directory.GetParent(Directory.GetCurrentDirectory());
            var b = Directory.GetParent(a.ToString());
            var c = Directory.GetParent(b.ToString());
            var d = Directory.GetParent(c.ToString());
            var result = scrapingRepository.CountryTranslate("Italia", "en", $"{d}/API/wwwroot/csv/stati.csv");
            var resultfr = scrapingRepository.CountryTranslate("Italia", "fr", $"{d}/API/wwwroot/csv/stati.csv");
            var resultit = scrapingRepository.CountryTranslate("Italy", "it", $"{d}/API/wwwroot/csv/stati.csv");


            //Assert
            result.Should().Be("Italy");
            resultfr.Should().Be("Italie");
            resultit.Should().Be("Italia");
        }

        [Fact]
        public async void TestCities()
        {
            //Arrange
            ScrapingRepository scrapingRepository = new ScrapingRepository();

            //Act
            var result = scrapingRepository.ExtractBestCitiesPerCountry("Italia");
            var resultspace = scrapingRepository.ExtractBestCitiesPerCountry("Paesi Bassi");


            //Assert
            result.Should().NotBe(null);
            resultspace.Should().NotBe(null);
        }

        [Fact]
        public async void TestMeteo()
        {
            //Arrange
            ScrapingRepository scrapingRepository = new ScrapingRepository();

            //Act
            var result = scrapingRepository.ExtractMeteo("Italia", "Roma");


            //Assert
            result.Count().Should().NotBe(0);
        }

        [Fact]
        public async void TestMappa()
        {
            //Arrange
            ScrapingRepository scrapingRepository = new ScrapingRepository();
            var a = Directory.GetParent(Directory.GetCurrentDirectory());
            var b = Directory.GetParent(a.ToString());
            var c = Directory.GetParent(b.ToString());
            var d = Directory.GetParent(c.ToString());
            string percorsoworldok = $"{d}/API/wwwroot/json/world_OK.json";
            string percorsoworld = $"{d}/API/wwwroot/csv/world.csv";
            string percorsoworldnew = $"{d}/API/wwwroot/csv/world_new.csv";
            string percorsojson = $"{d}/API/wwwroot/json/mappa.json";
            string percorso = $"{d}/API/wwwroot/csv/stati.csv";
            string percorsocasi = $"{d}/API/wwwroot/json/casi.json";
            string percorsotesto = $"{d}/API/wwwroot/csv/elecountry.txt";


            //Act
            var result = await scrapingRepository.CovidMap(percorso, percorsocasi, percorsotesto, percorsoworldok, percorsoworld, percorsoworldnew, percorsojson);


            //Assert
            result.Count().Should().NotBe(null);
        }

        [Fact]
        public async void TestFoto()
        {
            //Arrange
            ScrapingRepository scrapingRepository = new ScrapingRepository();


            //Act
            var result = await scrapingRepository.GetImages("Parigi");


            //Assert
            result.Count().Should().NotBe(null);
        }
    }
}
