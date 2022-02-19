
//using API.Functions;
//using API.Models;
//using System;
//using Xunit;
//using FluentAssertions;
//using System.Collections.Generic;

//namespace TestAPI
//{
//    public class ScrapingUnitTest
//    {
//        [Fact]
//        public async void TestCasi()
//        {
//            //Arrange
//            ScrapingRepository scrapingRepository = new ScrapingRepository();

//            //Act
//            List<Casi> result = scrapingRepository.DataCovid("Italia");
//            List<Casi> error = scrapingRepository.DataCovid("paeseinesistene");
            
//            //Assert
//            result[0].Stato.Should().Be("Italia");
//            result[0].CasiAttivi.Should().NotBe(0);
//            result[0].CasiGiornalieri.Should().NotBe(0);
//            result[0].Popolazione.Should().NotBe(0);
//            result[0].PercentualeContagi.Should().NotBe(0);

//            result[0].Stato.Should().BeNull();
//            result[0].CasiAttivi.Should().Be(0);
//            result[0].CasiGiornalieri.Should().Be(0);
//            result[0].Popolazione.Should().Be(0);
//            result[0].PercentualeContagi.Should().Be(0);
//        }

//        [Fact]
//        public void TestVaccini()
//        {
//            //Arrange
//            ScrapingRepository scrapingRepository = new ScrapingRepository();

//            //Act
//            Vaccini result = scrapingRepository.DataVaccini("Italia");
//            Vaccini error = scrapingRepository.DataVaccini("paeseinesistene");


//            //Assert
//            result.Stato.Should().Be("Italia");
//            result.Vaccinati.Should().NotBe(0);
//            result.DosiTotali.Should().NotBe(0);
//            result.NuoveDosi.Should().NotBe(0);
//            result.PercentualeVaccini.Should().NotBe(0);

//            error.Stato.Should().BeNull();
//            error.Vaccinati.Should().Be(0);
//            error.DosiTotali.Should().Be(0);
//            error.NuoveDosi.Should().Be(0);
//            error.PercentualeVaccini.Should().Be(0);
//        }

//        [Fact]
//        public void TestCodiceStato()
//        {
//            //Arrange
//            ScrapingRepository scrapingRepository = new ScrapingRepository();

//            //Act
//            var result = scrapingRepository.ExtractCountryCode("Italia");
//            Vaccini error = scrapingRepository.DataVaccini("paeseinesistene");


//            //Assert
//            result.Should().Be("IT");           

//            error.Stato.Should().BeNull();
//            error.Vaccinati.Should().Be(0);
//            error.DosiTotali.Should().Be(0);
//            error.NuoveDosi.Should().Be(0);
//            error.PercentualeVaccini.Should().Be(0);
//        }
//    }
//}
