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
    public class PassengerLogic : IPassengerLogic
    {
        IPassengerRepository passengerRepo;
        public PassengerLogic(IPassengerRepository passengerRepo)
        {
            this.passengerRepo = passengerRepo;
        }

        public void Create(Passenger passenger)
        {
            if (passenger.Name == null)
            {
                throw new ArgumentNullException("Name can't be null!");
            }
            else
            {
                passengerRepo.Create(passenger);
            }
        }

        public void Delete(int id)
        {
            passengerRepo.Delete(id);
        }

        public Passenger Read(int id)
        {
            return passengerRepo.Read(id) ?? throw new ArgumentException("There is no passenger with this id!");
        }

        public IEnumerable<Passenger> ReadAll()
        {
            return passengerRepo.ReadAll();
        }

        public void Update(Passenger passenger)
        {
            passengerRepo.Update(passenger);
        }
        public IEnumerable<KeyValuePair<string,int>> AirlinesMostExpensiveTickets()
        {
            return from x in passengerRepo.ReadAll()
                   group x by x.Plane.Airline.Name into g
                   select new KeyValuePair<string, int>(g.Key, g.Max(t => t.TicketPrice));
        }

        public IEnumerable<KeyValuePair<string, double>> AVGTicketPricesPerAirlines()
        {
            return from x in passengerRepo.ReadAll()
                   group x by x.Plane.Airline.Name into g
                   select new KeyValuePair<string, double>(g.Key, Math.Round(g.Average(t => t.TicketPrice),0));
        }

        public IEnumerable<KeyValuePair<string, int>> CountOfSoldFirstClassTicketsPerAirlines()
        {
            return from x in passengerRepo.ReadAll()
                   group x by x.Plane.Airline.Name into g
                   select new KeyValuePair<string, int>(g.Key, g.Count(t => t.FirstClass.Equals(true)));
        }
    }
}
