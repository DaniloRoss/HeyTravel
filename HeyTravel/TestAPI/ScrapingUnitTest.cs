using API.Functions;
using API.Models;
using System;
using Xunit;
using FluentAssertions;

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
            Casi result = await scrapingRepository.DataCovid("Italia");
            Casi error = await scrapingRepository.DataCovid("paeseinesistene");


            //Assert
            result.Stato.Should().Be("Italia");
            result.CasiAttivi.Should().NotBe(0);
            result.CasiGiornalieri.Should().NotBe(0);
            result.Popolazione.Should().NotBe(0);
            result.PercentualeContagi.Should().NotBe(0);

            error.Stato.Should().BeNull();
            error.CasiAttivi.Should().Be(0);
            error.CasiGiornalieri.Should().Be(0);
            error.Popolazione.Should().Be(0);
            error.PercentualeContagi.Should().Be(0);
        }

        [Fact]
        public void TestVaccini()
        {
            //Arrange
            ScrapingRepository scrapingRepository = new ScrapingRepository();

            //Act
            Vaccini result = scrapingRepository.DataVaccini("Italia");
            Vaccini error = scrapingRepository.DataVaccini("paeseinesistene");


            //Assert
            result.Stato.Should().Be("Italia");
            result.Vaccinati.Should().NotBe(0);
            result.DosiTotali.Should().NotBe(0);
            result.NuoveDosi.Should().NotBe(0);
            result.PercentualeVaccini.Should().NotBe(0);

            error.Stato.Should().BeNull();
            error.Vaccinati.Should().Be(0);
            error.DosiTotali.Should().Be(0);
            error.NuoveDosi.Should().Be(0);
            error.PercentualeVaccini.Should().Be(0);
        }
    }
}
