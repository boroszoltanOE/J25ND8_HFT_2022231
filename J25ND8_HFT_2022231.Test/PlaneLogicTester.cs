using System;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J25ND8_HFT_2022231.Logic.Services;
using J25ND8_HFT_2022231.Repository.Interfaces;
using J25ND8_HFT_2022231.Models;

namespace J25ND8_HFT_2022231.Test
{
    [TestFixture]
    public class PlaneLogicTester
    {
        PlaneLogic pl;
        Mock<IPlaneRepository> mockPlaneRepository;

        [SetUp]
        public void Init()
        {
            Airline fakeAirline1 = new Airline()
            {
                Id = 1,
                Name = "LuxemburgAirline",
                SafetyPoint = 5.1
            };
            Airline fakeAirline2 = new Airline()
            {
                Id=2,
                Name = "AzerbaijanAirline",
                SafetyPoint = 3.0
            };
            var planes = new List<Plane>()
            {
                new Plane()
                {
                    Id = 1,
                    Type = "SuperFast 14",
                    Airline = fakeAirline1,
                    CalculatedTime = 15.4
                },
                new Plane()
                { 
                    Id = 2,
                    Type = "SafetyPlane WR4",
                    Airline= fakeAirline1,
                    CalculatedTime = 14.2
                },
                new Plane()
                {
                    Id = 3,
                    Type = "HAZ-145 srx",
                    Airline = fakeAirline2,
                    CalculatedTime = 6.3
                },
                new Plane()
                { 
                    Id = 4,
                    Type = "SRV T765",
                    Airline = fakeAirline2,
                    CalculatedTime = 3.2
                }
            }.AsQueryable();
            mockPlaneRepository = new Mock<IPlaneRepository>();
            mockPlaneRepository.Setup(p => p.ReadAll()).Returns(planes);
            pl = new PlaneLogic(mockPlaneRepository.Object);
        }
        [Test]
        public void PlanesWithSafeAirlines()
        {
            var result = pl.PlanesWithSafeAirlines();
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("SuperFast 14",5.1),
                new KeyValuePair<string, double>("SafetyPlane WR4",5.1)
            };
            Assert.That(result,Is.EqualTo(expected));
        }
        [Test]
        public void LongestTravelsPerAirlines()
        {
            var result = pl.LongestTravelsPerAirlines();
            var expected = new List<KeyValuePair<string,double>>()
            {
                new KeyValuePair<string,double>("LuxemburgAirline",15.4),
                new KeyValuePair<string,double>("AzerbaijanAirline",6.3)
            };
            Assert.That(result,Is.EqualTo(expected));
        }
        [Test]
        public void Delete()
        {
            pl.Delete(1);

            mockPlaneRepository
                .Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}
