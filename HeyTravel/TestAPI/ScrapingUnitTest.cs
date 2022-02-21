
using API.Functions;
using API.Models;
using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.IO;

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
            List<Casi> result = scrapingRepository.DataCovid("Italia", $"{d}/API/wwwroot/csv/stati.csv");
            List<Casi> error = scrapingRepository.DataCovid("paeseinesistene", $"{d}/API/wwwroot/csv/stati.csv");

            //Assert
            result[0].Stato.Should().Be("Italia");
            result[0].CasiAttivi.Should().NotBe(0);
            result[0].CasiGiornalieri.Should().NotBe(0);
            result[0].Popolazione.Should().NotBe(0);
            result[0].PercentualeContagi.Should().NotBe(0);

            error[0].Stato.Should().Be("paeseinesistene");
            error[0].Popolazione.Should().Be(0);
            error[0].PercentualeContagi.Should().Be(0);
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


            //Assert
            result.Should().NotBe(null);
        }
    }
}
