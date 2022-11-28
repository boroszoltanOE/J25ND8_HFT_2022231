using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J25ND8_HFT_2022231.Logic.Services;
using J25ND8_HFT_2022231.Logic.Interfaces;
using J25ND8_HFT_2022231.Repository.Interfaces;
using J25ND8_HFT_2022231.Models;

namespace J25ND8_HFT_2022231.Test
{
    [TestFixture]
    public class PassengerLogicTester
    {
        PassengerLogic pl;
        Mock<IPassengerRepository> mockPassengerRepository;

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
                Id = 2,
                Name = "AzerbaijanAirline",
                SafetyPoint = 3.0
            };
            Plane plane1 = new Plane()
            {
                Id = 1,
                Type = "SuperFast 14",
                Airline = fakeAirline1,
                CalculatedTime = 15.4
            };
            Plane plane2 = new Plane()
            {
                Id = 2,
                Type = "SafetyPlane WR4",
                Airline = fakeAirline1,
                CalculatedTime = 14.2
            };
            Plane plane3 = new Plane()
            {
                Id = 3,
                Type = "HAZ-145 srx",
                Airline = fakeAirline2,
                CalculatedTime = 6.3
            };
            Plane plane4 = new Plane()
            {
                Id = 4,
                Type = "SRV T765",
                Airline = fakeAirline2,
                CalculatedTime = 3.2
            };
            var passengers = new List<Passenger>()
            {
                new Passenger()
                {
                    Id = 1,
                    TicketPrice = 10000,
                    FirstClass = true,
                    Plane = plane4
                },
                new Passenger()
                {
                    Id = 2,
                    TicketPrice = 2300,
                    FirstClass = true,
                    Plane = plane1
                },
                new Passenger()
                {
                    Id = 3,
                    TicketPrice = 4500,
                    FirstClass = true,
                    Plane = plane1
                },
                new Passenger()
                {
                    Id = 4,
                    TicketPrice = 23000,
                    FirstClass = false,
                    Plane = plane1
                },
                new Passenger()
                {
                    Id = 5,
                    TicketPrice = 4500,
                    FirstClass = true,
                    Plane = plane3
                },
                new Passenger()
                {
                    Id = 6,
                    TicketPrice = 1250,
                    FirstClass = true,
                    Plane = plane3
                },
                new Passenger()
                {
                    Id = 7,
                    TicketPrice = 12430,
                    FirstClass = true,
                    Plane = plane2
                },
                new Passenger()
                {
                    Id = 8,
                    TicketPrice = 2300,
                    FirstClass = false,
                    Plane = plane2
                }
            }.AsQueryable();
            mockPassengerRepository = new Mock<IPassengerRepository>();
            mockPassengerRepository.Setup(p => p.ReadAll()).Returns(passengers);
            pl = new PassengerLogic(mockPassengerRepository.Object);
        }
        [Test]
        public void AirlinesMostExpensiveTickets()
        {
            var result = pl.AirlinesMostExpensiveTickets();
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("AzerbaijanAirline",10000),
                new KeyValuePair<string, int>("LuxemburgAirline",23000)
            };
            Assert.That(result, Is.EqualTo(expected)); 
        }
        [Test]
        public void AVGTicketPricesPerAirlines()
        {
            var result = pl.AVGTicketPricesPerAirlines();
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("AzerbaijanAirline",5250),
                new KeyValuePair<string, double>("LuxemburgAirline",8906)
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void CountOfSoldFirstClassTicketsPerAirlines()
        {
            var result = pl.CountOfSoldFirstClassTicketsPerAirlines();
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("AzerbaijanAirline",3),
                new KeyValuePair<string, int>("LuxemburgAirline",3)
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void Delete()
        {
            pl.Delete(1);

            mockPassengerRepository
                .Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }
        [Test]
        public void Create()
        {
            var result = new Passenger() { Id = 3, Name = null};
            mockPassengerRepository.Verify(m => m.Create(result), Times.Never());
        }
    }
}
