using J25ND8_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Logic.Interfaces
{
    public interface IPassengerLogic
    {
        void Create(Passenger passenger);
        void Update(Passenger passenger);
        void Delete(int id);
        Passenger Read(int id);
        IEnumerable<Passenger> ReadAll();
    }
}
