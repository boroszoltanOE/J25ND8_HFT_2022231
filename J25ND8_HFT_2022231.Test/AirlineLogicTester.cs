using System;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J25ND8_HFT_2022231.Logic.Services;
using J25ND8_HFT_2022231.Models;
using J25ND8_HFT_2022231.Repository.Interfaces;
using System.Runtime.ConstrainedExecution;

namespace J25ND8_HFT_2022231.Test
{
    public class AirlineLogicTester
    {
        AirlineLogic al;
        Mock<IAirlineRepository> mockAirlineRepository;

        [SetUp]
        public void Init()
        {
            var airlines = new List<Airline>(){
                new Airline()
                {
                    Id = 1,
                    Name = "LuxemburgAirline",
                    SafetyPoint = 5.1
                },
                new Airline()
                {
                    Id = 2,
                    Name = "AzerbaijanAirline",
                    SafetyPoint = 3.0
                }
            }.AsQueryable();
            mockAirlineRepository = new Mock<IAirlineRepository>();
            mockAirlineRepository.Setup(p => p.ReadAll()).Returns(airlines);
            al = new AirlineLogic(mockAirlineRepository.Object);
        }
        [Test]
        public void CreateInValid()
        {
            var airline = new Airline() { Id = 3, Name = null, BaseCountry = "Kazahstan" };
            mockAirlineRepository.Verify(m =>m.Create(airline),Times.Never());
        }
        [Test]
        public void Delete()
        {
            al.Delete(1);

            mockAirlineRepository
                .Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }
        [Test]
        public void ReadWithValid()
        {
            Airline expected = new Airline()
            {
                Name = "LuxemburgAirline",
                SafetyPoint = 5.1,
                Id = 1,
            };

            mockAirlineRepository
                .Setup(r => r.Read(1))
                .Returns(expected);

            var result = al.Read(1);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
