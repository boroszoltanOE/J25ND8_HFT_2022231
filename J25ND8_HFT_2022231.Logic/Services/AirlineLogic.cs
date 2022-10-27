using J25ND8_HFT_2022231.Logic.Interfaces;
using J25ND8_HFT_2022231.Models;
using J25ND8_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Logic.Services
{
    public class AirlineLogic : IAirlineLogic
    {
        IAirlineRepository airlineRepo;
        public AirlineLogic(IAirlineRepository airlineRepo)
        {
            this.airlineRepo = airlineRepo;
        }


        public void Create(Airline airline)
        {
            airlineRepo.Create(airline);
        }

        public void Delete(int id)
        {
            airlineRepo.Delete(id);
        }

        public Airline Read(int id)
        {
            return airlineRepo.Read(id) ?? throw new ArgumentException("There is no airline with this id!");
        }

        public IEnumerable<Airline> ReadAll()
        {
            return airlineRepo.ReadAll();
        }

        public void Update(Airline airline)
        {
            airlineRepo.Update(airline);
        }
    }
}
